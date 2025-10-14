using System.Collections.Generic;

namespace Game.SaveDataToLevels.Domain.Entities
{
    public class LevelConfig
    {
        public int LevelIndex { get; }
        public int TimeOfGame { get; }
        public bool CanPlayCinematic { get; }
        public IReadOnlyList<LevelStep> Steps { get; }

        public LevelConfig(int levelIndex, int timeOfGame, bool canPlayCinematic, IReadOnlyList<LevelStep> steps)
        {
            LevelIndex = levelIndex;
            TimeOfGame = timeOfGame;
            CanPlayCinematic = canPlayCinematic;
            Steps = steps;
        }
    }
}