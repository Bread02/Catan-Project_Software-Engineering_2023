using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSettlement : MonoBehaviour
{
    [SerializeField] private Material origColour, takenColour, hoverOverColour;
    public bool settlementTaken;

    [Header("Other Scripts")]
    private TerrainAssigner terrainAssigner;
    private TurnManager turnManager;
    private WarningText warningText;
    private GameObject makeTradeScript;

    // 0 if unclaimed
    public int playerClaimedBy;

    [Header("Adjacent Objects")]
    // needed for robbers
    public List<GameObject> adjacentTiles = new List<GameObject>();

    // a settlemust MUST be joined by an adjacent road (unless it is 1st turn)
    // a settlement MUST NEVER be built adjacent to another settlement.
    public List<GameObject> adjacentRoads = new List<GameObject>();
    public List<GameObject> adjacentSettlements = new List<GameObject>();

    [Header("Player Color")]
    public Material red;
    public Material blue;
    public Material orange;
    public Material white;

    [Header("Contains Port Features")]
    public bool isImprovedHarbor = false;
    public bool isBrickHarbor = false;
    public bool isLumberHarbor = false;
    public bool isWoolHarbor = false;
    public bool isOreHarbor = false;
    public bool isGrainHarbor = false;


    [Header("Audio")]
    public AudioManager audioManager;

    public void Awake()
    {
        FindOtherScripts();
        turnManager.allSettlementBuildSites.Add(this.gameObject);
    }

    private void FindOtherScripts()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        terrainAssigner = GameObject.Find("TileHolder").GetComponent<TerrainAssigner>();
        makeTradeScript = GameObject.FindGameObjectWithTag("MakeTrade");
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
    }

    private void Start()
    {
        settlementTaken = false;
        //game object must be active first so it can be found. Set active as this is the trade GUI and should only show when trade starts.
        AdjacentTiles();
        FindAdjacentSettlements();
        FindAdjacentRoads();
    }


    // this is for BUILDING RULE ADHERENCE
    public void FindAdjacentSettlements()
    {
        foreach(GameObject settleSite in turnManager.allSettlementBuildSites)
        {
            if(this.gameObject != settleSite)
            {
                if (Vector3.Distance(this.gameObject.transform.position, settleSite.transform.position) < 0.7f)
                {
                    adjacentSettlements.Add(settleSite);
                }
            }
            else
            {
                // do nothing
            }
        }
    }

    // this is for BUILDING RULE ADHERENCE
    public void FindAdjacentRoads()
    {
        foreach (GameObject road in turnManager.allRoadBuildSites)
        {
            if (this.gameObject != road)
            {
                if (Vector3.Distance(this.gameObject.transform.position, road.transform.position) < 0.7f)
                {
                    adjacentRoads.Add(road);
                }
            }
            else
            {
                // do nothing
            }
        }
    }


    private void Update()
    {
        if (makeTradeScript.GetComponent<MakeTrade>().GetSettlementBought())
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (!makeTradeScript.GetComponent<MakeTrade>().GetSettlementBought() && !settlementTaken)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    // find tiles adjacent to this settlement
    // find all objects within 1 unit of this settlement
    // all objects within 1 unit are 'adjacent'.
    // this is for ROBBER FUNCTIONALITY
    public void AdjacentTiles()
    {
        foreach(GameObject tile in terrainAssigner.tileList)
        {
            if(Vector3.Distance(this.gameObject.transform.position, tile.gameObject.transform.position) < 1)
            {
                if(!adjacentTiles.Contains(tile))
                {
                    adjacentTiles.Add(tile);
                }
            }
        }
    }


    // check the settlement is not already taken, and check there are no adjacent built settlements.
    private void OnMouseDown()
    {
        foreach(GameObject adjacentSettlement in adjacentSettlements)
        {
            if (adjacentSettlement.GetComponent<ChooseSettlement>().settlementTaken)
            {
                Debug.Log("CANNOT BUILD SETTLEMENT. ADJACENT SETTLEMENT ALREADY CLAIMED");
                StartCoroutine(warningText.WarningTextBox("Cannot build settlement. Adjacent settlement already claimed."));
                return;
            }
        }

        if (!settlementTaken)
        {
         //   this.gameObject.GetComponent<Renderer>().material = takenColour;
            settlementTaken = true;
            playerClaimedBy = turnManager.playerToPlay;

            // add to playerManager of correct player.
            PlayerManager playerManager = turnManager.ReturnCurrentPlayer();
            playerManager.playerOwnedSettlements.Add(this.gameObject);
            string playerColor = playerManager.GetPlayerColor();
       //     Debug.Log("PLayer color: " + playerColor);

            //Play Audio Queue
            audioManager.PlaySound("build");

            // get color of player to turn settlement into
            switch (playerColor)
            {
                case "red":
                    this.gameObject.GetComponent<Renderer>().material = red;
                    break;
                case "blue":
                    this.gameObject.GetComponent<Renderer>().material = blue;
                    break;
                case "white":
                    this.gameObject.GetComponent<Renderer>().material = white;
                    break;
                case "orange":
                    this.gameObject.GetComponent<Renderer>().material = orange;
                    break;
                default:
                    Debug.LogError("Color ISSUE. Unacceptable string for color");
                    this.gameObject.GetComponent<Renderer>().material = takenColour;
                    break;

            }

            makeTradeScript.GetComponent<MakeTrade>().SetSettlementBought(false);

            foreach(GameObject adjacentTile in adjacentTiles)
            {
                adjacentTile.GetComponent<TerrainHex>().adjacentSettlements.Add(this.gameObject);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!settlementTaken)
        {
            this.gameObject.GetComponent<Renderer>().material = origColour;
        }
    }

    private void OnMouseEnter()
    {
        if (!settlementTaken)
        {
            this.gameObject.GetComponent<Renderer>().material = hoverOverColour;
        }
    }
}
