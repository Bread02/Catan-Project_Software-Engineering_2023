using UnityEngine;
using UnityEngine.SceneManagement;

public class MainsButton : MonoBehaviour
{

    [SerializeField] private LoadScene loadScene;
    
    public void GoToScene(string sceneName)
    {
     //   SceneManager.LoadScene(sceneName);
        StartCoroutine(loadScene.LoadSceneCoroutine(sceneName));
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has been quit :( .");
    }
}
