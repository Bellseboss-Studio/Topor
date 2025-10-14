using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void NextTo(int sceneIndex)
    {
        //SceneManager.LoadScene(sceneIndex);
        ServiceLocator.Instance.GetService<ITransitionService>().IniciarCarga(sceneIndex, 1);
    }
}
