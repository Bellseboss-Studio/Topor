using Game.SaveDataToLevels.Bootstrap;
using Game.TransitionService.Bootstrap;
using SelectorLevel.Infra.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SelectorLevel.Boostrap
{
    public class SelectLevelBoostrap : MonoBehaviour
    {
        [Header("Dependencies")] [SerializeField]
        private ScrollSoundController scrollSoundController;

        [Header("Level Buttons")] [SerializeField]
        private LevelButtonView[] levelButtons;

        private ILevelBoostrapFacade SaveLevelService;
        private ITransitionServiceBoostrap transitionServiceBoostrap;

        private void Start()
        {
            SaveLevelService = ServiceLocator.Instance.GetService<ILevelBoostrapFacade>();
            transitionServiceBoostrap = ServiceLocator.Instance.GetService<ITransitionServiceBoostrap>();
            scrollSoundController.Configure();

            foreach (var buttonView in levelButtons)
            {
                var config = buttonView.LevelConfig;
                buttonView.Button.onClick.AddListener(() => OnLevelSelected(config));
            }

            transitionServiceBoostrap.OcultarCortinilla();
        }

        private void OnLevelSelected(ScriptableLevelConfig config)
        {
            if (config == null)
            {
                Debug.LogWarning("LevelConfig is null.");
                return;
            }

            var levelData = config.ToDomain();
            SaveLevelService.SaveLevel(levelData);


            transitionServiceBoostrap.OnCargaFinalizada +=
                () => Debug.Log($"Level {levelData.LevelIndex} selected. Transitioning...");
            transitionServiceBoostrap.IniciarCarga(levelData.LevelIndex);
            foreach (var buttonView in levelButtons)
            {
                buttonView.Button.interactable = false;
            }

            // Aquí defines tu transición al juego (puedes usar tu TransitionService)
            // SceneManager.LoadScene("Gameplay");
        }

        private void OnDestroy()
        {
            foreach (var buttonView in levelButtons)
            {
                buttonView.Button.onClick.RemoveAllListeners();
            }
        }
    }
}