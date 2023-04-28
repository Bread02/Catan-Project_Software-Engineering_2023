using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeManager : MonoBehaviour
{
    [Header("Ints")]
    private int pointer; //point to next Text object to use when a different resource card is traded
    private int sum = 0;

    [Header("Other Scripts")]
    private TurnManager turnManager;
    private HelpText helpText;


    [Header("Dictionaries")]
    private Dictionary<string, TMP_Text> cardTxtDict;
    private Dictionary<string, int> cardAmountsDict, totalTradedDict;

    [Header("Game Objects")]
    [SerializeField] private GameObject bankMang, gameBoardMang, dropDownMenu, buyRoadBut, buySettBut, buyCityBut, buyDevCBut,
        unusedCardsBut, submitTradeBut, buyRCwGrainBut, buyRCwWoolBut, buyRCwBrickBut, buyRCwOreBut, buyRCwLumberBut, chooseRCpanel, endTurnButton;

    public GameObject tradeBG;

    [Header("Texts")]
    [SerializeField] private TMP_Text[] cardTxtObjs;
    [SerializeField] private TMP_Text rcTypeToGiveToBankInMTtxt;

    [Header("Bools")]
    public bool inTradeMode;
    public bool inStartMode;

    private void Awake()
    {
        tradeBG.SetActive(false);
        FindScripts();
        cardTxtDict = new Dictionary<string, TMP_Text>();
        cardAmountsDict = new Dictionary<string, int>();
        totalTradedDict = new Dictionary<string, int>();
        pointer = 0;
        inTradeMode = true;
    }

    // Finds the scripts required for this class.
    void FindScripts()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        helpText = GameObject.Find("HelpTextBox").GetComponent<HelpText>();
    }

    private void Update()
    {
        //If player has more than 1 card unused in the trade window, they can return that card to their hand
        if(sum > 0)
        {
            unusedCardsBut.SetActive(true);
        }
        else
        {
            unusedCardsBut.SetActive(false);
        }

        //Maritime trade buttons
        if (cardAmountsDict.ContainsKey("grain"))
        {
            if (turnManager.ReturnCurrentPlayer().ownsGrainHarbor && cardAmountsDict["grain"] >= 2)
            {
                //Player owns the brick harbor. Therefore only 2 brick cards a required to make a trade
                buyRCwGrainBut.SetActive(true);
            }
            else if (turnManager.ReturnCurrentPlayer().ownsImprovedHarbor && cardAmountsDict["grain"] >= 3)
            {
                //Player owns the 3:1 harbor, which i have called 'the improved harbor'.
                buyRCwGrainBut.SetActive(true);
            }
            else if (cardAmountsDict["grain"] >= 4)
            {
                //Player needs to trade 4 brick cards for any 1 resource card
                buyRCwGrainBut.SetActive(true);
            }
            else
            {
                //Player does not meet any requirements to compelte a maritime trade using brick cards
                buyRCwGrainBut.SetActive(false);
            }
        }

        if (cardAmountsDict.ContainsKey("wool"))
        {
            if (turnManager.ReturnCurrentPlayer().ownsWoolHarbor && cardAmountsDict["wool"] >= 2)
            {
                //Player owns the brick harbor. Therefore only 2 brick cards a required to make a trade
                buyRCwWoolBut.SetActive(true);
            }
            else if (turnManager.ReturnCurrentPlayer().ownsImprovedHarbor && cardAmountsDict["wool"] >= 3)
            {
                //Player owns the 3:1 harbor, which i have called 'the improved harbor'.
                buyRCwWoolBut.SetActive(true);
            }
            else if (cardAmountsDict["wool"] >= 4)
            {
                //Player needs to trade 4 brick cards for any 1 resource card
                buyRCwWoolBut.SetActive(true);
            }
            else
            {
                //Player does not meet any requirements to compelte a maritime trade using brick cards
                buyRCwWoolBut.SetActive(false);
            }
        }

        if (cardAmountsDict.ContainsKey("brick"))
        {
            if (turnManager.ReturnCurrentPlayer().ownsBrickHarbor && cardAmountsDict["brick"] >= 2)
            {
                //Player owns the brick harbor. Therefore only 2 brick cards a required to make a trade
                buyRCwBrickBut.SetActive(true);
            }
            else if (turnManager.ReturnCurrentPlayer().ownsImprovedHarbor && cardAmountsDict["brick"] >= 3)
            {
                //Player owns the 3:1 harbor, which i have called 'the improved harbor'.
                buyRCwBrickBut.SetActive(true);
            }
            else if (cardAmountsDict["brick"] >= 4)
            {
                //Player needs to trade 4 brick cards for any 1 resource card
                buyRCwBrickBut.SetActive(true);
            }
            else
            {
                //Player does not meet any requirements to compelte a maritime trade using brick cards
                buyRCwBrickBut.SetActive(false);
            }
        }

        if (cardAmountsDict.ContainsKey("ore"))
        {
            if (turnManager.ReturnCurrentPlayer().ownsOreHarbor && cardAmountsDict["ore"] >= 2)
            {
                //Player owns the brick harbor. Therefore only 2 brick cards a required to make a trade
                buyRCwOreBut.SetActive(true);
            }
            else if (turnManager.ReturnCurrentPlayer().ownsImprovedHarbor && cardAmountsDict["ore"] >= 3)
            {
                //Player owns the 3:1 harbor, which i have called 'the improved harbor'.
                buyRCwOreBut.SetActive(true);
            }
            else if (cardAmountsDict["ore"] >= 4)
            {
                //Player needs to trade 4 brick cards for any 1 resource card
                buyRCwOreBut.SetActive(true);
            }
            else
            {
                //Player does not meet any requirements to compelte a maritime trade using brick cards
                buyRCwOreBut.SetActive(false);
            }
        }

        if (cardAmountsDict.ContainsKey("lumber"))
        {
            if (turnManager.ReturnCurrentPlayer().ownsOreHarbor && cardAmountsDict["lumber"] >= 2)
            {
                //Player owns the brick harbor. Therefore only 2 brick cards a required to make a trade
                buyRCwLumberBut.SetActive(true);
            }
            else if (turnManager.ReturnCurrentPlayer().ownsImprovedHarbor && cardAmountsDict["lumber"] >= 3)
            {
                //Player owns the 3:1 harbor, which i have called 'the improved harbor'.
                buyRCwLumberBut.SetActive(true);
            }
            else if (cardAmountsDict["lumber"] >= 4)
            {
                //Player needs to trade 4 brick cards for any 1 resource card
                buyRCwLumberBut.SetActive(true);
            }
            else
            {
                //Player does not meet any requirements to compelte a maritime trade using brick cards
                buyRCwLumberBut.SetActive(false);
            }
        }

        //Build asset buttons
        if (cardAmountsDict.ContainsKey("brick") && cardAmountsDict.ContainsKey("lumber"))
        {
            if (cardAmountsDict["brick"] >= 1 && cardAmountsDict["lumber"] >= 1)
            {
                //Requirements for building a road are met
                buyRoadBut.SetActive(true);
                if (cardAmountsDict.ContainsKey("wool") && cardAmountsDict.ContainsKey("grain"))
                {
                    if (cardAmountsDict["wool"] >= 1 && cardAmountsDict["grain"] >= 1)
                    {
                        //Requirements for building a settlement are met
                        buySettBut.SetActive(true);
                    }
                    else
                    {
                        //Requirements for building a settlement are NOT met
                        buySettBut.SetActive(false);
                    }
                }
            }
            else
            {
                //Requirements for building a road and for buying a settlement are NOT met
                buyRoadBut.SetActive(false);
                buySettBut.SetActive(false);
            }
        }

        if (cardAmountsDict.ContainsKey("ore") && cardAmountsDict.ContainsKey("grain"))
        {
            if (cardAmountsDict["ore"] >= 3 && cardAmountsDict["grain"] >= 2)
            {
                //Requirements for building a city are met
                buyCityBut.SetActive(true);
            }
            else
            {
                buyCityBut.SetActive(false);
            }
            if (cardAmountsDict.ContainsKey("wool"))
            {
                if (cardAmountsDict["ore"] >= 1 && cardAmountsDict["wool"] >= 1 && cardAmountsDict["grain"] >= 1)
                {
                    //Requirements for building a development card are met
                    buyDevCBut.SetActive(true);
                }
                else
                {
                    //Requirements for building a development card are NOT met
                    buyDevCBut.SetActive(false);
                }
            }
        }
    }





    public void ReturnUnusedCardsButtonPressed()
    {
        foreach (KeyValuePair<string, int> cards in cardAmountsDict)
        {
            turnManager.ReturnCurrentPlayer().IncOrDecValue(cards.Key, cards.Value, null);
            totalTradedDict[cards.Key] -= cards.Value;
        }
        foreach (KeyValuePair<string, int> cards in totalTradedDict)
        {
            bankMang.GetComponent<BankManager>().IncOrDecValue(cards.Key, cards.Value); //No need to worry about return value as we are adding cards back to the bank
        }

        ResetVariables();
        endTurnButton.SetActive(true);
    }

    /*
     * Sends all cards that were put in the trade window to the bank
     */
    public void SubmitTrade()
    {
        helpText.SetHelpTextBoxOff();
        Debug.Log("Submitting trade");

        if (sum > 0)
        {
            Debug.Log("ERROR: You still have cards to trade!");
        }
        else
        {
            foreach (KeyValuePair<string, int> cards in totalTradedDict)
            {
                bankMang.GetComponent<BankManager>().IncOrDecValue(cards.Key, cards.Value); //No need to worry about return value as we are adding cards to bank
            }
            ResetVariables();
            endTurnButton.SetActive(true);
        }

    }

    private void ResetVariables()
    {
        pointer = 0;
        sum = 0;
        foreach (TMP_Text cardTxt in cardTxtDict.Values)
        {
            cardTxt.text = "NULL";
            cardTxt.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
        dropDownMenu.SetActive(true);
        cardTxtDict.Clear();
        cardAmountsDict.Clear();
        totalTradedDict.Clear();
        bankMang.GetComponent<BankManager>().SetTradeStarted(false);

        buyRoadBut.SetActive(false);
        buySettBut.SetActive(false);
        buyCityBut.SetActive(false);
        buyDevCBut.SetActive(false);
        submitTradeBut.SetActive(false);
        chooseRCpanel.SetActive(false);

        foreach (GameObject playerDropZone in turnManager.playerDropZones)
        {
            playerDropZone.SetActive(true);
        }

        inTradeMode = false;
        turnManager.isTrading = false;
        Debug.Log("Trade Manager variables reset!");
    }

    

    public void CardAddedToTrade(GameObject card)
    {
        submitTradeBut.SetActive(true);

        //Ensure all player drop zones are NOT active
        foreach (GameObject playerDropZone in turnManager.playerDropZones)
        {
            playerDropZone.SetActive(false);
        }

        inTradeMode = true;
        turnManager.isTrading = true;
        dropDownMenu.SetActive(false);
        this.gameObject.SetActive(true);
        if (cardTxtDict.ContainsKey(card.tag))
        {
            CurrentResourceTraded(card.tag);
        }
        else
        {
            DifferentResourceTraded(card.tag);
        }

        sum += 1;

    }

    public void CurrentResourceTraded(string key)
    {
        cardAmountsDict[key] += 1;
        totalTradedDict[key] += 1;

        cardTxtDict[key].text = string.Format("{0}: {1}", key, cardAmountsDict[key]);
    }

    public void DifferentResourceTraded(string key)
    {
        tradeBG.SetActive(true);
        cardTxtObjs[pointer].text = string.Format("{0}: {1}", key, 1);
        cardTxtObjs[pointer].gameObject.SetActive(true);

        cardTxtDict.Add(key, cardTxtObjs[pointer]);
        cardAmountsDict.Add(key, 1);
        totalTradedDict.Add(key, 1);

        pointer++;
    }

    public void IncOrDecValue(string key, int value)
    {
        sum += value;

        if (value >= 0)
        {
            totalTradedDict[key] += value;
        }
        cardAmountsDict[key] += value;
        cardTxtDict[key].text = key + ": " + cardAmountsDict[key].ToString();
    }

    //***Called by buttons***
    public void BuyRCwithGrainButtonPressed()
    {
        ShowMaritimeTradePanel("grain");
    }

    public void BuyRCwithWoolButtonPressed()
    {
        ShowMaritimeTradePanel("wool");
    }

    public void BuyRCwithBrickButtonPressed()
    {
        ShowMaritimeTradePanel("brick");
    }

    public void BuyRCwithOreButtonPressed()
    {
        ShowMaritimeTradePanel("ore");
    }

    public void BuyRCwithLumberButtonPressed()
    {
        ShowMaritimeTradePanel("lumber");
    }
    //*******//

    private string rcTypeToGiveToBank;

    public void ShowMaritimeTradePanel(string rcTypeToGiveToBank)
    {
        if(bankMang.GetComponent<BankManager>().GetResCardQuant() <= 0)
        {
            Debug.Log("Cannot perform maritime trade as there are no cards left in the bank!");
        }
        else
        {
            this.rcTypeToGiveToBank = rcTypeToGiveToBank;
            this.gameObject.SetActive(false);
            chooseRCpanel.SetActive(true);
            rcTypeToGiveToBankInMTtxt.text = rcTypeToGiveToBank;
        }
    }

    //***Called by buttons***
    public void GetGrainCardThroughMTButtonPressed()
    {
        GetResourceCardThroughtMT("grain");
    }

    public void GetWoolCardThroughMTButtonPressed()
    {
        GetResourceCardThroughtMT("wool");
    }

    public void GetBrickCardThroughMTButtonPressed()
    {
        GetResourceCardThroughtMT("brick");
    }

    public void GetOreCardThroughMTButtonPressed()
    {
        GetResourceCardThroughtMT("ore");
    }

    public void GetLumberCardThroughMTButtonPressed()
    {
        GetResourceCardThroughtMT("lumber");
    }
    //*******//

    public void GetResourceCardThroughtMT(string rcTypeToGetFromBank)
    {
        if(bankMang.GetComponent<BankManager>().GetValue(rcTypeToGetFromBank) <= 0)
        {
            Debug.Log("No " + rcTypeToGetFromBank + " left in the bank!");
        }
        else
        {
            bool ownsBestHarbor = false;
            //Remove cards from trade window
            switch (rcTypeToGetFromBank)
            {
                case "grain":
                    ownsBestHarbor = turnManager.ReturnCurrentPlayer().ownsGrainHarbor;
                    break;
                case "wool":
                    ownsBestHarbor = turnManager.ReturnCurrentPlayer().ownsWoolHarbor;
                    break;
                case "ore":
                    ownsBestHarbor = turnManager.ReturnCurrentPlayer().ownsOreHarbor;
                    break;
                case "brick":
                    ownsBestHarbor = turnManager.ReturnCurrentPlayer().ownsBrickHarbor;
                    break;
                case "lumber":
                    ownsBestHarbor = turnManager.ReturnCurrentPlayer().ownsLumberHarbor;
                    break;
            }

            int amntRequiredFromPlr;
            if (ownsBestHarbor)
            {
                Debug.Log("Current player owns the best harbour for " + rcTypeToGiveToBank);
                amntRequiredFromPlr = 2;
            }
            else if (turnManager.ReturnCurrentPlayer().ownsImprovedHarbor)
            {
                Debug.Log("Current player owns the 3:1 harbour");
                amntRequiredFromPlr = 3;
            }
            else
            {
                Debug.Log("Current player must give 4 cards for the maritime trade");
                amntRequiredFromPlr = 4;
            }

            //Take resource card the player wants from the bank, and add to player's hand
            IncOrDecValue(rcTypeToGiveToBank, -amntRequiredFromPlr);
            bankMang.GetComponent<BankManager>().IncOrDecValue(rcTypeToGetFromBank, -1); //No need to worry about return value as we have already checked quantity of bank
            turnManager.ReturnCurrentPlayer().IncOrDecValue(rcTypeToGetFromBank, 1);

            buyRCwBrickBut.SetActive(false);
            buyRCwGrainBut.SetActive(false);
            buyRCwLumberBut.SetActive(false);
            buyRCwOreBut.SetActive(false);
            buyRCwWoolBut.SetActive(false);

            chooseRCpanel.SetActive(false);
            this.gameObject.SetActive(true);

            turnManager.isTrading = false;
        }
    }
}
