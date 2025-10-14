using System.Collections.Generic;

namespace Game.SaveDataToLevels.Domain.Entities
{
    public class LevelStep
    {
        public int Weight { get; } // Influye en la duración relativa del step
        public IReadOnlyList<EnemySpawnConfig> Enemies { get; }
        public bool IsTutorialStep { get; } // Si este step pertenece a un tutorial
        public bool PauseGameDuringStep { get; } // Si el tiempo debe detenerse
        public string TimelineId { get; } // Si tiene una timeline asociada

        public LevelStep(int weight,
            IReadOnlyList<EnemySpawnConfig> enemies,
            bool isTutorialStep = false,
            bool pauseGame = false,
            string timelineId = null)
        {
            Weight = weight;
            Enemies = enemies;
            IsTutorialStep = isTutorialStep;
            PauseGameDuringStep = pauseGame;
            TimelineId = timelineId;
        }
    }
    
    
}