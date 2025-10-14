using System.Collections.Generic;
using System.Linq;
using Game.SaveDataToLevels.Domain.Entities;
using UnityEngine;

namespace Game.SaveDataToLevels.Infrastructure.Unity
{
    [CreateAssetMenu(menuName = "Game/Levels/LevelStep", fileName = "LevelStep", order = 1)]
    public class LevelStepSO : ScriptableObject
    {
        public int weight = 1;
        public bool isTutorialStep;
        public bool pauseGameDuringStep;
        public string timelineId;
        public List<EnemySpawnConfigSO> enemyConfigs;

        public LevelStep ToDomain()
        {
            var enemies = enemyConfigs?.Select(e => e.ToDomain()).ToList() ??
                          new List<EnemySpawnConfig>();
            return new LevelStep(weight, enemies, isTutorialStep, pauseGameDuringStep,
                timelineId);
        }
    }
}