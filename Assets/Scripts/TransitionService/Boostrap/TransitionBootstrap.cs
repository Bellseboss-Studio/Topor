using System;
using Game.Domain.Interfaces;
using Game.Infrastructure.Unity;
using UnityEngine;

namespace Game.TransitionService.Bootstrap
{
    public class TransitionBootstrap : MonoBehaviour, ITransitionServiceBoostrap
    {
        [SerializeField] private SceneTransitionService transitionService;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ServiceLocator.Instance.RegisterService<ITransitionServiceBoostrap>(this);

            // Reenviar eventos
            transitionService.OnCargaIniciada += () => OnCargaIniciada?.Invoke();
            transitionService.OnCargaFinalizada += () => OnCargaFinalizada?.Invoke();
            transitionService.OnEscenaLista += (index) => OnEscenaLista?.Invoke(index);
        }

        public void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0)
        {
            transitionService.IniciarCarga(escenaObjetivo, delayAntesDeCarga);
        }

        public void OcultarCortinilla()
        {
            transitionService.OcultarCortinilla();
        }

        public event Action OnCargaIniciada;
        public event Action OnCargaFinalizada;
        public event Action<int> OnEscenaLista;
    }
}