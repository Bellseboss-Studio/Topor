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
            var splashItems = imagesToShow
                .Select(image => new SplashItem(SplashType.Image, image.imageName, image.timeToTransition)).ToList();

            _iSplashService = splashService;
            _iSplashService.OnSplashEnded += () => SceneManager.LoadScene("MainMenu");

            _transitionService.OnCargaFinalizada += () => { _iSplashService.PlaySequence(splashItems); };
            _transitionService.OcultarCortinilla();
        }
    }
}