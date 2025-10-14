using Game.MainMenu.Domain;
using Game.MainMenu.Infra.Unity;
using Game.TransitionService.Bootstrap;
using UnityEngine;

namespace Game.MainMenu.Bootstrap
{
    public class MainMenuBootstrap : MonoBehaviour, IMainMenuServiceBoostrap
    {
        private IMainMenuService _service;
        [SerializeField] private MainMenuUIController mainMenuController;

        private void Start()
        {
            _service = new MainMenuService();
            var transition = ServiceLocator.Instance.GetService<ITransitionServiceBoostrap>();
            mainMenuController.Configure(_service, transition);
        }
    }
}