using System;

namespace Game.MainMenu.Domain
{
    public class MainMenuService : IMainMenuService
    {
        public event Action OnStartGame;
        public event Action OnOpenOptions;

        public void StartGame()
        {
            // Podríamos agregar lógica extra aquí (guardar estado, reproducir sonido, etc)
            OnStartGame?.Invoke();
        }

        public void OpenOptions()
        {
            OnOpenOptions?.Invoke();
        }
    }
}