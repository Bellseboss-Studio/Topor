using System.Collections.Generic;
using System.Linq;
using Game.SaveDataToLevels.Domain.Entities;
using UnityEngine;

namespace SelectorLevel.Infra.Unity
{
    [CreateAssetMenu(fileName = "LevelConfigSO", menuName = "Game/Levels/LevelConfig")]
    public class ScriptableLevelConfig : ScriptableObject
    {
        [SerializeField] private int levelIndex;
        [SerializeField] private int timeOfGame;
        [SerializeField] private bool canPlayCinematic;
        [SerializeField] private List<LevelStepData> steps = new();

        public LevelConfig ToDomain()
        {
            var domainSteps = new List<LevelStep>();
            foreach (var stepData in steps)
            {
                var enemies = stepData.enemies
                    .Select(enemy => new EnemySpawnConfig(enemy.enemyId, enemy.spawnRate, enemy.maxEnemies)).ToList();

                domainSteps.Add(new LevelStep(
                    stepData.weight,
                    enemies,
                    stepData.isTutorialStep,
                    stepData.pauseGameDuringStep,
                    stepData.timelineId
                ));
            }

            return new LevelConfig(levelIndex, timeOfGame, canPlayCinematic, domainSteps);
        }

        [System.Serializable]
        public class LevelStepData
        {
            public int weight;
            public bool isTutorialStep;
            public bool pauseGameDuringStep;
            public string timelineId;
            public List<EnemySpawnData> enemies;
        }

        [System.Serializable]
        public class EnemySpawnData
        {
            public string enemyId;
            public float spawnRate;
            public int maxEnemies;
        }
    }
}