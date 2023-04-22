using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [Header("Other Scripts")]
    private LargestArmyCheck largestArmyCheck;

    [Header("Dictionaries")]
    protected Dictionary<string, int> pCardQuantities; //key = card type, value = quantity of card type in player's hand
    private Dictionary<string, TMP_Text> rcQuantityTextsDict, dcQuantityTextsDict; //key = card type, value = text to show quantity of card type in player's hand
    private Dictionary<string, GameObject> cardSpawnPoints; //key = card type, value = CardSP for card type
    private Dictionary<string, GameObject> cardTypeParentObjs; //key = card type, value = parent object for card type

    [Header("Game Objects")]
    [SerializeField] private GameObject cardPfab;
    [SerializeField] private GameObject[] RCspawnPoints, DCspawnPoints;

    [SerializeField] private Sprite grainMat, woolMat, brickMat, oreMat, lumberMat, knightMat, victoryPointsMat, monopolyMat, roadBuildingMat, yearOfPlentyMat;

    /*
     * Actual x-coordinate values for the spawn points in global space:
     * RCspawnPoints = 0, 2, 4, 6, 8
     * DCspawnPoints = 10, 12, 14, 16, 18
     */

    private List<GameObject> RChandOrder, DChandOrder;

    [Header("Player Owned Structures")]
    public List<GameObject> playerOwnedSettlements;
    public List<GameObject> playerOwnedCities;
    public List<GameObject> playerOwnedRoads;

    public string playerColor;

    [Header("Player Colors")]
    public Material red;
    public Material blue;
    public Material white;
    public Material orange;

    [Header("Player Stats")]
    private int numberOfKnightCardsPlayed;
    private int longestSingleRoad;
    public bool ownsLargestArmy;
    public bool ownsLongestRoad;

    [Header("Ints")]
    public int playerNumber;
    private int RCfreeSpacePointer, DCfreeSpacePointer;
    public int playerVictoryPoints;
    public int victoryPointCardsPlayed;

    [Header("Other")]
    [SerializeField] private TMP_Text[] rcQuantTxts, dcQuantTxts; //direct address of the 'quantity' text components for resource cards and dev cards, respectively

    public bool ownsImprovedHarbor = false, ownsBrickHarbor = false, ownsLumberHarbor = false, ownsWoolHarbor = false, ownsOreHarbor = false, ownsGrainHarbor = false;
    public int ReturnNumberOfRCCards()
    {
        List<int> values = new List<int>();
        int totalValue = 0;
        foreach (var kvp in pCardQuantities)
        {
            if (kvp.Key == "grain" || kvp.Key == "wool" || kvp.Key == "brick" || kvp.Key == "ore" || kvp.Key == "lumber")
            {
                //      Debug.Log("Key: " + kvp.Key);
                //      Debug.Log("value: " + kvp.Value);
                values.Add(kvp.Value);
            }
        }

        foreach (int val in values)
        {
            totalValue += val;
        }


        return totalValue;
    }

    public void SetPlayerNumber(int playerNumberSet)
    {
        playerNumber = playerNumberSet;
    }

    public enum ColorSelected
    {
        red,
        blue,
        white,
        orange
    }

    public ColorSelected colorSelected;

    public void SetLargestArmy(bool hasLargestArmy)
    {
        ownsLargestArmy = hasLargestArmy;
    }


    public int ReturnNumberOfKnightCardsPlayed()
    {
        return numberOfKnightCardsPlayed;
    }

    private void Start()
    {
        InvokeRepeating("CountVictoryPoints", 1f, 1f);

        // largestArmyCheck = GameObject.Find("LargestArmyCheck").GetComponent<LargestArmyCheck>(); - commented out because it throws error

        pCardQuantities = new Dictionary<string, int>
        {
            {"grain", 0 },
            {"wool", 0 },
            {"brick", 0 },
            {"ore", 0 },
            {"lumber", 0 },
            {"knight", 0 },
            {"victoryPoints", 0 },
            {"monopoly", 0 },
            {"roadBuilding", 0 },
            {"yearOfPlenty", 0 }
        };

        rcQuantityTextsDict = new Dictionary<string, TMP_Text>();
        dcQuantityTextsDict = new Dictionary<string, TMP_Text>();

        cardSpawnPoints = new Dictionary<string, GameObject>();

        cardTypeParentObjs = new Dictionary<string, GameObject>
        {
            {"grain", null },
            {"wool", null },
            {"brick", null },
            {"ore", null },
            {"lumber", null },
            {"knight", null },
            {"victoryPoints", null },
            {"monopoly", null },
            {"roadBuilding", null },
            {"yearOfPlenty", null }
        };

        RChandOrder = new List<GameObject>();
        DChandOrder = new List<GameObject>();

        RCfreeSpacePointer = 0;
        DCfreeSpacePointer = 0;
    }

    public void IncrementKnightCardUsage()
    {
        numberOfKnightCardsPlayed++;
        largestArmyCheck.CheckLongestArmy();
    }


    public void PlayerColor(int colors)
    {
        // color
        switch (colors)
        {
            case 0:
                colorSelected = ColorSelected.blue;
                break;
            case 1:
                colorSelected = ColorSelected.orange;
                break;
            case 2:
                colorSelected = ColorSelected.red;
                break;
            case 3:
                colorSelected = ColorSelected.white;
                break;
        }
    }

    public string GetPlayerColor()
    {
        return colorSelected.ToString();
    }

    //can use negative numbers too (adding a negative is subtraction)
    public void IncOrDecValue(string key, int value, GameObject cardPfabToRemove = null)
    {
        if (value > 0)
        {
            if (key == "grain" || key == "wool" || key == "brick" || key == "ore" || key == "lumber")
            {
                AddResourceCard(key, value);
            }
            else
            {
                AddDevelopmentCard(key, value);
            }
        }
        else if (value < 0)
        {
            if (key == "grain" || key == "wool" || key == "brick" || key == "ore" || key == "lumber")
            {
                RemoveResourceCard(key, value, cardPfabToRemove);
            }
            else
            {
                RemoveDevelopmentCard(key, value, cardPfabToRemove);
            }
        }
    }

    /*
     * Actions that cause card to be removed:
     * - Player plays the card
     */

    private void RemoveResourceCard(string cardTag, int amountRemoved, GameObject cardPfabToRemove)
    {
        pCardQuantities[cardTag] += amountRemoved;
        Destroy(cardPfabToRemove);

        rcQuantityTextsDict[cardTag].text = pCardQuantities[cardTag].ToString();

        if (pCardQuantities[cardTag] <= 0)
        {
            RChandOrder.Remove(cardTypeParentObjs[cardTag]);
            cardSpawnPoints.Remove(cardTag);

            Destroy(cardTypeParentObjs[cardTag]);

            pCardQuantities[cardTag] = 0;

            foreach (TMP_Text spText in rcQuantTxts)
            {
                spText.gameObject.SetActive(false);
            }
            rcQuantityTextsDict.Clear();

            //This works well!
            RCfreeSpacePointer = 0;
            foreach (GameObject cardParentObj in RChandOrder)
            {
                cardParentObj.transform.SetParent(RCspawnPoints[RCfreeSpacePointer].transform);
                cardParentObj.transform.localPosition = new Vector3(0, 0, 0);
                cardTypeParentObjs[cardParentObj.tag] = cardParentObj;

                rcQuantTxts[RCfreeSpacePointer].text = pCardQuantities[cardParentObj.tag].ToString();
                rcQuantTxts[RCfreeSpacePointer].gameObject.SetActive(true);
                rcQuantityTextsDict.Add(cardParentObj.tag, rcQuantTxts[RCfreeSpacePointer]);

                RCfreeSpacePointer++;
            }
            //
        }
    }

    private void RemoveDevelopmentCard(string cardTag, int amountRemoved, GameObject cardPfabToRemove)
    {
        pCardQuantities[cardTag] += amountRemoved;
        Destroy(cardPfabToRemove);

        dcQuantityTextsDict[cardTag].text = pCardQuantities[cardTag].ToString();

        if (pCardQuantities[cardTag] <= 0)
        {
            DChandOrder.Remove(cardTypeParentObjs[cardTag]);
            cardSpawnPoints.Remove(cardTag);

            Destroy(cardTypeParentObjs[cardTag]);

            pCardQuantities[cardTag] = 0;

            foreach (TMP_Text spText in dcQuantTxts)
            {
                spText.gameObject.SetActive(false);
            }
            dcQuantityTextsDict.Clear();

            //This works well!
            DCfreeSpacePointer = 0;
            foreach (GameObject cardParentObj in DChandOrder)
            {
                cardParentObj.transform.SetParent(DCspawnPoints[DCfreeSpacePointer].transform);
                cardParentObj.transform.localPosition = new Vector3(0, 0, 0);
                cardTypeParentObjs[cardParentObj.tag] = cardParentObj;

                dcQuantTxts[DCfreeSpacePointer].text = pCardQuantities[cardParentObj.tag].ToString();
                dcQuantTxts[DCfreeSpacePointer].gameObject.SetActive(true);
                dcQuantityTextsDict.Add(cardParentObj.tag, dcQuantTxts[DCfreeSpacePointer]);

                DCfreeSpacePointer++;
            }
            //
        }
    }

    private void AddResourceCard(string cardTag, int amountAdded)
    {
        if (pCardQuantities[cardTag] == 0) //card type is NOT currently in player's hand
        {
            pCardQuantities[cardTag] += amountAdded;

            rcQuantTxts[RCfreeSpacePointer].text = pCardQuantities[cardTag].ToString(); //sets corresponding text to show user how many cards they own of that card type

            rcQuantityTextsDict.Add(cardTag, rcQuantTxts[RCfreeSpacePointer]);
            cardSpawnPoints.Add(cardTag, RCspawnPoints[RCfreeSpacePointer]); //sets corresponding spawn point of the card type

            //create a parent object for card type - any future cards added that are the same card type
            GameObject cardTypeParentObj = Instantiate(new GameObject(), cardSpawnPoints[cardTag].transform);
            cardTypeParentObj.gameObject.tag = cardTag;

            for (int i = 0; i < amountAdded; i++) //for loop as multiple cards can be added in one call of method
            {
                GameObject newCard = Instantiate(cardPfab, cardTypeParentObj.transform);
                newCard.GetComponent<DragAndDropControl>().SetPlayerNumWhoOwnsThisCard(playerNumber);
                newCard.tag = cardTag;
                SetCardMat(newCard);
            }

            cardTypeParentObjs[cardTag] = cardTypeParentObj;
            RChandOrder.Add(cardTypeParentObj);

            rcQuantityTextsDict[cardTag].gameObject.SetActive(true); //this gameobject will not be active if the card is a 'new' card type being added to player's hand
            RCfreeSpacePointer++;
        }
        else //card type IS in player's hand
        {
            pCardQuantities[cardTag] += amountAdded;
            for (int i = 0; i < amountAdded; i++)
            {
                GameObject newCard = Instantiate(cardPfab, cardTypeParentObjs[cardTag].transform);
                newCard.GetComponent<DragAndDropControl>().SetPlayerNumWhoOwnsThisCard(playerNumber);
                newCard.tag = cardTag;
                SetCardMat(newCard);
            }
            rcQuantityTextsDict[cardTag].text = pCardQuantities[cardTag].ToString(); //sets corresponding text to show user how many cards they own of that card type
        }
    }

    public void AddDevelopmentCard(string cardTag, int amountAdded)
    {
        if (pCardQuantities[cardTag] == 0) //card type is NOT currently in player's hand
        {
            pCardQuantities[cardTag] += amountAdded;

            dcQuantTxts[DCfreeSpacePointer].text = pCardQuantities[cardTag].ToString(); //sets corresponding text to show user how many cards they own of that card type

            dcQuantityTextsDict.Add(cardTag, dcQuantTxts[DCfreeSpacePointer]);
            cardSpawnPoints.Add(cardTag, DCspawnPoints[DCfreeSpacePointer]); //sets corresponding spawn point of the card type

            //create a parent object for card type - any future cards added that are the same card type
            GameObject cardTypeParentObj = Instantiate(new GameObject(), cardSpawnPoints[cardTag].transform);
            cardTypeParentObj.gameObject.tag = cardTag;

            for (int i = 0; i < amountAdded; i++) //for loop as multiple cards can be added in one call of method
            {
                GameObject newCard = Instantiate(cardPfab, cardTypeParentObj.transform);
                newCard.GetComponent<DragAndDropControl>().SetPlayerNumWhoOwnsThisCard(playerNumber);
                newCard.tag = cardTag;
                SetCardMat(newCard);
            }

            cardTypeParentObjs[cardTag] = cardTypeParentObj;
            DChandOrder.Add(cardTypeParentObj);

            dcQuantityTextsDict[cardTag].gameObject.SetActive(true); //this gameobject will not be active if the card is a 'new' card type being added to player's hand
            DCfreeSpacePointer++;
        }
        else //card type IS in player's hand
        {
            pCardQuantities[cardTag] += amountAdded;
            for (int i = 0; i < amountAdded; i++)
            {
                GameObject newCard = Instantiate(cardPfab, cardTypeParentObjs[cardTag].transform);
                newCard.GetComponent<DragAndDropControl>().SetPlayerNumWhoOwnsThisCard(playerNumber);
                newCard.tag = cardTag;
                SetCardMat(newCard);
            }
            dcQuantityTextsDict[cardTag].text = pCardQuantities[cardTag].ToString(); //sets corresponding text to show user how many cards they own of that card type
        }
    }

    private void SetCardMat(GameObject card)
    {
        switch (card.tag)
        {
            case "grain": //grain
                card.GetComponent<SpriteRenderer>().sprite = grainMat;
                break;
            case "wool": //wool
                card.GetComponent<SpriteRenderer>().sprite = woolMat;
                break;
            case "ore": //ore
                card.GetComponent<SpriteRenderer>().sprite = oreMat;
                break;
            case "brick": //brick
                card.GetComponent<SpriteRenderer>().sprite = brickMat;
                break;
            case "lumber": //lumber
                card.GetComponent<SpriteRenderer>().sprite = lumberMat;
                break;
            case "knight": //knight
                card.GetComponent<SpriteRenderer>().sprite = knightMat;
                break;
            case "yearOfPlenty": //yearOfPlenty
                card.GetComponent<SpriteRenderer>().sprite = yearOfPlentyMat;
                break;
            case "monopoly": //monopoly
                card.GetComponent<SpriteRenderer>().sprite = monopolyMat;
                break;
            case "roadBuilding": //roadBuilding
                card.GetComponent<SpriteRenderer>().sprite = roadBuildingMat;
                break;
            case "victoryPoints": //victoryPoints
                card.GetComponent<SpriteRenderer>().sprite = victoryPointsMat;
                break;
        }
    }

    public void CheckIfNewCards(List<GameObject> tiles)
    {
        // go through all player owned settlements and find if adjacent tile is in the tiles list.
        for (int j = 0; j < playerOwnedSettlements.Count; j++)
        {
            //    Debug.Log("Inside player owned settlements");

            foreach (GameObject tiles1 in tiles)
            {

                //    Debug.Log("Inside tiles");


                // loop through first
                for (int i = 0; i < playerOwnedSettlements.Count; i++)
                {
                    //      Debug.Log("sETTLEMENT: " + playerOwnedSettlements[i]);
                }


                // loop through second=
                for (int i = 0; i < tiles.Count; i++)
                {
                    //        Debug.Log("sETTLEMENT: " + tiles1);
                }


                if (playerOwnedSettlements[j].GetComponent<ChooseSettlement>().adjacentTiles.Contains(tiles1))
                {

                    // if not blocked by robber, remove card from bank and add new card to player's hand.
                    if (!tiles1.GetComponent<TerrainHex>().robberBlocked)
                    {

                        string terrainType = tiles1.GetComponent<TerrainHex>().terrain.ToString();
                        GameObject.Find("THE_BANK").GetComponent<BankManager>().IncOrDecValue(terrainType, -1);
                        AddResourceCard(terrainType, 1);
                        Debug.Log("Adding new player card");
                    }
                    else
                    {
                        Debug.Log("Robber blocking tile :( no new cards");
                    }
                }
            }

        }

    }

    public void SetBuildingColors(string color)
    {
        if (color == "red")
        {

        }
    }

    private void CountVictoryPoints()
    {
        // start with 0.
        playerVictoryPoints = 0;

        // 1 point per settlement
        playerVictoryPoints += playerOwnedSettlements.Count;

        // 2 points per city
        playerVictoryPoints += playerOwnedCities.Count * 2;

        // 
        if (PlayerHasLongestRoad())
        {
            playerVictoryPoints += 2;
        }

        if (PlayerHasLargestArmy())
        {
            playerVictoryPoints += 2;
        }
        playerVictoryPoints += victoryPointCardsPlayed;
    }

    public int ReturnVictoryPoints()
    {
        return playerVictoryPoints;
    }

    public bool PlayerHasLongestRoad()
    {
        return false;
    }

    public bool PlayerHasLargestArmy()
    {
        return ownsLargestArmy;
    }


    public void PlayVictoryPointCard()
    {
        victoryPointCardsPlayed++;
    }

}
