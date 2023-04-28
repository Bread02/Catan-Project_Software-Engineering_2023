using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * This script updates the heads-up text display for the amount of cards remaining in the bank, a useful display for all players.
 * 
 * @author Ben Conway
 * @version 28/04/2023
 */
public class DisplayBankQuantities : MonoBehaviour
{
    private Dictionary<string, TMP_Text> bankTxtDict;

    // Start is called before the first frame update
    void Start()
    {
        bankTxtDict = new Dictionary<string, TMP_Text>();

        foreach (Transform cardsInBankTxt in this.gameObject.transform)
        {
            bankTxtDict[cardsInBankTxt.tag] = cardsInBankTxt.gameObject.GetComponent<TMP_Text>();
        }
    }

    public void ChangeQuantity(string key, int newValue)
    {
        bankTxtDict[key].text = newValue.ToString();
    }
}
