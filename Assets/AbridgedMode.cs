using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AbridgedMode : MonoBehaviour
{
    private TurnManager turnManager;

    [Header("UI")]
    public TextMeshProUGUI timeRemainingText;
    public GameObject abridgedUI;

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
        if(Input.GetKeyDown(KeyCode.V))
        {
            SetupAbridged(180);
        }
        // count down if abridged mode
        if(isCountingDown)
        {
            CountDown();
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            timeRemaining = 3;
        }
    }

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

    // time run out
    private void TimeRanOut()
    {
        turnManager.SetAbridgedFinalTurn();
    }

}
