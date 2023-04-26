using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TerrainHex : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Other Scripts")]
    private TerrainAssigner terrainAssigner;
    private TurnManager turnManager;
    private Robber robber;
    private WarningText warningText;

    [Header("Ints")]
    public int terrainDiceNumber;
    private int terrainTypeNumber;

    [Header("Bools")]
    public bool robberActivated;
    public bool robberLocationSelected;
    public bool isDesert;
    public bool robberBlocked;

    public Terrain terrain;

    [Header("Adjacent Settlements")]
    public List<GameObject> adjacentSettlements;

    [Header("GameObjects")]
    public GameObject hexImage;
    public GameObject terrainNumberObject;
    private GameObject terrainHexCircle;

    [Header("Terrain Colors")]
    [SerializeField] private Color hoverOverColour;
    [SerializeField] private Color origColour;
    [SerializeField] private Color selectedColour;

    [Header("Hex Image")]
    [SerializeField] private Sprite desertSprite;
    [SerializeField] private Sprite forestSprite;
    [SerializeField] private Sprite fieldSprite;
    [SerializeField] private Sprite hillsSprite;
    [SerializeField] private Sprite mountainsSprite;
    [SerializeField] private Sprite pastureSprite;

    public TextMeshProUGUI pip;

    public int placeOnBoardNumber;

    public enum Terrain
    {
        Desert,
        lumber,
        wool,
        brick,
        grain,
        ore
    }


    void Awake()
    {
        FindScripts();
        AddToList();
        isDesert = false;

        terrainHexCircle = this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject;

        terrainHexCircle.SetActive(true);
        terrainNumberObject.SetActive(true);
    }

    // Finds the other scripts needed for this script.
    void FindScripts()
    {
        terrainAssigner = GameObject.Find("TileHolder").GetComponent<TerrainAssigner>();
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
    }

    // Adds this hex to the tile lists.
    void AddToList()
    {
        terrainAssigner.tileList.Add(this.gameObject);
        terrainAssigner.tileNoDesertList.Add(this.gameObject);
    }

    // Assigns the tile's correct hex.
    public void AssignTile(int terrainType)
    {
        if (terrainType == 0)
        {
            if (terrain == Terrain.lumber)
            {
                hexImage.GetComponent<Image>().sprite = forestSprite;
            }
            if (terrain == Terrain.Desert)
            {
                hexImage.GetComponent<Image>().sprite = desertSprite;
                isDesert = true;
                terrainAssigner.tileNoDesertList.Remove(this.gameObject);
            }
            if (terrain == Terrain.wool)
            {
                hexImage.GetComponent<Image>().sprite = pastureSprite;
            }
            if (terrain == Terrain.brick)
            {
                hexImage.GetComponent<Image>().sprite = hillsSprite;
            }
            if (terrain == Terrain.ore)
            {
                hexImage.GetComponent<Image>().sprite = mountainsSprite;
            }
            if (terrain == Terrain.grain)
            {
                hexImage.GetComponent<Image>().sprite = fieldSprite;
            }
        }
    }

    // Assigns the tile's dice number.
    public void AssignDiceNumber(int number)
    {
        terrainDiceNumber = number;
        terrainNumberObject.GetComponent<TextMeshProUGUI>().text = terrainDiceNumber.ToString();

        // sort pips. Give red color if 6 or 8.
        switch (number)
        {
            case 2:
                SetPips(1);
                break;
            case 3:
                SetPips(2);
                break;
            case 4:
                SetPips(3);
                break;
            case 5:
                SetPips(4);
                break;
            case 6:
                SetPips(5);
                terrainNumberObject.GetComponent<TextMeshProUGUI>().color = Color.red;
                break;
            case 7:
                // give no pips
                SetPips(0);
                break;
            case 8:
                SetPips(5);
                terrainNumberObject.GetComponent<TextMeshProUGUI>().color = Color.red;
                break;
            case 9:
                SetPips(4);
                break;
            case 10:
                SetPips(3);
                break;
            case 11:
                SetPips(2);
                break;
            case 12:
                SetPips(1);
                break;
        
        
        }

    }

    // Sets the number of pips below a number.
    public void SetPips(int numberOfPips)
    {
        switch(numberOfPips)
        {
            case 0:
                pip.text = "";
                break;
            case 1:
                pip.text = ".";
                break;
            case 2:
                pip.text = "..";
                break;
            case 3:
                pip.text = "...";
                break;
            case 4:
                pip.text = "....";
                break;
            case 5:
                pip.text = ".....";
                break;
        }
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
    // Assigns the desert tile and characteristics to a hex.

    public void AssignDesertTile()
    {
        Debug.Log("Assigning Desert");
        terrain = Terrain.Desert;

        // desert hex has no terrain number visible.
        terrainHexCircle.SetActive(false);
        terrainNumberObject.SetActive(false);

        AssignTile(0);
        return;

    }


    // Assigns the tile's terrain type number.
    public void AssignTerrainTypeNumber(int number)
    {
        terrainTypeNumber = number;

        if (number == 0)
        {
            terrain = Terrain.Desert;
            AssignTile(0);
            isDesert = true;
            return;
        }

        if (number == 1 || number == 2 || number ==  3 || number == 4)
        {
            terrain = Terrain.wool;
            AssignTile(0);
            isDesert = false;
            return;
        }
        if (number == 5 || number == 6 || number == 7 || number == 8)
        {
            terrain = Terrain.grain;
            AssignTile(0);
            isDesert = false;
            return;
        }
        if (number == 9 || number == 10 || number == 11 || number == 12)
        {
            terrain = Terrain.lumber;
            AssignTile(0);
            isDesert = false;
            return;
        }
        if (number == 13 || number == 14 || number == 15)
        {
            terrain = Terrain.ore;
            AssignTile(0);
            isDesert = false;
            return;
        }
        if (number == 16 || number == 17 || number == 18)
        {
            terrain = Terrain.brick;
            AssignTile(0);
            isDesert = false;
            return;
        }



    }

    // terrain hex interaction for when the robber is activated
    public void UnselectHex()
    {
        robberLocationSelected = false;
        hexImage.GetComponent<Image>().color = origColour;
    }

    // on mouse down, moves the robber.
    private void OnMouseDown()
    {
        if (robberActivated)
        {
            if (robber.occupiedHex != this.gameObject)
            {

                terrainAssigner.UnselectAllHex();
                // get the hex image component
                GameObject hexImage = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
                hexImage.GetComponent<Image>().color = selectedColour;
                robberLocationSelected = true;
                terrainAssigner.selectedRobberHex = this.gameObject;
                robberBlocked = true;

                // if hex selected is NOT current robber position.


                robber.robberPositionSelected = true;
            }
            else
            {
                StartCoroutine(warningText.WarningTextBox(("Robber must be moved to new position")));
            }

        }
    }

    // When mouse is no longer hovering over a hex when robber is activated.
    private void OnMouseExit()
    {
        if (robberActivated && !robberLocationSelected)
        {
            GameObject hexImage = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
            hexImage.GetComponent<Image>().color = origColour;
            robberBlocked = false;
        }
    }

    // When mouse hovering over a hex when robber is activated.
    private void OnMouseEnter()
    {
        if (robberActivated && !robberLocationSelected)
        {
            GameObject hexImage = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
            hexImage.GetComponent<Image>().color = hoverOverColour;
            robberBlocked = false;
        }
    }

}
