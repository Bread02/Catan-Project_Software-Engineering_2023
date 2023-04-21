using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;
    private Robber robber;

    [Header("Game Objects")]
    [SerializeField] private GameObject bankGuiTxt;
    [SerializeField] private GameObject tradeGUImang;

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

    public void IncOrDecValue(string key, int value)
    {
        int temp = bank[key];
        bank[key] += value;
        if (temp <= 0)
        {
            Debug.Log("No more " + key + " cards left in bank!");
            bank[key] = 0;
        }
        if (key == "knight" || key == "victoryPoints" || key == "monopoly" || key == "roadBuilding" || key == "yearOfPlenty")
        {
            bankGuiTxt.GetComponent<DisplayBankQuantities>().ChangeQuantity("development", GetDevCardQuant());
        }
        else
        {
            bankGuiTxt.GetComponent<DisplayBankQuantities>().ChangeQuantity(key, bank[key]);
        }
        
    }

    private int GetDevCardQuant()
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

    private void OnTriggerEnter(Collider cardPlayed)
    {
        string cardType = cardPlayed.gameObject.tag;
        Debug.Log(cardType);
        turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, -1, cardPlayed.gameObject);

        if (cardType == "knight" || cardType == "victoryPoints" || cardType == "monopoly" || cardType == "roadBuilding" || cardType == "yearOfPlenty") //development card played
        {
            Debug.Log("card type is corret. " + cardType);
            if (tradeStarted) //cannot play development cards while trading!
            {
                turnManager.ReturnCurrentPlayer().IncOrDecValue(cardType, 1);
            }

            if(cardType == "knight")
            {
                // activate robber
                robber.TriggerRobberMovement();
                turnManager.ReturnCurrentPlayer().IncrementKnightCardUsage();
            }

        }
        else //resource card played
        {
            tradeGUImang.GetComponent<TradeManager>().CardAddedToTrade(cardPlayed.gameObject);
            tradeStarted = true;
        }

        StartCoroutine(ChangeColour());
    }

    IEnumerator ChangeColour()
    {
        this.gameObject.GetComponent<Renderer>().material = blackMat;

        yield return new WaitForSeconds(0.2f);

        this.gameObject.GetComponent<Renderer>().material = whiteMat;
    }
}
