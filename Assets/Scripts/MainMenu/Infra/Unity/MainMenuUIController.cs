using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Game.MainMenu.Domain;
using Game.TransitionService.Bootstrap;

namespace Game.MainMenu.Infra.Unity
{
    public class MainMenuUIController : MonoBehaviour
    {
        [Header("UI References")] [SerializeField]
        private Button startButton;

        [SerializeField] private Button optionsButton;

        [Header("Scene Info")] [SerializeField]
        private int nextSceneIndex = 1;

        [SerializeField] private MainMenuAnimatorController[] animatorController;


        private IMainMenuService MenuService;

        private ITransitionServiceBoostrap TransitionBoostrap;

        public void Configure(IMainMenuService service, ITransitionServiceBoostrap transition)
        {
            MenuService = service;
            TransitionBoostrap = transition;

            startButton.onClick.AddListener(OnStartClicked);
            optionsButton.onClick.AddListener(OnOptionsClicked);

            // Suscribirse a eventos del servicio (opcional)
            MenuService.OnStartGame += HandleStartGame;
            TransitionBoostrap.OcultarCortinilla();
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(OnStartClicked);
            optionsButton.onClick.RemoveListener(OnOptionsClicked);
            MenuService.OnStartGame -= HandleStartGame;
        }

        private void OnStartClicked()
        {
            MenuService.StartGame();
        }

        private void OnOptionsClicked()
        {
            MenuService.OpenOptions();
        }

        private void HandleStartGame()
        {
            // Deshabilitar botones
            startButton.interactable = false;
            optionsButton.interactable = false;

            // Animación (si existe)

            if (animatorController != null || animatorController?.Length > 0)
            {
                foreach (var controller in animatorController)
                {
                    controller.PlayIntro();
                }
            }

            // Esperar 1 segundo y luego hacer la transición
            StartCoroutine(LoadAfterDelay(1f));
        }

        private IEnumerator LoadAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            TransitionBoostrap.IniciarCarga(nextSceneIndex, 0f);
        }
    }
}