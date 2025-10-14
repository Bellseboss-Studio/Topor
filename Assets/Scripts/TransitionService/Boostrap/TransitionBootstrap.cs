using System;
using Game.Infrastructure.Unity;
using UnityEngine;

namespace Game.TransitionService.Bootstrap
{
    public class TransitionBootstrap : MonoBehaviour, ITransitionServiceBoostrap
    {
        [SerializeField] private SceneTransitionService transitionService;

        public event Action OnCargaIniciada;
        public event Action OnCargaFinalizada;
        public event Action<int> OnEscenaLista;

        private void Awake()
        {
            // Evita duplicados persistentes
            if (FindObjectsByType<TransitionBootstrap>(FindObjectsSortMode.None).Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            if (transitionService == null)
            {
                Debug.LogError($"[TransitionBootstrap] No se asignó un SceneTransitionService en {name}");
                return;
            }

            ServiceLocator.Instance.RegisterService<ITransitionServiceBoostrap>(this);

            // Suscribir eventos del servicio interno
            transitionService.OnCargaIniciada += HandleCargaIniciada;
            transitionService.OnCargaFinalizada += HandleCargaFinalizada;
            transitionService.OnEscenaLista += HandleEscenaLista;
        }

        private void OnDestroy()
        {
            // Limpieza para evitar fugas de eventos
            if (transitionService != null)
            {
                transitionService.OnCargaIniciada -= HandleCargaIniciada;
                transitionService.OnCargaFinalizada -= HandleCargaFinalizada;
                transitionService.OnEscenaLista -= HandleEscenaLista;
            }
        }

        public void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0f)
        {
            transitionService?.IniciarCarga(escenaObjetivo, delayAntesDeCarga);
        }

        public void OcultarCortinilla()
        {
            transitionService?.OcultarCortinilla();
        }

        private void HandleCargaIniciada() => OnCargaIniciada?.Invoke();
        private void HandleCargaFinalizada() => OnCargaFinalizada?.Invoke();
        private void HandleEscenaLista(int index) => OnEscenaLista?.Invoke(index);
    }
}