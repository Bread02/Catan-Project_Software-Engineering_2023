using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AbridgedMode : MonoBehaviour
{

    [Header("UI")]
    public TextMeshProUGUI timeRemainingText;
    public GameObject abridgedUI;

    public bool isAbridgedMode;

    public float timeRemaining;

    public bool isCountingDown;

    // Start is called before the first frame update
    void Awake()
    {
        abridgedUI.SetActive(false);

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
    }

    public void CountDown()
    {
        timeRemaining -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);


        timeRemainingText.text = minutes.ToString() +  ":" + seconds.ToString();
    }


}
