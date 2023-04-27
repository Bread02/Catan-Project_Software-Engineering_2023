using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script controls mechanic for the dice.
 * This is attached to each trigger collider child of the dice and is triggered if it touches
 * the game board
 *
 * @author Altair
 * @version 27/04/2023
 */
public class DiceTriggerDetection : MonoBehaviour
{
    public bool isTriggered;

    private void Start()
    {
        isTriggered = false;
    }

    // if staying on collider, then triggered.
    private void OnTriggerStay(Collider other)
    {
    //    Debug.Log("Triggered 2");
   //     Debug.Log(other.name);

        if (other.gameObject.tag == "GameBoard")
        {


            isTriggered = true;
        }
    }

}
