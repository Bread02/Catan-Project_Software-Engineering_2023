using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainAssigner : MonoBehaviour
{
    [Header("Other Scripts")]
    private Robber robber;

    [Header("Lists")]
    public List<GameObject> tileList = new List<GameObject>();
    public List<GameObject> tileNoDesertList = new List<GameObject>();
    public List<GameObject> tileNumberMatches = new List<GameObject>();
    public List<GameObject> orderedTileList = new List<GameObject>(); // ordered list is assigned from top left to bottom right manually.

    [Header("Game Objects")]
    public GameObject desertHex;
    public GameObject selectedRobberHex;

    // Start is called before the first frame update
    
    void Awake()
    {
        robber = GameObject.Find("Robber").GetComponent<Robber>();
    }


    // Triggers the assign tiles beginner script.
    public void AssignTilesBeginner()
    {
        AssignTilesBeginnerMap();
        Debug.Log("Creating Beginner Map");
    }

    // Triggers the assign tiles random script.
    public void AssignTilesRandom()
    {
        AssignTiles();
    }

    // Enables the robber activated script on all hexes.
    public void TriggerRobber()
    {
        foreach(GameObject hex in tileList)
        {
            hex.GetComponent<TerrainHex>().robberActivated = true;
        }
    }

    // Disables the robber activated script on all hexes.
    public void EndTriggerRobber()
    {
        foreach (GameObject hex in tileList)
        {
            hex.GetComponent<TerrainHex>().robberActivated = false;
        }
        UnselectAllHex();
    }

    // Unselects all hexes.
    public void UnselectAllHex()
    {
        foreach (GameObject hex in tileList)
        {
            hex.GetComponent<TerrainHex>().UnselectHex();
        }
    }


    // Selects the hex for the robber.
    public GameObject SelectedHexForRobber()
    {
        Debug.Log("Selected hex for robber");
        robber.robberPositionSelected = true;
        return selectedRobberHex;
    }


    // when dice roll complete, find all hex that matches that dice roll.
    public List<GameObject> FindMatchingHexNumbers(int hexNumber)
    {
        List<GameObject> matchingHex = new List<GameObject>();

        foreach(GameObject tile in tileList)
        {
            if(tile.GetComponent<TerrainHex>().terrainDiceNumber == hexNumber)
            {
                matchingHex.Add(tile);
            }
        }

        return matchingHex;
    }


    // Assigns all tiles a 0.
    public void AssignTiles()
    {
        for (int j = 0; j < tileList.Count; j++)
        {
            tileList[j].GetComponent<TerrainHex>().AssignTile(0); // for beginner map, a number would be assigned, otherwise 0 is random.
        }

        AssignTerrainDiceNumber();
    }

    // Assigns each ordered tile a specific type.
    public void AssignTilesBeginnerMap()
    {
        orderedTileList[0].GetComponent<TerrainHex>().AssignTerrainTypeNumber(13); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[1].GetComponent<TerrainHex>().AssignTerrainTypeNumber(1); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[2].GetComponent<TerrainHex>().AssignTerrainTypeNumber(9); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[3].GetComponent<TerrainHex>().AssignTerrainTypeNumber(5); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[4].GetComponent<TerrainHex>().AssignTerrainTypeNumber(16); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[5].GetComponent<TerrainHex>().AssignTerrainTypeNumber(1); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[6].GetComponent<TerrainHex>().AssignTerrainTypeNumber(16); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[7].GetComponent<TerrainHex>().AssignTerrainTypeNumber(5); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[8].GetComponent<TerrainHex>().AssignTerrainTypeNumber(9); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[9].GetComponent<TerrainHex>().AssignDesertTile(); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[9].GetComponent<TerrainHex>().AssignTerrainTypeNumber(0); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[10].GetComponent<TerrainHex>().AssignTerrainTypeNumber(9); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[11].GetComponent<TerrainHex>().AssignTerrainTypeNumber(13); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[12].GetComponent<TerrainHex>().AssignTerrainTypeNumber(9); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[13].GetComponent<TerrainHex>().AssignTerrainTypeNumber(13); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[14].GetComponent<TerrainHex>().AssignTerrainTypeNumber(5); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[15].GetComponent<TerrainHex>().AssignTerrainTypeNumber(1); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[16].GetComponent<TerrainHex>().AssignTerrainTypeNumber(16); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[17].GetComponent<TerrainHex>().AssignTerrainTypeNumber(5); // for beginner map, a number would be assigned, otherwise 0 is random.
        orderedTileList[18].GetComponent<TerrainHex>().AssignTerrainTypeNumber(1); // for beginner map, a number would be assigned, otherwise 0 is random.

        desertHex = orderedTileList[9];

        AssignTerrainDiceNumberBeginner();
    }

    // assigns the main dice roll number for the tile. RANDOMLY assign this.
    // take a number from the list, remove
    // possible numbers include
    /*
    x1 - 2
    x2 - 3
    x2 - 4
    x2 - 5
    x2 - 6
    x2 - 8
    x2 - 9
    x2 - 10
    x2 - 11
    x1 - 12
    */

    /*number of each terrain
 *  x1 - desert
 *  x4 - pasture
 *  x4 - field
 *  x4 - forest
 *  x3 - ore
 *  x3 - clay
 * 
 * */

    // assigns a dice number to each hex.
    void AssignTerrainDiceNumber()
{
        List<GameObject> tileNumberAssignment = new List<GameObject>();
        List<int> numberList = new List<int>();
        List<int> numberListTerrain = new List<int>();

        foreach (GameObject tile in tileList)
        {
            tileNumberAssignment.Add(tile);
        }

        for (int i = 0; i < 19; i++)
        {
            numberList.Add(i);
        }


        /*number of each terrain
     *  0 - desert
     *  1, 2, 3, 4 - pasture
     *  5, 6, 7, 8 - field
     *  9, 10, 11, 12 - forest
     *  13, 14, 15 - ore
     *  16, 17, 18 - clay
     * 
     * */

        for (int i = 1; i < 19; i++)
        {
            numberListTerrain.Add(i);
        }



        // assign DESERT
        int random10 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random10);
        tileList[random10].GetComponent<TerrainHex>().AssignDesertTile();
        tileList[random10].GetComponent<TerrainHex>().AssignDiceNumber(7);
        desertHex = tileList[random10];
        Debug.Log("Assigned Desert Tile");





        int random = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random);

        int randomTerrain = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain);

        tileList[random].GetComponent<TerrainHex>().AssignDiceNumber(2);
        tileList[random].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain);

        //  assign 2
        int random2 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random2);

        int randomTerrain2 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain2);

        tileList[random2].GetComponent<TerrainHex>().AssignDiceNumber(3);
        tileList[random2].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain2);


        int random3 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random3);

        int randomTerrain3 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain3);

        tileList[random3].GetComponent<TerrainHex>().AssignDiceNumber(3);
        tileList[random3].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain3);



        // assign 4
        int random4 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random4);

        int randomTerrain4 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain4);

        tileList[random4].GetComponent<TerrainHex>().AssignDiceNumber(4);
        tileList[random4].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain4);


        int random5 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random5);

        int randomTerrain5 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain5);

        tileList[random5].GetComponent<TerrainHex>().AssignDiceNumber(4);
        tileList[random5].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain5);


        // assign 5
        int random6 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random6);

        int randomTerrain6 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain6);

        tileList[random6].GetComponent<TerrainHex>().AssignDiceNumber(5);
        tileList[random6].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain6);


        int random7 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random7);

        int randomTerrain7 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain7);

        tileList[random7].GetComponent<TerrainHex>().AssignDiceNumber(5);
        tileList[random7].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain7);


        // assign 6
        int random8 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random8);

        int randomTerrain8 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain8);

        tileList[random8].GetComponent<TerrainHex>().AssignDiceNumber(6);
        tileList[random8].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain8);


        int random9 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random9);


        int randomTerrain9 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain9);

        tileList[random9].GetComponent<TerrainHex>().AssignDiceNumber(6);
        tileList[random9].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain9);




        // assign 8
        int random11 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random11);

        int randomTerrain11 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain11);

        tileList[random11].GetComponent<TerrainHex>().AssignDiceNumber(8);
        tileList[random11].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain11);


        int random12 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random12);

        int randomTerrain12 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain12);

        tileList[random12].GetComponent<TerrainHex>().AssignDiceNumber(8);
        tileList[random12].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain12);


        // assign 9
        int random13 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random13);

        int randomTerrain13 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain13);

        tileList[random13].GetComponent<TerrainHex>().AssignDiceNumber(9);
        tileList[random13].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain13);


        int random14 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random14);

        int randomTerrain14 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain14);

        tileList[random14].GetComponent<TerrainHex>().AssignDiceNumber(9);
        tileList[random14].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain14);


        // assign 10
        int random15 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random15);

        int randomTerrain15 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain15);

        tileList[random15].GetComponent<TerrainHex>().AssignDiceNumber(10);
        tileList[random15].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain15);


        int random16 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random16);

        int randomTerrain16 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain16);

        tileList[random16].GetComponent<TerrainHex>().AssignDiceNumber(10);
        tileList[random16].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain16);


        // assign 11

        int random17 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random17);

        int randomTerrain17 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain17);

        tileList[random17].GetComponent<TerrainHex>().AssignDiceNumber(11);
        tileList[random17].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain17);


        int random18 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random18);

        int randomTerrain18 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain18);

        tileList[random18].GetComponent<TerrainHex>().AssignDiceNumber(11);
        tileList[random18].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain18);


        // assign 12

        int random19 = numberList[Random.Range(0, numberList.Count)];
        numberList.Remove(random19);

        int randomTerrain19 = numberListTerrain[Random.Range(0, numberListTerrain.Count)];
        numberListTerrain.Remove(randomTerrain19);

        tileList[random19].GetComponent<TerrainHex>().AssignDiceNumber(12);
        tileList[random19].GetComponent<TerrainHex>().AssignTerrainTypeNumber(randomTerrain19);
    }

    // assigns a dice number to each ordered hex.
    public void AssignTerrainDiceNumberBeginner()
    {
        orderedTileList[0].GetComponent<TerrainHex>().AssignDiceNumber(10);
        orderedTileList[1].GetComponent<TerrainHex>().AssignDiceNumber(2);
        orderedTileList[2].GetComponent<TerrainHex>().AssignDiceNumber(9);
        orderedTileList[3].GetComponent<TerrainHex>().AssignDiceNumber(12);
        orderedTileList[4].GetComponent<TerrainHex>().AssignDiceNumber(6);
        orderedTileList[5].GetComponent<TerrainHex>().AssignDiceNumber(4);
        orderedTileList[6].GetComponent<TerrainHex>().AssignDiceNumber(10);
        orderedTileList[7].GetComponent<TerrainHex>().AssignDiceNumber(9);
        orderedTileList[8].GetComponent<TerrainHex>().AssignDiceNumber(11);
        orderedTileList[9].GetComponent<TerrainHex>().AssignDiceNumber(7);
        orderedTileList[10].GetComponent<TerrainHex>().AssignDiceNumber(3);
        orderedTileList[11].GetComponent<TerrainHex>().AssignDiceNumber(8);
        orderedTileList[12].GetComponent<TerrainHex>().AssignDiceNumber(8);
        orderedTileList[13].GetComponent<TerrainHex>().AssignDiceNumber(3);
        orderedTileList[14].GetComponent<TerrainHex>().AssignDiceNumber(4);
        orderedTileList[15].GetComponent<TerrainHex>().AssignDiceNumber(5);
        orderedTileList[16].GetComponent<TerrainHex>().AssignDiceNumber(5);
        orderedTileList[17].GetComponent<TerrainHex>().AssignDiceNumber(6);
        orderedTileList[18].GetComponent<TerrainHex>().AssignDiceNumber(11);
    }
}