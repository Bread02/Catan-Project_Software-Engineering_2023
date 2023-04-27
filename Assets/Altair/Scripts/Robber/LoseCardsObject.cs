using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script controls the losing cards object for when a robber is activated.
 * This is when the player must discard half of their cards if they have too many cards when 7 is rolled.
 *
 * @author Altair
 * @version 26/04/2023
 */
public class LoseCardsObject : MonoBehaviour
{

    [Header("Other Scripts")]
    private TurnManager turnManager;
    private WarningText warningText;

    [Header("Other")]
    public Material blackMat;
    public Material origMat;
    public GameObject loseCardsZone;

    // Finds the scripts in the scene needed for this script.
    private void FindScripts()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
    }

    // Start is called before the first frame update
    void Start()
    {
        FindScripts();
    }

    // cards will be lost when thrown on the trigger, and do NOTHING.
    private void OnTriggerEnter(Collider cardPlayed)
    {
        string cardType = cardPlayed.gameObject.tag;
      //  Debug.Log(cardType);


        // if dev card dropped, return out, throw warning.
        if (cardType == "knight" || cardType == "victoryPoints" || cardType == "monopoly" || cardType == "roadBuilding" || cardType == "yearOfPlenty") //development card played
        {
            StartCoroutine(warningText.WarningTextBox("Cannot discard development card. Discard resource cards instead."));
            return;
        }


        turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, -1, cardPlayed.gameObject);
        StartCoroutine(ChangeColour());


    }

    // changes the color of this game object.
    IEnumerator ChangeColour()
    {
        this.gameObject.GetComponent<Renderer>().material = blackMat;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<Renderer>().material = origMat;
    }

}