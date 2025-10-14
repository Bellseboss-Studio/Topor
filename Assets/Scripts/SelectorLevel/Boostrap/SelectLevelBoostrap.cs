using System;
using Game.SaveDataToLevels.Bootstrap;
using SelectorLevel.Infra.Unity;
using UnityEngine;

namespace SelectorLevel.Boostrap
{
    public class SelectLevelBoostrap : MonoBehaviour
    {
        private ILevelBoostrapFacade SaveLevelService;
        [SerializeField] private ScrollSoundController scrollSoundController;

        private void Start()
        {
            SaveLevelService = ServiceLocator.Instance.GetService<ILevelBoostrapFacade>();
            scrollSoundController.Configure();
        }
    }
}