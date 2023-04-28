using System.Collections.Generic;
using UnityEngine;

/**
 * This script offers a solution to the 'longest road' feature found in the original board game.
 * 
 * It uses the settlement and road points found in the game as vertices and edges of a graph, respectively.
 * By simulating a graph structure, the script can perform a depth-first traversal of the board to find out which player owns the longest road.
 * 
 * @author Ben Conway
 * @version 28/04/2023
 */
public class NewLongestRoadCheck : MonoBehaviour
{
    private TurnManager turnManager;
    private List<List<ChooseSettlement>> allSPLists; //order of queue will always be from player 1 to 4 (for 4-player)

    private int playerNumWhoOwnsCurrentLongestRoad, lengthOfLongestRoad; //both of these variables will hold a value of 0 until a road is found with length of at least 5

    public GameObject longestRoad0SP, longestRoadP1SP, longestRoadP2SP, longestRoadP3SP, longestRoadP4SP;
    private List<GameObject> longestRoadSPs;

    private void Start()
    {
        playerNumWhoOwnsCurrentLongestRoad = 0;
        lengthOfLongestRoad = 0;

        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        allSPLists = new List<List<ChooseSettlement>>();

        switch (turnManager.playersToSpawn)
        {
            case 2:
                allSPLists.Add(new List<ChooseSettlement>());
                allSPLists.Add(new List<ChooseSettlement>());
                break;
            case 3:
                allSPLists.Add(new List<ChooseSettlement>());
                allSPLists.Add(new List<ChooseSettlement>());
                allSPLists.Add(new List<ChooseSettlement>());
                break;
            case 4:
                allSPLists.Add(new List<ChooseSettlement>());
                allSPLists.Add(new List<ChooseSettlement>());
                allSPLists.Add(new List<ChooseSettlement>());
                allSPLists.Add(new List<ChooseSettlement>());
                break;
        }

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

    public void AddSettlement(int playerNum, ChooseSettlement settlementPoint)
    {
        allSPLists[playerNum - 1].Add(settlementPoint);
    }

    /*
     * Called whenever a road piece is added to the board by a player
     */
    public void FindLongestRoad()
    {
        //Set every road point as 'unexplored'
        foreach(GameObject roadPoint in GameObject.FindGameObjectsWithTag("RoadPoint"))
        {
            roadPoint.GetComponent<ChooseBorder>().thisRoadPointExplored = false;
        }
        //Not sure if this is needed - but set every settlement/city point as 'unexplored'
        foreach(GameObject settCityPoint in GameObject.FindGameObjectsWithTag("CityPoint"))
        {
            settCityPoint.GetComponent<ChooseSettlement>().thisPointExplored = false;
        }

        int playerNumWithLongestRoad = 0;
        int longestRoadFoundValue = 0;

        //Go through every player's list of 'settlement start points'
        foreach(List<ChooseSettlement> playerSPsList in allSPLists)
        {
            if(playerSPsList.Count <= 0)
            {
                break;
            }
            //Player may have multiple settlements. Therefore need to store the 'longest possible distance' out of ALL the settlements
            int longestPossibleDistForPlayer = 0;
            int playerNumWhoOwnsSP = playerSPsList[0].playerNumWhoOwnsThisSt; //just take one of the settlement starting points and get the player number
            //Debug.Log("Checking player " + playerNumWhoOwnsSP + "'s roads");

            //Use every settlement owned by the player as a start point
            foreach(ChooseSettlement settlementStartPoint in playerSPsList)
            {
                //This is when the depth-first traversal happens
                int playerNum = settlementStartPoint.playerNumWhoOwnsThisSt;
                settlementStartPoint.distanceFromSP = 0; //because it is the start point!
                //Debug.Log("Finding longest road from settlement owned by player " + playerNum);

                List<ChooseSettlement> endPointList = new List<ChooseSettlement>();
                Stack<ChooseSettlement> stack = new Stack<ChooseSettlement>();
                stack.Push(settlementStartPoint);
                while(stack.Count > 0)
                {
                    //Debug.Log("Checking unexplored settlement point");
                    ChooseSettlement settlementPoint = stack.Pop();
                    //If this settlement point has been claimed, then this is the end of the road!
                    //We know that it has been claimed because the settlementPoint.playerNumWhoOwnsThisSt will NOT equal 0 (the default value for all settlement points
                    //But we also need to check that it is NOT the settlement start point.
                    if(settlementPoint.playerNumWhoOwnsThisSt != 0 && !ReferenceEquals(settlementStartPoint, settlementPoint))
                    {
                        //Debug.Log("Adding current unexplored settlement point to endPointList");
                        //Add this settlementPoint to endPointList
                        endPointList.Add(settlementPoint);
                    }
                    //This settlement point has not been claimed
                    else
                    {
                        bool foundNewRoad = false;
                        //Now find all adjacent edges that are owned by the player - these are road pieces on the board
                        List<ChooseBorder> adjRoadsOwnedByPlr = new List<ChooseBorder>();
                        //Debug.Log("Number of roads adjacent to current unexplored settlement point is " + settlementPoint.adjacentRoads.Count);
                        foreach (GameObject adjRoad in settlementPoint.adjacentRoads)
                        {
                            ChooseBorder adjRoadCB = adjRoad.GetComponent<ChooseBorder>();
                            //If the adjacent edge (road) is owned by the player AND this edge has not yet been explored by the traversal
                            //Debug.Log("The player who owns this road is Player " + adjRoadCB.playerNumWhoOwnsThisR);
                            if (adjRoadCB.playerNumWhoOwnsThisR == playerNum && !adjRoadCB.thisRoadPointExplored)
                            {
                                foundNewRoad = true;
                                adjRoadCB.thisRoadPointExplored = true;
                                adjRoadsOwnedByPlr.Add(adjRoadCB);

                                //Now find the settlement point that is at the other end of this road
                                //Must set the 'distanceFromSP' value of the settlementPoint to be one more than settlementPoint

                                //Foreach loop should only iterate twice, for the two settlement points adjacent to the road point
                                //Debug.Log("Number of settlements adjacent to this road is " + adjRoadCB.adjacentSettlements.Count);
                                foreach (GameObject adjSett in adjRoadCB.adjacentSettlements)
                                {
                                    //Debug.Log("Checking out settlement adjacent to road");
                                    ChooseSettlement adjSettCS = adjSett.GetComponent<ChooseSettlement>();

                                    //If statement should only be true once out of the 2 iterations of the foreach loop
                                    //If the adjacent settlement point is NOT 'settlementPoint'
                                    //Debug.Log("The player who owns this adjacent settlement is Player " + adjSettCS.playerNumWhoOwnsThisSt);
                                    if (!ReferenceEquals(adjSett, settlementPoint.gameObject))
                                    {
                                        adjSett.GetComponent<ChooseSettlement>().distanceFromSP = settlementPoint.distanceFromSP + 1;
                                        //Debug.Log("Pushing unexplored settlement owned by player " + playerNum + " onto stack");
                                        stack.Push(adjSett.GetComponent<ChooseSettlement>());
                                    }
                                }
                            }
                        }
                        //If no unexplored roads branch off from this settlementPoint, then this is the end of the road!
                        if (!foundNewRoad)
                        {
                            endPointList.Add(settlementPoint);
                        }
                    }
                }
                //Now go through endPointList and find which point has the longest 'distance from start point'
                int longestDistFromSP = 0;
                //Debug.Log("Length of endPointList is " + endPointList.Count);
                foreach(ChooseSettlement ep in endPointList)
                {
                    if(ep.distanceFromSP > longestDistFromSP)
                    {
                        longestDistFromSP = ep.distanceFromSP;
                    }
                }
                //Now check if the longest distance from this specific settlement start point is greater than the longest distance found so far
                if(longestDistFromSP > longestPossibleDistForPlayer)
                {
                    longestPossibleDistForPlayer = longestDistFromSP;
                }
            }

            Debug.Log("Player " + playerNumWhoOwnsSP + "'s longest road has a distance of " + longestPossibleDistForPlayer);
            //Now check if the longest road for the player is greater than the longest road currently found in the entire traversal
            if(longestPossibleDistForPlayer > longestRoadFoundValue)
            {
                //Update value of longest road
                longestRoadFoundValue = longestPossibleDistForPlayer;
                playerNumWithLongestRoad = playerNumWhoOwnsSP;
            }
        }

        //ONLY update 'playerNumWhoOwnsCurrentLongestRoad' and 'lengthOfLongestRoad' if the length of the longest road found thanks to the traversal is greater than or equal to 5
        if(longestRoadFoundValue >= 5)
        {
            if(playerNumWhoOwnsCurrentLongestRoad == 0)
            {
                //Only add 2 victory points to the player who now has longest road card
                turnManager.playerList[playerNumWithLongestRoad - 1].playerVictoryPoints += 2;
            }
            else
            {
                //Means the player who used to have longest road card loses 2 victory points
                //As well as the new player gaining 2 victory points
                turnManager.playerList[playerNumWhoOwnsCurrentLongestRoad - 1].playerVictoryPoints -= 2;
                turnManager.playerList[playerNumWithLongestRoad - 1].playerVictoryPoints += 2;
            }
            playerNumWhoOwnsCurrentLongestRoad = playerNumWithLongestRoad;
            lengthOfLongestRoad = longestRoadFoundValue;
            //Also need to update the scene so that the players can see who owns the longest road (thanks to the longest road card)
            MoveLongestRoadCard();
        }
        else
        {
            //No player has a road with length of at least 5

            if(playerNumWhoOwnsCurrentLongestRoad != 0)
            {
                //A player did have the longest road, but then they built a settlement that broke up the road.
                //Therefore need to deduct 2 victory points from this player
                turnManager.playerList[playerNumWhoOwnsCurrentLongestRoad - 1].playerVictoryPoints -= 2;
            }
            playerNumWhoOwnsCurrentLongestRoad = 0;
            lengthOfLongestRoad = 0;
            MoveLongestRoadCard();
        }

        Debug.Log("Length of longest road currently on the board is " + lengthOfLongestRoad+" - NOTE: This will be 0 until a road of length 5 is constructed");
        Debug.Log("Player " + playerNumWhoOwnsCurrentLongestRoad + " owns the longest road - NOTE: This will be 0 until a road of length 5 is constructed");
    }

    /*
     * Method for visually displaying who owns the longest road
     */
    public void MoveLongestRoadCard()
    {
        Debug.Log("Moving longest road card!");
        for (int i = 0; i < longestRoadSPs.Count; i++)
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
    }
}
