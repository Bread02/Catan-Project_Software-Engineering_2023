using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnightCardsPlayedMainManager : MonoBehaviour
{
    private TurnManager turnManager;

    [SerializeField] TMP_Text player1KCPTxt, player2KCPTxt, player3KCPTxt, player4KCPTxt;
    private List<TMP_Text> playerKCPTxts;
    private Dictionary<int, int> playerKCPAmntDict;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();

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

    public void IncrementKCPAmountToPlayer(int playerNum)
    {
        playerKCPAmntDict[playerNum] += 1;

        playerKCPTxts[playerNum - 1].text = playerKCPAmntDict[playerNum].ToString();
    }
}
