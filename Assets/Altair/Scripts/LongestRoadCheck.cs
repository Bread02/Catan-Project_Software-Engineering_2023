using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestRoadCheck : MonoBehaviour
{
    public GameObject longestRoadCard;

    // current largest player
    public PlayerManager playerWithLongestRoad;
    private TurnManager turnManager;


    [Header("Largest Army Points")]
    public Transform P0Point;
    public Transform P1Point;
    public Transform P2Point;
    public Transform P3Point;
    public Transform P4Point;
    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        longestRoadCard.transform.position = P0Point.position; // start at no players.

    }


    public void SetAllPlayersToFalse()
    {
        for (int i = 0; i < turnManager.playerList.Count; i++)
        {
            turnManager.playerList[i].SetLargestArmy(false);
        }
    }

    public void MoveLongestRoadCard()
    {
        int playerNumber = 0;
        if (playerWithLongestRoad != null)
        {
            playerNumber = playerWithLongestRoad.playerNumber;

        }
        switch (playerNumber)
        {
            // no one has it
            case 0:
                return;
            case 1:
                longestRoadCard.transform.position = P1Point.position;
                break;
            case 2:
                longestRoadCard.transform.position = P2Point.position;
                break;
            case 3:
                longestRoadCard.transform.position = P3Point.position;
                break;
            case 4:
                longestRoadCard.transform.position = P4Point.position;
                break;
        }
    }
}
