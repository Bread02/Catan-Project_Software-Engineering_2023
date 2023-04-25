using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseUI;

    [SerializeField] private LoadScene loadScene;

    private void Start()
    {
        loadScene = GameObject.Find("LoadingBar").GetComponent<LoadScene>();
    }

    public void PauseGame(){
        paused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        paused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        paused = false;
        StartCoroutine(loadScene.LoadSceneCoroutine("MainMenuFinal"));
        SceneManager.LoadScene(0);
    }
}
