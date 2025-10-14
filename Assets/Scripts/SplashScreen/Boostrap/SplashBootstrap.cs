using System.Collections.Generic;
using System.Linq;
using Game.TransitionService.Bootstrap;
using Game.Splash.Domain.Entities;
using Game.Splash.Domain.Interfaces;
using Game.Splash.Infra.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Splash.Bootstrap
{
    public class SplashBootstrap : MonoBehaviour
    {
        [SerializeField] private SplashService splashService;
        [SerializeField] private List<SplashScreenSerializable> imagesToShow;

        private ISplashService _iSplashService;
        private ITransitionServiceBoostrap _transitionService;

        private void Start()
        {
            _transitionService = ServiceLocator.Instance.GetService<ITransitionServiceBoostrap>();
            _iSplashService = splashService;

            // Generar la secuencia de items del splash
            var splashItems = imagesToShow
                .Select(image => new SplashItem(SplashType.Image, image.imageName, image.timeToTransition))
                .ToList();

            // Suscribirse al evento de finalización del splash
            _iSplashService.OnSplashEnded += OnSplashEnded;

            // Suscribirse a la transición
            _transitionService.OnCargaFinalizada += OnTransitionFinished;

            // Ocultar la cortinilla para mostrar el splash
            _transitionService.OcultarCortinilla();

            // Local function: evita lambdas con capturas de referencia fuera del control del ciclo de vida
            void OnTransitionFinished()
            {
                if (_iSplashService != null && splashService != null)
                {
                    _iSplashService.PlaySequence(splashItems);
                }
            }
        }

        private void OnSplashEnded()
        {
            _iSplashService.OnSplashEnded -= OnSplashEnded;
            _transitionService.OnCargaFinalizada -= OnTransitionFinishedSafe;

            SceneManager.LoadScene("MainMenu");
        }

        private void OnDestroy()
        {
            // Seguridad adicional
            _iSplashService.OnSplashEnded -= OnSplashEnded;
            _transitionService.OnCargaFinalizada -= OnTransitionFinishedSafe;
        }

        // Método auxiliar para poder desuscribir correctamente el evento (no se puede desuscribir lambdas anónimas)
        private void OnTransitionFinishedSafe()
        {
            if (_iSplashService != null)
                _iSplashService.PlaySequence(imagesToShow
                    .Select(image => new SplashItem(SplashType.Image, image.imageName, image.timeToTransition))
                    .ToList());
        }
    }
}