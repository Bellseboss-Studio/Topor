using SaveDataToLevels.Domain.Interfaces;
using UnityEngine;

namespace Game.SaveDataToLevels.Infrastructure.Unity
{
    public class TimeControlService : MonoBehaviour, ITimeControlService
    {
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }
    }
}