using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script checks for the longest road, and grants the player that card if they have the longest road.
 *
 * @author Altair, Ben
 * @version 26/04/2023
 */
public class LongestRoadCheck : MonoBehaviour
{
    /* Commented out because not in use right now and it throws errors
    // current largest player
    [Header("Other Scripts")]
    public PlayerManager playerWithLongestRoad;
    private TurnManager turnManager;

    public GameObject longestRoad0SP, longestRoadP1SP, longestRoadP2SP, longestRoadP3SP, longestRoadP4SP;

    [Header("Other")]
    private int lengthOfLongestRoad;
    private bool hasBeenGivenToAPlayer;
    private List<GameObject> longestRoadSPs;

    // Start is called before the first frame update
    void Start()
    {
        lengthOfLongestRoad = 4; //Must be 4 so that condition on line 61 is true when player builds road of length 5
        hasBeenGivenToAPlayer = false;
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        longestRoadSPs = new List<GameObject>
        {
            longestRoad0SP
        };
        switch (turnManager.playersToSpawn)
        {
            case 2:
                longestRoadSPs.Add(longestRoadP1SP);
                longestRoadSPs.Add(longestRoadP2SP);
                break;
            case 3:
                longestRoadSPs.Add(longestRoadP1SP);
                longestRoadSPs.Add(longestRoadP2SP);
                longestRoadSPs.Add(longestRoadP3SP);
                break;
            case 4:
                longestRoadSPs.Add(longestRoadP1SP);
                longestRoadSPs.Add(longestRoadP2SP);
                longestRoadSPs.Add(longestRoadP3SP);
                longestRoadSPs.Add(longestRoadP4SP);
                break;
        }
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
                playerNumWhoOwnsCurrentLongestRoad = roadPoint.GetComponent<ChooseBorder>().playerNumWhoOwnsThisR;
            }
        }

        if(currentLongestRoad > lengthOfLongestRoad)
        {
            for(int i = 0; i < longestRoadSPs.Count; i++)
            {
                if (i == playerNumWhoOwnsCurrentLongestRoad)
                {
                    longestRoadSPs[i].SetActive(true);
                }
                else
                {
                    longestRoadSPs[i].SetActive(false);
                }
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
            lengthOfLongestRoad = currentLongestRoad;
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
