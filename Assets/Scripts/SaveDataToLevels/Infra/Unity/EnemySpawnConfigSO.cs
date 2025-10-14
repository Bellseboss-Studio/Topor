using Game.SaveDataToLevels.Domain.Entities;
using UnityEngine;

namespace Game.SaveDataToLevels.Infrastructure.Unity
{
    [CreateAssetMenu(menuName = "Game/Levels/EnemySpawnConfig", fileName = "EnemySpawnConfig", order = 0)]
    public class EnemySpawnConfigSO : ScriptableObject
    {
        public string enemyId;
        public float spawnRate;
        public int maxEnemies;

        public EnemySpawnConfig ToDomain()
        {
            return new EnemySpawnConfig(enemyId, spawnRate, maxEnemies);
        }
    }
}