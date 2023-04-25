using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonateCardsObject : MonoBehaviour
{
    private TurnManager turnManager;
    private WarningText warningText;
    private StealCards stealCards;

    public Material blackMat;

   // public GameObject loseCardsZone;

    private PlayerManager playerDonatingTo;

    private void FindScripts()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        stealCards = GameObject.Find("StealCards").GetComponent<StealCards>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
    }

    // Start is called before the first frame update
    void Start()
    {
        FindScripts();
    }

    public void SetPlayerDonatingTo(PlayerManager setPlayerDonatingTo)
    {
        playerDonatingTo = setPlayerDonatingTo;
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

        // decrease value of current player.
        turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, -1, cardPlayed.gameObject);

        // increase value of other player donating to.
        playerDonatingTo.IncOrDecValue(cardType, +1, cardPlayed.gameObject);

        // one donated, trigger turn manager to go back to player who played robber.
        stealCards.FinishTheft(true);

        StartCoroutine(ChangeColour());
    }


    IEnumerator ChangeColour()
    {
        this.gameObject.GetComponent<Renderer>().material = blackMat;
        yield return new WaitForSeconds(0.2f);
    }
}
