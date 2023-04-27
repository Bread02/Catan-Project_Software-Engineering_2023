using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/**
 * This script is responsbie for controlling the how to play menu in the mainscene2.
 *
 * @author Altair, Ben
 * @version 27/04/2023
 */
public class KnightCardsPlayedMainManager : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;

    [Header("Text")]
    [SerializeField] TMP_Text player1KCPTxt, player2KCPTxt, player3KCPTxt, player4KCPTxt;

    [Header("Lists")]
    private List<TMP_Text> playerKCPTxts;

    [Header("Dictionaries")]
    private Dictionary<int, int> playerKCPAmntDict;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        SomethingMethod();
    }

    // BEN PLS PUT COMMENT
    private void SomethingMethod()
    {
        playerKCPTxts = new List<TMP_Text>();
        playerKCPAmntDict = new Dictionary<int, int>();
        switch (turnManager.playersToSpawn)
        {
            case 2:
                playerKCPTxts.Add(player1KCPTxt);
                playerKCPTxts.Add(player2KCPTxt);

                playerKCPAmntDict.Add(1, 0);
                playerKCPAmntDict.Add(2, 0);
                break;
            case 3:
                playerKCPTxts.Add(player1KCPTxt);
                playerKCPTxts.Add(player2KCPTxt);
                playerKCPTxts.Add(player3KCPTxt);

                playerKCPAmntDict.Add(1, 0);
                playerKCPAmntDict.Add(2, 0);
                playerKCPAmntDict.Add(3, 0);
                break;
            case 4:
                playerKCPTxts.Add(player1KCPTxt);
                playerKCPTxts.Add(player2KCPTxt);
                playerKCPTxts.Add(player3KCPTxt);
                playerKCPTxts.Add(player4KCPTxt);

                playerKCPAmntDict.Add(1, 0);
                playerKCPAmntDict.Add(2, 0);
                playerKCPAmntDict.Add(3, 0);
                playerKCPAmntDict.Add(4, 0);
                break;
        }
    }

    // increments the player's Knight cards.
    public void IncrementKCPAmountToPlayer(int playerNum)
    {
        playerKCPAmntDict[playerNum] += 1;

        playerKCPTxts[playerNum - 1].text = playerKCPAmntDict[playerNum].ToString();
    }
}
