using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DomesticTradeOnlyManager : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;

    [SerializeField] private TMP_Text tradeInitiateText, tradeReceiverText;

    private int tradeInitiatePlayerNum, tradeReceiverPlayerNum, sumOfCardsFromInitiate, sumOfCardsFromReceiver;

    private bool hasTradeInitiateGivenAllTheirCards, hasTradeInitiateGivenFirstCard;

    [SerializeField] private GameObject finishedGivingCardsButton, bankGraphicObject, endTurnButton;

    private void Update()
    {
        if (!hasTradeInitiateGivenAllTheirCards && sumOfCardsFromInitiate > 0)
        {
            finishedGivingCardsButton.SetActive(true);
        }
        else if(hasTradeInitiateGivenAllTheirCards && sumOfCardsFromReceiver > 0)
        {
            finishedGivingCardsButton.SetActive(true);
        }
        else
        {
            finishedGivingCardsButton.SetActive(false);
        }
    }

    public void DomesticTrade(int tradeInitiateNum, int tradeReceiverNum)
    {
        Debug.Log("Trade initiate: " + tradeInitiateNum);
        Debug.Log("Trade receiver: " + tradeReceiverNum);
        if (!hasTradeInitiateGivenFirstCard)
        {
            turnManager.isTrading = true;
            bankGraphicObject.SetActive(false);

            //Removes player dropzones for the players that aren't part of this current domestic trade
            for(int i = 1; i <= turnManager.playerDropZones.Count; i++)
            {
                if (i != tradeInitiateNum && i != tradeReceiverNum)
                {
                    turnManager.playerDropZones[i-1].SetActive(false);
                }
            }

            tradeInitiateText.text = "Player " + tradeInitiateNum.ToString();
            tradeReceiverText.text = "Player " + tradeReceiverNum.ToString();
            tradeInitiatePlayerNum = tradeInitiateNum;
            tradeReceiverPlayerNum = tradeReceiverNum;
            hasTradeInitiateGivenFirstCard = true;
        }

        if (!hasTradeInitiateGivenAllTheirCards)
        {
            //The trade initiate is still giving cards to trade receiver
            sumOfCardsFromInitiate++;
        }
        else
        {
            //It is now the trade receiver that is giving cards to the trade initiate
            sumOfCardsFromReceiver++;
        }
        this.gameObject.SetActive(true);
        hasTradeInitiateGivenAllTheirCards = false;
    }

    public void FinishedTradingCardsButtonPressed()
    {
        Debug.Log("Finished domestic trade button pressed!");
        if (!hasTradeInitiateGivenAllTheirCards)
        {
            Debug.Log("Trade initiate has given at least one card!");
            //The trade receiver still needs to give their cards to the trade initiate
            hasTradeInitiateGivenAllTheirCards = true;
            turnManager.ForcePlayerTurn(turnManager.playerList[tradeReceiverPlayerNum - 1]);
        }
        else
        {
            Debug.Log("Trade initiate AND Trade Receiver have given at least one card!");
            //Trade initiate and trade receiver have both given their cards. Therefore go back to the trade initiate's turn
            turnManager.ForcePlayerTurn(turnManager.playerList[tradeInitiatePlayerNum - 1]);

            hasTradeInitiateGivenFirstCard = false;
            hasTradeInitiateGivenAllTheirCards = false;
            sumOfCardsFromInitiate = 0;
            sumOfCardsFromReceiver = 0;
            bankGraphicObject.SetActive(true);

            foreach(GameObject playerDropZone in turnManager.playerDropZones)
            {
                playerDropZone.SetActive(true);
            }

            this.gameObject.SetActive(false);

            turnManager.isTrading = false;

            endTurnButton.SetActive(true);
        }
    }
}
