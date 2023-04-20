using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DiceReader : MonoBehaviour
{

    //  private bool hitSurface = false;

    public DiceColor diceColor;

    public enum DiceColor
    {
        red,
        yellow
    }

    public Vector3 diceStartPosition;

    public DiceRolling diceRolling;

    // detectors are the opposite sides of their number.
    // it is the number of the top of the dice.
    [Header("Detectors")]
    [SerializeField] private GameObject OneDetector;
    [SerializeField] private GameObject TwoDetector;
    [SerializeField] private GameObject ThreeDetector;
    [SerializeField] private GameObject FourDetector;
    [SerializeField] private GameObject FiveDetector;
    [SerializeField] private GameObject SixDetector;

    public List<GameObject> detectorList = new List<GameObject>();

    bool rolled = false;
    bool finishRollingResult = false;

    [Header("Number")]
    private int diceNumber = 0;   
    [SerializeField] private Button rollDiceButton;

    public DiceReader otherDiceReader;


    // Start is called before the first frame update
    void Start()
    {
        diceStartPosition = this.gameObject.transform.position;
        finishRollingResult = false;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;


        detectorList.Add(OneDetector);
        detectorList.Add(TwoDetector);
        detectorList.Add(ThreeDetector);
        detectorList.Add(FourDetector);
        detectorList.Add(FiveDetector);
        detectorList.Add(SixDetector);

    }

    // resets dice ready to be reused for next turn
    public void ResetDicePosition()
    {
        this.gameObject.transform.position = diceStartPosition;
        rolled = false;
        finishRollingResult = false;
        diceNumber = 0;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;

        // reset all triggers
        foreach (GameObject detector in detectorList)
        {
            detector.GetComponent<DiceTriggerDetection>().isTriggered = false;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0 && rolled) 
        {
            CheckDiceNumber();
            finishRollingResult = true;
            switch (diceColor)
            {
                case DiceColor.red:
                    diceRolling.DiceRollTrigger(true);
                    break;
                case DiceColor.yellow:
                    diceRolling.DiceRollTrigger(false);
                    break;
            }
            RollResult();

        }
        else
        {
            if(!rolled)
            SpinDice();
        }
    }

    public void RollDice()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;

        // wait a very small time for object to start moving.
        Invoke("InvokeRolled", 0.5f);
    }

    public void InvokeRolled()
    {
        rolled = true;
    }


    void CheckDiceNumber()
    {

        if(OneDetector.GetComponent<DiceTriggerDetection>().isTriggered == true)
        {
            diceNumber = 1;
            return;
        }
        if (TwoDetector.GetComponent<DiceTriggerDetection>().isTriggered == true)
        {
            diceNumber = 2;
            return;

        }
        if (ThreeDetector.GetComponent<DiceTriggerDetection>().isTriggered == true)
        {
            diceNumber = 3;
            return;

        }
        if (FourDetector.GetComponent<DiceTriggerDetection>().isTriggered == true)
        {
            diceNumber = 4;
            return;

        }
        if (FiveDetector.GetComponent<DiceTriggerDetection>().isTriggered == true)
        {
            diceNumber = 5;
            return;

        }
        if (SixDetector.GetComponent<DiceTriggerDetection>().isTriggered == true)
        {
            diceNumber = 6;
            return;

        }

        diceNumber = 0;
        return;

    }


    // after the dice rolling is complete, check what the number is then trigger actions.
    // if roll = 7, trigger robber.
    public int RollResult()
    {
        return diceNumber;
    }

    void SpinDice()
    {
     //   this.transform.Rotate(9, 19, 4);
        transform.rotation = Random.rotation;
    }


}
