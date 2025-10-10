using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionService : MonoBehaviour, ITransitionService
{
    [SerializeField] private CanvasGroup cortinilla;
    [SerializeField] private Slider barraCarga;
    [SerializeField] private TextMeshProUGUI textoPorcentaje;

    private AsyncOperation operacion;

    public event Action OnCargaIniciada;
    public event Action OnCargaFinalizada;
    public event Action<int> OnEscenaLista;

    private void Awake()
    {
        if (FindObjectsOfType<TransitionService>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        ServiceLocator.Instance.RegisterService<ITransitionService>(this);
        cortinilla.alpha = 0f;
        cortinilla.blocksRaycasts = false;
        cortinilla.interactable = false;
    }

    public void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0f)
    {
        StartCoroutine(CargarEscenaConTransicion(escenaObjetivo, delayAntesDeCarga));
    }

    private IEnumerator CargarEscenaConTransicion(int escena, float delay)
    {
        OnCargaIniciada?.Invoke();

        cortinilla.blocksRaycasts = true;
        cortinilla.interactable = true;

        barraCarga.value = barraCarga.minValue;
        if (textoPorcentaje != null)
            textoPorcentaje.text = "0%";
        if (delay > 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        // 1. Fade in
        yield return cortinilla.DOFade(1f, 0.5f).SetEase(Ease.InOutQuad).WaitForCompletion();

        // 2. Comenzar carga
        operacion = SceneManager.LoadSceneAsync(escena);
        operacion.allowSceneActivation = false;

        // 3. Mostrar progreso
        while (operacion.progress < 0.9f)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
            barraCarga.value = progreso;

            if (textoPorcentaje != null)
                textoPorcentaje.text = $"{(int)(progreso * 100)}%";

            yield return null;
        }

        barraCarga.value = barraCarga.maxValue;
        if (textoPorcentaje != null)
            textoPorcentaje.text = "100%";

        // 4. Asegurarse que el fade-in se haya completado (por si hay latencia visual)
        yield return new WaitForSeconds(0.1f);

        // 5. Activar la escena solo cuando la cortinilla esté completamente visible
        operacion.allowSceneActivation = true;
    }


    public void OcultarCortinilla()
    {
        StartCoroutine(OcultarYFinalizar());
    }

    private IEnumerator OcultarYFinalizar()
    {
        yield return cortinilla.DOFade(0f, 0.5f).WaitForCompletion();
        cortinilla.blocksRaycasts = false;
        cortinilla.interactable = false;
        OnCargaFinalizada?.Invoke();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += EscenaCargada;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= EscenaCargada;
    }

    private void EscenaCargada(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);
        OnEscenaLista?.Invoke(scene.buildIndex);
    }
}


public interface ITransitionService
{
    void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0f);
    void OcultarCortinilla();
    event Action OnCargaIniciada;
    event Action OnCargaFinalizada;
    event Action<int> OnEscenaLista;
}