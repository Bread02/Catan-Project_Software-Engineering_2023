using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrade : MonoBehaviour
{
    [SerializeField] private GameObject tradeMang, submitTradeButt, playerMang, bankMang;

    private bool roadBought, settlementBought, cityBought;

    public TurnManager turnManager;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        roadBought = true;
        settlementBought = true;

    }

    public bool GetRoadBought() { return roadBought; }

    /*
     * Will only ever set boolean variable to false - used so that other settlement renderers are disabled in the display.
     */
    public void SetRoadBought(bool x)
    {
        submitTradeButt.SetActive(true);
        tradeMang.SetActive(true);
        roadBought = x;
    }

    public bool GetSettlementBought() { return settlementBought; }

    /*
     * Will only ever set boolean variable to false - used so that other settlement renderers are disabled in the display.
     */
    public void SetSettlementBought(bool x)
    {
        submitTradeButt.SetActive(true);
        tradeMang.SetActive(true);
        settlementBought = x;
    }

    public void BuyRoad()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("brick", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("lumber", -1);
        roadBought = true;
        tradeMang.SetActive(false); //removes trade GUI to make it easier to see board
        Debug.Log("You bought a road!");
    }

    public void BuySettlement()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("brick", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("lumber", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("wool", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -1);
        settlementBought = true;
        tradeMang.SetActive(false); //removes trade GUI to make it easier to see board
        Debug.Log("You bought a settlement!");
       
    }

    public void BuyCity()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("ore", -3);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -2);
        cityBought = true;
        tradeMang.SetActive(false); //removes trade GUI to make it easier to see board
     //   turnManager.
        Debug.Log("You bought a city!");
    }

    public void BuyDevCard()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("ore", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("wool", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -1);


        //must find new development card to take if there are no cards of cardType left in bank
        string cardType = "";
        do
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            int randNo = Random.Range(0, 5);
            Debug.Log("Random number is: " + randNo);

            switch (randNo)
            {
                case 0: //knight card
                    cardType = "knight";
                    break;

                case 1: //monopoly card
                    cardType = "monopoly";
                    break;

                case 2: //roadBuilding card
                    cardType = "roadBuilding";
                    break;

                case 3: //yearOfPlenty card
                    cardType = "yearOfPlenty";
                    break;

                case 4: //victoryPoints card
                    cardType = "victoryPoints";
                    break;
            }
        } while (bankMang.GetComponent<BankManager>().GetValue(cardType) <= 0);

        bankMang.GetComponent<BankManager>().IncOrDecValue(cardType, -1);
        playerMang.GetComponent<PlayerManager>().IncOrDecValue(cardType, 1);
        submitTradeButt.SetActive(true);

        Debug.Log("You bought a development card!");
    }

    public void BuyGrainCard()
    {
        Debug.Log("You bought a grain card!");
    }

    public void BuyWoolCard()
    {
        Debug.Log("You bought a wool card!");
    }

    public void BuyBrickCard()
    {
        Debug.Log("You bought a brick card!");
    }

    public void BuyOreCard()
    {
        Debug.Log("You bought a ore card!");
    }

    public void BuyLumberCard()
    {
        Debug.Log("You bought a lumber card!");
    }
}
