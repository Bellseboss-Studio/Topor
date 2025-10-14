using Game.SaveDataToLevels.Domain.Entities;
using Game.SaveDataToLevels.Domain.Services;
using Game.SaveDataToLevels.Infrastructure.Unity;
using UnityEngine;

namespace Game.SaveDataToLevels.Bootstrap
{
    public class LevelBootstrap : MonoBehaviour, ILevelBoostrapFacade
    {
        [SerializeField] private LevelStartDataSO levelStartData;
        private ILevelConfigService _levelService;

        private void Awake()
        {
            if (FindObjectsByType<LevelBootstrap>(FindObjectsSortMode.InstanceID).Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            ServiceLocator.Instance.RegisterService<ILevelBoostrapFacade>(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<ILevelBoostrapFacade>();
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