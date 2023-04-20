using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTriggerDetection : MonoBehaviour
{
    public bool isTriggered;

    private void Start()
    {
        isTriggered = false;
    }

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
