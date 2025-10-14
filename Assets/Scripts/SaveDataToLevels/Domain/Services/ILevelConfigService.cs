using Game.SaveDataToLevels.Domain.Entities;

namespace Game.SaveDataToLevels.Domain.Services
{
    public interface ILevelConfigService
    {
        void SaveLevel(LevelConfig level);
        LevelConfig GetCurrentLevel();
    }
}