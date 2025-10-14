using Game.SaveDataToLevels.Domain.Entities;

namespace Game.SaveDataToLevels.Bootstrap
{
    public interface ILevelBoostrapFacade
    {
        void SaveLevel(LevelConfig level);
        LevelConfig GetCurrentLevel();
    }
}