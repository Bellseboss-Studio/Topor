using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.SaveDataToLevels.Infrastructure.Unity
{
    [CreateAssetMenu(menuName = "Bellseboss/SelectorLevel/LevelStart", fileName = "LevelStartData", order = 0)]
    public class LevelStartDataSO : ScriptableObject
    {
        [SerializeField] private int timeOfGame;

        // [SerializeField] private List<StepOfGame> steps;
        [SerializeField] private int levelIndex;
        [SerializeField] private bool canPlayCinematic;

        public int TimeOfGame => timeOfGame;

        // public List<StepOfGame> Steps => steps;
        public int LevelIndex => levelIndex + 3;
        public bool CanPlayCinematic => canPlayCinematic;

        public void Initialize()
        {
            // foreach (var stepSpawnRatioEnemy in steps.SelectMany(step => step.toposToSpawn))
            // {
            //     stepSpawnRatioEnemy.deltaSpawn = 0;
            // }
            //
            // foreach (var step in steps.Where(step => step.timeLineStep != null))
            // {
            //     step.Configure();
            // }
        }
    }
}