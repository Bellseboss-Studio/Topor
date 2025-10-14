namespace Game.SaveDataToLevels.Domain.Entities
{
    public class EnemySpawnConfig
    {
        public string EnemyId { get; } // ID o tipo del enemigo
        public float SpawnRate { get; } // Enemigos por segundo o intervalo
        public int MaxEnemies { get; } // Opcional, límite

        public EnemySpawnConfig(string enemyId, float spawnRate, int maxEnemies)
        {
            EnemyId = enemyId;
            SpawnRate = spawnRate;
            MaxEnemies = maxEnemies;
        }
    }
}