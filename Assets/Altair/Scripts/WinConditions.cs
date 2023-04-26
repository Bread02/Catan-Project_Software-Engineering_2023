using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
 * This script controls the win screen, and the buttons involved in the win screen
 *
 * @author Altair
 * @version 26/04/2023
 */
public class WinConditions : MonoBehaviour
{
    [Header("Other Scripts")]
    private LoadScene loadScene;

    [Header("Victory Screen UI")]
    public GameObject victoryScreen;
    public TextMeshProUGUI victoryText;

    [Header("Bools")]
    public bool victoryTriggered;

    // Start is called before the first frame update
    void Start()
    {
        loadScene = GameObject.Find("LoadingBar").GetComponent<LoadScene>();

        victoryScreen.SetActive(false);
        victoryTriggered = false;
    }

    // Update is called once per frame
    // debug trigger victory button
    // REMOVE IN FINAL VERSION
    public void TriggerVictoryButton()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            TriggerForfit();
        }
    }

    public void TriggerVictory(PlayerManager winningPlayer)
    {
        victoryScreen.SetActive(true);
        victoryTriggered = true;

        // get the stat card from the winning player and display it.
        

        victoryText.text = "Congratulations! \n \n Player has the most victory points!";
    }

    // triggerS forfit
    private void TriggerForfit()
    {
        victoryScreen.SetActive(true);
        victoryTriggered = true;
        victoryText.text = "Game forfitted. No one won.";
    }

    // REMOVE IN FINAL VERSION
    void Update()
    {
        TriggerVictoryButton();
    }

    // Interacts with load scene to return to main menu
    public void ReturnToMainMenu()
    {
        StartCoroutine(loadScene.LoadSceneCoroutine("MainMenuFinal"));
    }

    // Interacts with load scene to return to play menu
    public void PlayAgain()
    {
        StartCoroutine(loadScene.LoadSceneCoroutine("PlayMenu"));
    }



}
