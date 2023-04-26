using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Robber : MonoBehaviour
{
    // Start is called before the first frame update
    // After tiles have spawned and the board is setup, place the robber on the desert hex

    [Header("Other Scripts")]
    private TerrainAssigner terrainAssigner;
    private TurnManager turnManager; 
    private WarningText warningText;
    private StealCards stealCards;
    private DiscardHalfOfCards discardHalfOfCards;

    [Header("Game Objects")]
    [SerializeField] private GameObject robberTriggerCanvas;
    private GameObject desertHex;
    public GameObject occupiedHex;
    private GameObject bankMangObj;
    [SerializeField] private GameObject endTurnButton;

    [Header("Robber Notifications")]
    public string robberActivatedRollString = "7 rolled! Robber Activated!\n\nMove the robber to a new location.";
    public string robberActivatedKnightString = "Knight card used! Robber Activated!\n\nMove the robber to a new location.";
    public TextMeshProUGUI robberActivatedText;


    public bool robberPositionSelected;

    void Start()
    {
        robberPositionSelected = false;
        robberTriggerCanvas.SetActive(false);
        terrainAssigner = GameObject.Find("TileHolder").GetComponent<TerrainAssigner>();
        DelayStart();
        Invoke("DelayStart", 0.01f);
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
        stealCards = GameObject.Find("StealCards").GetComponent<StealCards>();
        discardHalfOfCards = GameObject.Find("DiscardHalfOfCards").GetComponent<DiscardHalfOfCards>();
        bankMangObj = GameObject.Find("THE_BANK");
    }

    void DelayStart()
    {
        desertHex = terrainAssigner.desertHex;
        occupiedHex = desertHex;
        this.gameObject.transform.position = new Vector3(desertHex.transform.position.x + 0.3f, desertHex.transform.position.y + 0.3f, desertHex.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // roll 7 emulate
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Rolling 7");
            discardHalfOfCards.LoseHalfOfCards(turnManager.ReturnCurrentPlayer());
        }

    }


    // if robber is triggered in this method, players MUST DISCARD HALF THEIR CARDS if they have more than 7. Rounding down.
    public void TriggerRobberMovement()
    {
        //Want to hide everything in the scene that a card could interact with - also the end turn button
        //Hides player dropzones
        foreach(GameObject playerDropZone in turnManager.playerDropZones)
        {
            playerDropZone.SetActive(false);
        }
        //Hides bank
        bankMangObj.SetActive(false);
        //Hide end turn button
        endTurnButton.SetActive(false);
        //These will be set to true again in the FinishTheft() method, in StealCards

        terrainAssigner.TriggerRobber();
        robberTriggerCanvas.SetActive(true);
        robberActivatedText.text = robberActivatedRollString.ToString();


        Debug.Log("Triggering robber movement");
      //  turnManager.LoseHalfOfCards();
    }


    // this method changes the text.
    public void TriggerRobberMovementKnight()
    {
        terrainAssigner.TriggerRobber();
        robberTriggerCanvas.SetActive(true);
        robberActivatedText.text = robberActivatedKnightString.ToString();
    }

    // NOTE. PLAYER MUST MOVE THE ROBBER BEFORE TRIGGERING THE END.
    public void TriggerRobberMovementEnd()
    {
        Debug.Log("Ending Robber Movement");
        if (robberPositionSelected)
        {
            GameObject hex = terrainAssigner.selectedRobberHex;
            // if robber is not in same position as previously, allow end. else make an error.
            robberTriggerCanvas.SetActive(false);
            MoveRobber(terrainAssigner.selectedRobberHex);
            terrainAssigner.EndTriggerRobber();

            // now steal card of adjacent player to robber. Check adjacent settlements.
            stealCards.FindAdjacentSettlementPlayers();
        }
        else
        {
            Debug.Log("Robber cannot remain in current position. Move robber");
            StartCoroutine(warningText.WarningTextBox(("Robber cannot remain in current position. Move Robber")));
        }
    }



    public void MoveRobber(GameObject hex)
    {
        Debug.Log("Robber Moved");
        occupiedHex = hex;
        this.gameObject.transform.position = new Vector3(hex.transform.position.x + 0.3f, hex.transform.position.y + 0.3f, hex.transform.position.z);
    }
}
