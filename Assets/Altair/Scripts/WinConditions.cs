using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinConditions : MonoBehaviour
{


    [Header("Player Victory Point Track")]
    private int player1VictoryPoints;
    private int player2VictoryPoints;
    private int player3VictoryPoints;
    private int player4VictoryPoints;

    [Header("Victory Screen UI")]
    public GameObject victoryScreen;
    public TextMeshProUGUI victoryText;

    public bool victoryTriggered;


    // Start is called before the first frame update
    void Start()
    {
        victoryScreen.SetActive(false);
        victoryTriggered = false;
    }

    // Update is called once per frame
    // debug trigger victory button
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
        

        victoryText.text = "Player has most victory points! Conngratulations!";
    }

    // trigger forfit
    private void TriggerForfit()
    {
        victoryScreen.SetActive(true);
        victoryTriggered = true;
        victoryText.text = "Game forfitted. No one won.";
    }


    void Update()
    {
        TriggerVictoryButton();
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Clicked Main Menu Button");
        SceneManager.LoadScene("MainMenuFinal");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayMenu");
    }



}
