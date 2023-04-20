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
        terrainAssigner = GameObject.Find("TileHolder").GetComponent<TerrainAssigner>();
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
        AddToList();
        isDesert = false;
    }

    void AddToList()
    {
        terrainAssigner.tileList.Add(this.gameObject);
        terrainAssigner.tileNoDesertList.Add(this.gameObject);
    }

    public void AssignTile()
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
    public void AssignDiceNumber(int number)
    {
        terrainDiceNumber = number;
        terrainNumberObject.GetComponent<TextMeshProUGUI>().text = terrainDiceNumber.ToString();
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
    public void AssignDesertTile()
    {

        terrain = Terrain.Desert;

        AssignTile();
        return;

    }


    public void AssignTerrainTypeNumber(int number)
    {
        terrainTypeNumber = number;

        if (number == 1 || number == 2 || number ==  3 || number == 4)
        {
            terrain = Terrain.wool;
            AssignTile();
            isDesert = false;
            return;
        }
        if (number == 5 || number == 6 || number == 7 || number == 8)
        {
            terrain = Terrain.grain;
            AssignTile();
            isDesert = false;
            return;
        }
        if (number == 9 || number == 10 || number == 11 || number == 12)
        {
            terrain = Terrain.lumber;
            AssignTile();
            isDesert = false;
            return;
        }
        if (number == 13 || number == 14 || number == 15)
        {
            terrain = Terrain.ore;
            AssignTile();
            isDesert = false;
            return;
        }
        if (number == 16 || number == 17 || number == 18)
        {
            terrain = Terrain.brick;
            AssignTile();
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

    private void OnMouseExit()
    {
        if (robberActivated && !robberLocationSelected)
        {
            GameObject hexImage = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
            hexImage.GetComponent<Image>().color = origColour;
            robberBlocked = false;
        }
    }

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
