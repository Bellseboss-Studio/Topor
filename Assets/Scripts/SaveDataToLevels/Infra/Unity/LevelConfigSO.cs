using System.Collections.Generic;
using System.Linq;
using Game.SaveDataToLevels.Domain.Entities;
using UnityEngine;

namespace Game.SaveDataToLevels.Infrastructure.Unity
{
    [CreateAssetMenu(menuName = "Game/Levels/LevelConfig", fileName = "LevelConfig", order = 2)]
    public class LevelConfigSO : ScriptableObject
    {
        public int levelIndex;
        public int timeOfGame;
        public bool canPlayCinematic;
        public List<LevelStepSO> steps;

        public LevelConfig ToDomain()
        {
            var stepDomains = steps?.Select(s => s.ToDomain()).ToList() ?? new List<LevelStep>();
            return new LevelConfig(levelIndex, timeOfGame, canPlayCinematic, stepDomains);
        }
    }
}