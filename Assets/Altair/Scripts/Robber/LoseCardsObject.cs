using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCardsObject : MonoBehaviour
{
    private TurnManager turnManager;
    private WarningText warningText;
    public Material blackMat;

    public GameObject loseCardsZone;

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

    
    IEnumerator ChangeColour()
    {
        this.gameObject.GetComponent<Renderer>().material = blackMat;
        yield return new WaitForSeconds(0.2f);
    }
    
}