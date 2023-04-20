using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank_Object_Manager : MonoBehaviour
{
    /*
     * Manages cards 'dropped' by player onto bank, and cards 'taken' by players from the bank.
     * When the quantity of a card type is altered, the appropriate function is called in Bank_HUD_Manager
     * If the player is carrying out a maritime trade, or build, then they will interact with the bank.
     */

    private bool tradeStarted;

    [SerializeField] private Bank_HUD_Manager bankHUDMang;

    public void SetTradeStarted(bool x)
    {
        tradeStarted = x;
    }

    /*
     * When a card is dropped onto the bank, this method is called.
     */
    private void OnTriggerEnter(Collider other)
    {
        if (tradeStarted)
        {

        }
    }
}
