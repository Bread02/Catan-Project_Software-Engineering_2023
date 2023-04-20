using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank_HUD_Manager : MonoBehaviour
{
    /*
     * Manages the HUD (Heads-Up Display) specifically for the bank.
     * This script plays greater importance in managing the Bank, as it holds a dictionary for the quantity of cards in the bank.
     */

    private Dictionary<string, int> bank;

    [SerializeField] private TMP_Text brickQuant, lumberQuant, grainQuant, woolQuant, oreQuant, devQuant;

    private void Start()
    {
        bank = new Dictionary<string, int>
        {
            {"brick", 19 },
            {"lumber", 19 },
            {"grain", 19 },
            {"wool", 19 },
            {"ore", 19 },
            {"knight", 14 },
            {"victoryPoints", 5 },
            {"monopoly", 2 },
            {"roadBuilding", 2 },
            {"yearOfPlenty", 2 }
        };
    }

    public void CardQuantUpdate()
    {
        brickQuant.text = bank["brick"].ToString();
        lumberQuant.text = bank["lumber"].ToString();
        grainQuant.text = bank["grain"].ToString();
        woolQuant.text = bank["wool"].ToString();
        oreQuant.text = bank["ore"].ToString();
        devQuant.text = (bank["knight"] + bank["victoryPoints"] + bank["monopoly"] + bank["roadBuilding"] + bank["yearOfPlenty"]).ToString();
    }

    /*
     * When this method is first called, the player is either performing a maritime trade, or wants to build an asset.
     */
    public void CardAddedToBank(GameObject card)
    {

    }
}
