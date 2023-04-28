using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * This script controls the abridged mode in the main game. It controls the time remaining on the screen and
 * triggers the final turn on the turnManager.
 *
 * @author Altair Robinson
 * @version 26/04/2023
 */
public class AbridgedMode : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;

    [Header("UI")]
    public TextMeshProUGUI timeRemainingText;
    public GameObject abridgedUI;

    [Header("Time Remaining")]
    public float timeRemaining;

    [Header("Bools")]
    public bool isAbridgedMode;
    public bool isCountingDown;

    // Start is called before the first frame update
    void Awake()
    {
        abridgedUI.SetActive(false);
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void SetupAbridged(int totalTime)
    {
        isAbridgedMode = true;
        abridgedUI.SetActive(true);
        isCountingDown = true;
        timeRemaining = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        // DEBUGS. REMOVE ON FINAL VERSION
        /*
        if(Input.GetKeyDown(KeyCode.V))
        {
            SetupAbridged(180);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            timeRemaining = 3;
        }
        */

        // count down if abridged mode
        if (isCountingDown)
        {
            CountDown();
        }
    }

    // This counts down the timer. Starting from time remaining to zero using the in game speed setting.
    public void CountDown()
    {
        timeRemaining -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);


        timeRemainingText.text = minutes.ToString() +  ":" + seconds.ToString();

        if(timeRemaining <= 0)
        {
            isCountingDown = false;
            float minutes1 = Mathf.FloorToInt(timeRemaining / 60);
            float seconds2 = Mathf.FloorToInt(timeRemaining % 60);


            timeRemainingText.text = "Time up!";

            TimeRanOut();
        }
    }

    // Set turnmanager to abridged final turn when the time runs out.
    private void TimeRanOut()
    {
        turnManager.SetAbridgedFinalTurn();
    }

}
