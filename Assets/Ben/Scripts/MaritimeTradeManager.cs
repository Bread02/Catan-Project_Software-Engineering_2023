using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaritimeTradeManager : MonoBehaviour
{
    /*
     * This script manages the processes of the maritime trade.
     * The maritime trade starts when the player clicks the maritime trade button.
     * When they have clicked this, the player will drag their first card to the bank.
     * 
     * When 4 resource cards of the same type are added to the bank, an 'any card' token, seen in the HUD as a question mark, is automatically given to the player.
     * 
     * At any time, the player can press the 'cancel' button. This causes all cards given to the bank to be returned back to the player.
     * 
     * When the player presses the 'confirm' button, they can drag resource card(s) they want directly from the bank to their hand, equal to the value of tokens they have.
     * NOTE: Once the player confirms, they cannot then cancel the trade. They must take resource card(s) from the bank.
     * 
     * The player is expected to know that they have at least 4 resource cards of the same type. If they cannot make a trade, the 'cancel' button is always available.
     */

    [Header("Dictionaries")]
    private Dictionary<string, int> cardAmountsDict, totalTradedDict;

    [SerializeField] private Bank_HUD_Manager bankHUDMang;

    private TurnManager turnManager; //Altair line

    private bool inTradeMode, inStartMode; //Altair line

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>(); //Altair line
    }

    public void InitaliseMaritimeTrade()
    {
        cardAmountsDict = new Dictionary<string, int>();
        totalTradedDict = new Dictionary<string, int>();
        inTradeMode = true; //Altair line
    }
}
