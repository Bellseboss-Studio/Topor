using Game.SaveDataToLevels.Domain.Entities;

namespace Game.SaveDataToLevels.Domain.Services
{
    public class LevelConfigService : ILevelConfigService
    {
        private LevelConfig _levelConfig;

        public void SaveLevel(LevelConfig level)
        {
            _levelConfig = level;
        }

        public LevelConfig GetCurrentLevel()
        {
            return _levelConfig;
        }
    }
}