using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseUI;

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
        SceneManager.LoadScene(0);
    }
}
