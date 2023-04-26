using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongestRoadCheck : MonoBehaviour
{
    // current largest player
    public PlayerManager playerWithLongestRoad;
    private TurnManager turnManager;
    private int sizeOfLongestRoad;

    private bool hasBeenGivenToAPlayer;

    public GameObject longestRoad0SP, longestRoadP1SP, longestRoadP2SP, longestRoadP3SP, longestRoadP4SP;

    private List<GameObject> longestRoadSPs;

    // Start is called before the first frame update
    void Start()
    {
        sizeOfLongestRoad = 4; //Must be 4 so that condition on line 61 is true when player builds road of length 5
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
                playerNumWhoOwnsCurrentLongestRoad = roadPoint.GetComponent<ChooseBorder>().playerClaimedBy;
            }
        }

        if(currentLongestRoad > sizeOfLongestRoad)
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
