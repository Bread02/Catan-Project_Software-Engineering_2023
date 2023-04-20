using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDropZone : MonoBehaviour
{
    public int playerNumThatOwnsThisDropZone;

    private TurnManager turnManager;

    [SerializeField] private DomesticTradeOnlyManager domesTradeParentObj;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    private void OnTriggerEnter(Collider cardPlayed)
    {
        string cardType = cardPlayed.tag;
        if(playerNumThatOwnsThisDropZone == turnManager.ReturnCurrentPlayer().playerNumber)
        {
            Debug.Log("You silly goose! You're trying to trade with yourself!");
            turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, -1, cardPlayed.gameObject);
            turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, 1);
        }
        else
        {
            domesTradeParentObj.DomesticTrade(turnManager.ReturnCurrentPlayer().playerNumber, playerNumThatOwnsThisDropZone);
            turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, -1, cardPlayed.gameObject);
            Debug.Log("Removed " + cardType + "card from player " + turnManager.ReturnCurrentPlayer().playerNumber + "'s hand.");
            turnManager.playerList[playerNumThatOwnsThisDropZone - 1].IncOrDecValue(cardPlayed.tag, 1);
            Debug.Log("Added " + cardType + "card to player " + playerNumThatOwnsThisDropZone + "'s hand.");
        }
    }
}
