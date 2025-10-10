using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DebugCustom.Script
{
    public class DebugCustomFacade : MonoBehaviour, IDebugCustom
    {
        [SerializeField] private Button button_show_debug;
        [SerializeField] private AnimatorDebugPanel debug_panel_animator;
        private bool isDebugVisible;
        private bool isTracker;

        private void Awake()
        {
            if(FindObjectsOfType<DebugCustomFacade>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            SceneManager.sceneLoaded += OnSceneLoaded;
            isTracker = true;
            DontDestroyOnLoad(gameObject);
            button_show_debug.onClick.AddListener(ShowOrHideDebug);
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            
        }
        
        private void OnDestroy()
        {
            if(isTracker)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }
        }

        private void ShowOrHideDebug()
        {
            isDebugVisible = !isDebugVisible;
            debug_panel_animator.ShowOrHideDebug(isDebugVisible);
        }
    }
}