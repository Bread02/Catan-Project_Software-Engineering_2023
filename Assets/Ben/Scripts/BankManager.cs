using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;
    private Robber robber;
    [SerializeField] private MakeTrade makeTrade;

    [Header("Game Objects")]
    [SerializeField] private GameObject bankGuiTxt;
    [SerializeField] private GameObject tradeGUImang;
    [SerializeField] private GameObject endTurnButton;

    [Header("Materials")]
    [SerializeField] private Material whiteMat, blackMat;

    [Header("Others")]
    private Dictionary<string, int> bank;
    private bool tradeStarted;

    // Start is called before the first frame update
    void Start()
    {
        FindScripts();

        tradeStarted = false;

        bank = new Dictionary<string, int>
        {
            {"grain", 19 },
            {"wool", 19 },
            {"brick", 19 },
            {"ore", 19 },
            {"lumber", 19 },
            {"knight", 14 },
            {"victoryPoints", 5 },
            {"monopoly", 2 },
            {"roadBuilding", 2 },
            {"yearOfPlenty", 2 }
        };
    }

    private void FindScripts()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        robber = GameObject.Find("Robber").GetComponent<Robber>();
    }

    public int GetValue(string key)
    {
        return bank[key];
    }

    public bool IncOrDecValue(string key, int value)
    {
        bool cardsTaken = true;
        bank[key] += value;
        if (bank[key] < 0)
        {
            bank[key] = 0;
            cardsTaken = false;
        }
        if (key == "knight" || key == "victoryPoints" || key == "monopoly" || key == "roadBuilding" || key == "yearOfPlenty")
        {
            bankGuiTxt.GetComponent<DisplayBankQuantities>().ChangeQuantity("development", GetDevCardQuant());
        }
        else
        {
            bankGuiTxt.GetComponent<DisplayBankQuantities>().ChangeQuantity(key, bank[key]);
        }
        return cardsTaken;
    }

    public int GetResCardQuant()
    {
        return bank["grain"] + bank["wool"] + bank["ore"] + bank["brick"] + bank["lumber"];
    }

    public int GetDevCardQuant()
    {
        return bank["knight"] + bank["victoryPoints"] + bank["monopoly"] + bank["roadBuilding"] + bank["yearOfPlenty"];
    }

    public void SetTradeStarted(bool x)
    {
        tradeStarted = x;
    }

    public bool GetTradeStarted()
    {
        return tradeStarted;
    }

    [SerializeField] private KnightCardsPlayedMainManager kcMangTextScript;

    private void OnTriggerEnter(Collider cardPlayed)
    {
        string cardType = cardPlayed.gameObject.tag;
        Debug.Log(cardType);
        turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, -1, cardPlayed.gameObject);

        StartCoroutine(ChangeColour());

        if (cardType == "knight" || cardType == "victoryPoints" || cardType == "monopoly" || cardType == "roadBuilding" || cardType == "yearOfPlenty") //development card played
        {
            if (tradeStarted) //cannot play development cards while trading!
            {
                turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, 1);
            }
            else
            {
                endTurnButton.SetActive(false);
                switch (cardType)
                {
                    case "knight":
                        // activate robber
                        turnManager.playerWhoRolledSeven = turnManager.ReturnCurrentPlayer(); //knight card simulates rolling a 7
                        robber.TriggerRobberMovement();
                        turnManager.ReturnCurrentPlayer().IncrementKnightCardUsage();
                        turnManager.hasUsedDevCardThisTurn = true;
                        kcMangTextScript.IncrementKCPAmountToPlayer(turnManager.ReturnCurrentPlayer().playerNumber);
                        break;
                    case "roadBuilding":
                        // NEEDS IMPLEMENTING
                        // BUYS 2 ROADS FOR THE PLAYER TO BUILD ON THE MAP.
                        StartCoroutine(RoadBuildingDevCardPlayed());
                        turnManager.hasUsedDevCardThisTurn = true;
                        break;
                    case "yearOfPlenty":
                        // NEEDS IMPLEMENTING
                        // ALLOWS THE PLAYER TO TAKE ANY 2 RESOURCE CARDS FROM THE BANK
                        if(GetResCardQuant() >= 2)
                        {
                            StartCoroutine(YearOfPlentyDevCardPlayed());
                            turnManager.hasUsedDevCardThisTurn = true;
                        }
                        else
                        {
                            Debug.Log("Not enough cards in bank to activate year of plenty! Returning card to player hand.");
                            turnManager.ReturnCurrentPlayer().IncOrDecValue("yearOfPlenty", 1);
                        }
                        break;
                    case "monopoly":
                        // NEEDS IMPLEMENTING
                        // All players must give all of the resource cards the player asks for. e.g. ore, all players give all their ore cards.
                        // If player does not have ore card, they do not give anything.
                        MonopolyDevCardPlayed();
                        turnManager.hasUsedDevCardThisTurn = true;
                        break;
                }
            }
            //Will reset back to showing resource cards only - players don't want to reveal their development cards to other players!
            turnManager.ReturnCurrentPlayer().ShowResourceCardsOnly();

        }
        else //resource card played
        {
            endTurnButton.SetActive(false);
            tradeGUImang.GetComponent<TradeManager>().CardAddedToTrade(cardPlayed.gameObject);
            tradeStarted = true;
        }
    }

    IEnumerator ChangeColour()
    {
        this.gameObject.GetComponent<Renderer>().material = blackMat;

        yield return new WaitForSeconds(0.2f);

        this.gameObject.GetComponent<Renderer>().material = whiteMat;
    }

    public bool firstRoadPlacedInRB, secondRoadPlacedInRB;

    IEnumerator RoadBuildingDevCardPlayed()
    {
        firstRoadPlacedInRB = false;
        secondRoadPlacedInRB = false;
        makeTrade.SetRoadBought(true);
        yield return new WaitUntil(() => firstRoadPlacedInRB);
        makeTrade.SetRoadBought(true);
        yield return new WaitUntil(() => secondRoadPlacedInRB);
    }

    [SerializeField] private GameObject monopolyPanel;

    //**Methods for Monopoly Development Card**
    public void MonopolyDevCardPlayed()
    {
        monopolyPanel.SetActive(true);
    }

    public void StealGrainButtonPressed()
    {
        StealResourceCardFromPlayers("grain");
    }

    public void StealWoolButtonPressed()
    {
        StealResourceCardFromPlayers("wool");
    }

    public void StealBrickButtonPressed()
    {
        StealResourceCardFromPlayers("brick");
    }

    public void StealOreButtonPressed()
    {
        StealResourceCardFromPlayers("ore");
    }

    public void StealLumberButtonPressed()
    {
        StealResourceCardFromPlayers("lumber");
    }

    private void StealResourceCardFromPlayers(string rcType)
    {
        monopolyPanel.SetActive(false);
        foreach (PlayerManager player in turnManager.playerList)
        {
            if (player.playerNumber != turnManager.ReturnCurrentPlayer().playerNumber && player.GetCardTypeQuantity(rcType) > 0)
            {
                //Is NOT the player whose turn it currently is (i.e. the player who player the monopoly card)
                //Then remove card from opponent's hand and add to hand of player who played monopoly card

                //TODO: Check if opponent actually holds resource card that will be stolen!
                while(player.GetCardTypeQuantity(rcType) > 0)
                {
                    player.IncOrDecValue(rcType, -1);
                    turnManager.ReturnCurrentPlayer().IncOrDecValue(rcType, 1);
                }
            }
        }
    }
    //********//

    [SerializeField] private GameObject yearOfPlentyPanel;
    public bool firstRCchosenFromYOP, secondRCchosenFromYOP;

    public IEnumerator YearOfPlentyDevCardPlayed()
    {
        yearOfPlentyPanel.SetActive(true);
        firstRCchosenFromYOP = false;
        secondRCchosenFromYOP = false;
        yield return new WaitUntil(() => firstRCchosenFromYOP);
        yield return new WaitUntil(() => secondRCchosenFromYOP);
        yearOfPlentyPanel.SetActive(false);
    }

    public void GetGrainCardThroughYOPButtonPressed()
    {
        ResourceCardGainedFromYOP("grain");
    }

    public void GetWoolCardThroughYOPButtonPressed()
    {
        ResourceCardGainedFromYOP("wool");
    }

    public void GetBrickCardThroughYOPButtonPressed()
    {
        ResourceCardGainedFromYOP("brick");
    }

    public void GetOreCardThroughYOPButtonPressed()
    {
        ResourceCardGainedFromYOP("ore");
    }

    public void GetLumberCardThroughYOPButtonPressed()
    {
        ResourceCardGainedFromYOP("lumber");
    }

    private void ResourceCardGainedFromYOP(string rcType)
    {
        if (!IncOrDecValue(rcType, -1))
        {
            Debug.Log("No " + rcType + " cards left in bank.");
        }
        else
        {
            turnManager.ReturnCurrentPlayer().IncOrDecValue(rcType, 1);
            if (!firstRCchosenFromYOP)
            {
                firstRCchosenFromYOP = true;
            }
            else if (!secondRCchosenFromYOP)
            {
                secondRCchosenFromYOP = true;
            }
        }
    }
}
