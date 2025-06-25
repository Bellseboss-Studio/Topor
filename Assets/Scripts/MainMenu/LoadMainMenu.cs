using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        ServiceLocator.Instance.GetService<ITransitionService>().OnEscenaLista += LoadScene;
    }

    private void LoadScene(int escenaBuildIndex)
    {
        if (escenaBuildIndex == SceneManager.GetActiveScene().buildIndex)
        {
            ServiceLocator.Instance.GetService<ITransitionService>().OcultarCortinilla();
            ServiceLocator.Instance.GetService<ITransitionService>().OnEscenaLista -= LoadScene;
        }
    }
}