using UnityEngine;
using UnityEngine.UI;

namespace SelectorLevel.Infra.Unity
{
    [RequireComponent(typeof(Button))]
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private ScriptableLevelConfig levelConfig;
        [SerializeField] private Button levelButton;

        public ScriptableLevelConfig LevelConfig => levelConfig;
        public Button Button => levelButton;
    }
}