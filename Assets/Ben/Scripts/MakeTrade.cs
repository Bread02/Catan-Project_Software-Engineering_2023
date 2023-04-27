using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeTrade : MonoBehaviour
{
    [SerializeField] private GameObject tradeMang, submitTradeButt, bankMang, cancelPieceBuildBut;
    private HelpText helpText;

    private bool roadBought, settlementBought, cityBought;

    private bool isSetUpPhase;

    private int roadAndSettlementPlacedInSetUp;

    public TurnManager turnManager;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        helpText = GameObject.Find("HelpTextBox").GetComponent<HelpText>();

        roadBought = true;
        settlementBought = true;
        isSetUpPhase = true;
        roadAndSettlementPlacedInSetUp = 0;
    }

    public bool GetRoadBought() { return roadBought; }

    public void SetRoadBought(bool x)
    {
        tradeMang.SetActive(true);
        roadBought = x;
    }

    public bool GetSettlementBought() { return settlementBought; }

    public bool GetCityBought() { return cityBought; }

    public void SetCityBought(bool cityBoughtBool)
    {
        tradeMang.SetActive(true);
        cityBought = cityBoughtBool;
    }


    public void SetSettlementBought(bool x)
    {
        tradeMang.SetActive(true);
        settlementBought = x;
    }

    public void SetIsSetUpPhase(bool x)
    {
        isSetUpPhase = x;
    }

     void Update()
    {

        // DEBUG KEYS
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SetRoadBought(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetCityBought(true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetSettlementBought(true);
        }

    }

    public void BuyRoad()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("brick", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("lumber", -1);
        roadBought = true;
        tradeMang.SetActive(false); //removes trade GUI to make it easier to see board
        cancelPieceBuildBut.SetActive(true);
        Debug.Log("You bought a road!");
    }

    public void CancelPieceBuildButtonPressed()
    {
        //Add correct cards back to trade
        if (roadBought)
        {
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("brick", 1);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("lumber", 1);
        }
        else if (settlementBought)
        {
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("brick", 1);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("lumber", 1);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("wool", 1);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", 1);
        }
        else if (cityBought)
        {
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("ore", -3);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -2);
        }
        //For insurance, set all bools to false
        roadBought=false;
        settlementBought=false;
        cityBought=false;

        //Hide cancel button
        cancelPieceBuildBut.SetActive(false);

        tradeMang.SetActive(true);
    }

    public void HideCancelPieceBuildBut()
    {
        cancelPieceBuildBut.SetActive(false);
    }

    public void BuySettlement()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("brick", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("lumber", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("wool", -1);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -1);
        settlementBought = true;
        tradeMang.SetActive(false); //removes trade GUI to make it easier to see board
        cancelPieceBuildBut.SetActive(true);
        Debug.Log("You bought a settlement!");
    }

    public void BuyCity()
    {
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("ore", -3);
        tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -2);
        cityBought = true;
        tradeMang.SetActive(false); //removes trade GUI to make it easier to see board
        cancelPieceBuildBut.SetActive(true);
        helpText.HelpTextBox("Choose a settlement to build your city on");
        Debug.Log("You bought a city!");
    }

    public void BuyDevCard()
    {
        if(bankMang.GetComponent<BankManager>().GetDevCardQuant() <= 0)
        {
            Debug.Log("No development cards left in bank!");
        }
        else
        {
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("ore", -1);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("wool", -1);
            tradeMang.GetComponent<TradeManager>().IncOrDecValue("grain", -1);

            //must find new development card to take if there are no cards of devCardType left in bank
            string devCardType = "";

            do
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                int randNo = Random.Range(0, 5);
                Debug.Log("Random number is: " + randNo);

                switch (randNo)
                {
                    case 0: //knight card
                        devCardType = "knight";
                        break;

                    case 1: //monopoly card
                        devCardType = "monopoly";
                        break;

                    case 2: //roadBuilding card
                        devCardType = "roadBuilding";
                        break;

                    case 3: //yearOfPlenty card
                        devCardType = "yearOfPlenty";
                        break;

                    case 4: //victoryPoints card
                        devCardType = "victoryPoints";
                        break;
                }
            } while (bankMang.GetComponent<BankManager>().GetValue(devCardType) <= 0);
            Debug.Log("Development card type bought is: " + devCardType);

            bankMang.GetComponent<BankManager>().IncOrDecValue(devCardType, -1); //Do not need to use return value as we have already checked at least one dev card is in bank
            turnManager.ReturnCurrentPlayer().GetComponent<PlayerManager>().IncOrDecValue(devCardType, 1);
            submitTradeButt.SetActive(true);

            Debug.Log("You bought a development card!");
        }
    }
}
