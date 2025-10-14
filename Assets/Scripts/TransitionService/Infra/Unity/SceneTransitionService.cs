using System;
using System.Collections;
using Game.Domain.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Infrastructure.Unity
{
    public class SceneTransitionService : MonoBehaviour, ITransitionService
    {
        [SerializeField] private TransitionUIController uiController;
        private AsyncOperation operacion;

        public event Action OnCargaIniciada;
        public event Action OnCargaFinalizada;
        public event Action<int> OnEscenaLista;

        public void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0f)
        {
            StartCoroutine(CargarEscenaConTransicion(escenaObjetivo, delayAntesDeCarga));
        }

        private IEnumerator CargarEscenaConTransicion(int escena, float delay)
        {
            OnCargaIniciada?.Invoke();
            uiController.ResetUI();

            if (delay > 0)
                yield return new WaitForSeconds(delay);

            yield return uiController.FadeIn(0.5f);

            operacion = SceneManager.LoadSceneAsync(escena);
            operacion.allowSceneActivation = false;

            while (operacion.progress < 0.9f)
            {
                float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
                uiController.UpdateProgress(progreso);
                yield return null;
            }

            uiController.UpdateProgress(1f);
            yield return new WaitForSeconds(0.1f);

            operacion.allowSceneActivation = true;
        }

        public void OcultarCortinilla()
        {
            StartCoroutine(OcultarYFinalizar());
        }

        private IEnumerator OcultarYFinalizar()
        {
            yield return uiController.FadeOut(0.5f);
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
            OnEscenaLista?.Invoke(scene.buildIndex);
        }
    }
}
