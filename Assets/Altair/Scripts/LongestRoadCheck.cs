using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestRoadCheck : MonoBehaviour
{
    public GameObject longestRoadCard;

    // current largest player
    public PlayerManager playerWithLongestRoad;
    private TurnManager turnManager;
    private int sizeOfLongestRoad;

    private bool hasBeenGivenToAPlayer;

    [Header("Largest Army Points")]
    public Transform P0Point;
    public Transform P1Point;
    public Transform P2Point;
    public Transform P3Point;
    public Transform P4Point;
    // Start is called before the first frame update
    void Start()
    {
        sizeOfLongestRoad = 5;
        hasBeenGivenToAPlayer = false;
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        longestRoadCard.transform.position = P0Point.position; // start at no players.
    }

    private void Update()
    {
        int currentLongestRoad = 0, playerNumWhoOwnsCurrentLongestRoad = 0;
        foreach(GameObject roadPoint in GameObject.FindGameObjectsWithTag("RoadPoint"))
        {
            int rpFurthDist = roadPoint.GetComponent<ChooseBorder>().furthestDistanceFromASettlement;
            if (rpFurthDist > currentLongestRoad)
            {
                currentLongestRoad = rpFurthDist;
                playerNumWhoOwnsCurrentLongestRoad = roadPoint.GetComponent<ChooseBorder>().playerClaimedBy;
            }
        }

        if(currentLongestRoad > sizeOfLongestRoad)
        {
            switch (playerNumWhoOwnsCurrentLongestRoad)
            {
                case 1:
                    longestRoadCard.transform.position = P1Point.position;
                    longestRoadCard.transform.rotation = P1Point.rotation;
                    break;
                case 2:
                    longestRoadCard.transform.position = P2Point.position;
                    longestRoadCard.transform.rotation = P2Point.rotation;
                    break;
                case 3:
                    longestRoadCard.transform.position = P3Point.position;
                    longestRoadCard.transform.rotation = P3Point.rotation;
                    break;
                case 4:
                    longestRoadCard.transform.position = P4Point.position;
                    longestRoadCard.transform.rotation = P4Point.rotation;
                    break;
            }
            if(!hasBeenGivenToAPlayer)
            {
                playerWithLongestRoad = turnManager.playerList[playerNumWhoOwnsCurrentLongestRoad - 1];
                playerWithLongestRoad.playerVictoryPoints += 2;
                hasBeenGivenToAPlayer = true;
            }
            else
            {
                playerWithLongestRoad.playerVictoryPoints -= 2;
                playerWithLongestRoad = turnManager.playerList[playerNumWhoOwnsCurrentLongestRoad - 1];
                playerWithLongestRoad.playerVictoryPoints += 2;
            }
            sizeOfLongestRoad = currentLongestRoad;
        }
    }

    /*
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
    }*/ //Commented out because not sure if needed anymore - anyway I (Ben) aren't using them
}
