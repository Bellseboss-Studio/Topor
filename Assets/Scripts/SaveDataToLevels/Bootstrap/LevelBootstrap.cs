using Game.SaveDataToLevels.Domain.Entities;
using Game.SaveDataToLevels.Domain.Services;
using UnityEngine;

namespace Game.SaveDataToLevels.Bootstrap
{
    public class LevelBootstrap : MonoBehaviour, ILevelBoostrapFacade
    {
        private ILevelConfigService _levelService;

        private void Awake()
        {
            if (FindObjectsByType<LevelBootstrap>(FindObjectsSortMode.InstanceID).Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            _levelService = new LevelConfigService();
            ServiceLocator.Instance.RegisterService<ILevelBoostrapFacade>(this);
        }

        public void SaveLevel(LevelConfig level)
        {
            _levelService.SaveLevel(level);
        }

        public LevelConfig GetCurrentLevel()
        {
            return _levelService.GetCurrentLevel();
        }
    }
}