using System;

namespace Game.MainMenu.Domain
{
    public interface IMainMenuService
    {
        event Action OnStartGame;
        event Action OnOpenOptions;

        void StartGame();
        void OpenOptions();
    }
}