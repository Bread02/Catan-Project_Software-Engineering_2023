using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TurnManager : MonoBehaviour
{
    [Header("Other Scripts")]
    private DiceRolling diceRolling;
    private TradeManager tradeManager;
    private MakeTrade makeTrade;
    private Robber robber;
    private WarningText warningText;
    private HelpText helpText;

    [Header("Ints")]
    public int playerToPlay;
    public int playersToSpawn;

    public List<PlayerManager> playerList = new List<PlayerManager>();
    public List<GameObject> playerDropZones = new List<GameObject>();

    [Header("Bools")]
    public bool finishedDiceRolling;
    public bool isTrading;
    private bool cardDiscardingComplete;
    bool playerDiscarded = false;

    public PlayerManager playerWhoRolledSeven;

    // prevents dice rolling
    public bool doNotRoll;
    public bool allPlayersBuiltStart;
    private bool playerOneBuilt;

    public TextMeshProUGUI playerTurnText;

    [Header("Lists of All Objects")]
    public List<GameObject> allSettlementBuildSites;
    public List<GameObject> allRoadBuildSites;

    public int turnNumber;

    // player number assigned with color
    public Dictionary<int, string> playerNumberColor;
    public Dictionary<int, string> playerNameNumber;

    [Header("GameObjects")]
    // the first instructions that appear when starting the game
    // this is to aid the player so they know what to do when the game starts.
    public GameObject endTurnButton;
    public GameObject playerHandPrefab;
    public GameObject loseCardsObject;
    public GameObject donateCardsObject;

    [Header("Player Cameras")]
    public Camera player1Camera;
    public Camera player2Camera;
    public Camera player3Camera;
    public Camera player4Camera;

    [Header("Player Hand Spawn Locations")]
    public Transform player1SpawnPosition;
    public Transform player2SpawnPosition;
    public Transform player3SpawnPosition;
    public Transform player4SpawnPosition;

    [Header("Player Hand Spawn Locations")]
    public GameObject player1StealFromButton;
    public GameObject player2StealFromButton;
    public GameObject player3StealFromButton;
    public GameObject player4StealFromButton;

    [Header("Player DropZones")]
    public GameObject player1DropZone;
    public GameObject player2DropZone;
    public GameObject player3DropZone;
    public GameObject player4DropZone;

    // Start is called before the first frame update
    // instantiate correct number of player managers.
    // instantiate players by their correct name.
    void Awake()
    {
        FindObjects();

        donateCardsObject.SetActive(false);

        player1Camera.enabled = true;
        player2Camera.enabled = false;

        doNotRoll = true;
        allPlayersBuiltStart = false;

        finishedDiceRolling = false;
        isTrading = true;
        // when starting the game, the first player has not finished turn.
        HideEndTurnButton();


        playerToPlay = 1;
        playersToSpawn = 4;
        int playerNumber = 1;

        for (int i = 1; i <= playersToSpawn; i++)
        {
            InstantiatePlayerHandLocations(i);
            playerList.Add(playerHandPrefab.GetComponent<PlayerManager>());
            //    playerHandPrefab.GetComponent<PlayerManager>().PlayerColor(;
            playerList[i - 1].SetPlayerNumber(playerNumber);
            playerNumber++;
        }
        AssignPlayerToColor();
        DisplayCurrentPlayerTurn();

        SetAllPlayerPositions();

        //Add player dropZones to playerDropZones list
        playerDropZones.Add(player1DropZone);
        playerDropZones.Add(player2DropZone);
        playerDropZones.Add(player3DropZone);
        playerDropZones.Add(player4DropZone);
    }

    private void Start()
    {
        loseCardsObject.SetActive(false);
    }

    private void FindObjects()
    {
        diceRolling = GameObject.Find("DiceRolling").GetComponent<DiceRolling>();
        tradeManager = GameObject.Find("THE_TRADE_GUI").GetComponent<TradeManager>();
        makeTrade = GameObject.Find("EMPTY_OBJ_MakeTrade").GetComponent<MakeTrade>();
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
        helpText = GameObject.Find("HelpTextBox").GetComponent<HelpText>();
    }

    public void InstantiatePlayerHandLocations(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                playerHandPrefab = Instantiate(playerHandPrefab, player1SpawnPosition);
                break;
            case 2:
                playerHandPrefab = Instantiate(playerHandPrefab, player2SpawnPosition);
                break;
            case 3:
                playerHandPrefab = Instantiate(playerHandPrefab, player3SpawnPosition);
                break;
            case 4:
                playerHandPrefab = Instantiate(playerHandPrefab, player4SpawnPosition);
                break;
        }
    }

    /*
    For testing purposes
    Blue = Player 1
    Orange = player 2
    Red = player 3
    White = player 4

    Final version should allow the player to select their color.
*/

    public void AssignPlayerToColor()
    {
        Debug.Log("Assigning player to color");
        playerNumberColor = new Dictionary<int, string>();
        playerNumberColor.Add(1, "blue");
        playerNumberColor.Add(2, "orange");
        playerNumberColor.Add(3, "red");
        playerNumberColor.Add(4, "white");

        playerList[0].PlayerColor("blue");
        playerList[1].PlayerColor("orange");
        playerList[2].PlayerColor("red");
        playerList[3].PlayerColor("white");

    }

    // before ANY dice rolling can commence, players must all select the road and settlement locations they want to start at.
    public void SetAllPlayerPositions()
    {
        StartCoroutine(WaitForPlayerBuild());

    }

    // player builds 2 roads and 2 settlements when they start.
    IEnumerator WaitForPlayerBuild()
    {
        int turnNumberCount = 1;
        for (int i = 0; i < playersToSpawn; i++)
        {
         //   Debug.Log("Waiting for 1 to build");
            string helpText1 = "Build your first settlement and adjacent road.";
            StartCoroutine(helpText.HelpTextBox(helpText1));
            yield return new WaitUntil(() => !tradeManager.inTradeMode);
            Debug.Log("Player has built first structure, waiting for second");

            string helpText2 = "Build your second settlement and adjacent road.";
            StartCoroutine(helpText.HelpTextBox(helpText2));

            tradeManager.inTradeMode = true;
            isTrading = true;
            helpText.SetHelpTextBoxActive();
            makeTrade.SetSettlementBought(true);
            makeTrade.SetRoadBought(true);
            yield return new WaitUntil(() => !tradeManager.inTradeMode);
            Debug.Log("Now finishing turn");
            EndPlayerTurn();
          //  yield return new WaitUntil(() => turnNumber == turnNumberCount);
            Debug.Log("Resetting start building");
            
            tradeManager.inTradeMode = true;
            isTrading = true;
            helpText.SetHelpTextBoxActive();
            makeTrade.SetSettlementBought(true);
            makeTrade.SetRoadBought(true);
            turnNumberCount++;
        }
        tradeManager.inTradeMode = false;
        isTrading = false;
        helpText.SetHelpTextBoxOff();
        makeTrade.SetSettlementBought(false);
        makeTrade.SetRoadBought(false);
        allPlayersBuiltStart = true;
     //   EndPlayerTurn();
        doNotRoll = false;
        Debug.Log("Can now roll, new turn started. Finished waitforplayerbuild");
    }


    // if dice rolling is false, and trade is false, show button.
    public void Update()
    {
        if(finishedDiceRolling && !isTrading)
        {
            DisplayEndTurnButton();
        }

        // force next player turn
        if(Input.GetKeyDown(KeyCode.Q))
        {
            EndPlayerTurn();
        }

    }


    public PlayerManager ReturnCurrentPlayer()
    {
    //    Debug.Log("player to play: " + playerToPlay);
        return playerList[playerToPlay - 1];
    }

    public void DisplayCurrentPlayerTurn()
    {
     //   playerTurnText.text = "Turn: Player " + playerToPlay.ToString();


        // display correct camera
        switch (playerToPlay)
        {
            case 1:
                player1Camera.enabled = true;
                player2Camera.enabled = false;
                player3Camera.enabled = false;
                player4Camera.enabled = false;
                break;
            case 2:
                player1Camera.enabled = false;
                player2Camera.enabled = true;
                player3Camera.enabled = false;
                player4Camera.enabled = false;
                break;
            case 3:
                player1Camera.enabled = false;
                player2Camera.enabled = false;
                player3Camera.enabled = true;
                player4Camera.enabled = false;

                break;
            case 4:
                player1Camera.enabled = false;
                player2Camera.enabled = false;
                player3Camera.enabled = false;
                player4Camera.enabled = true;
                break;
            default:
                Debug.LogError("ERROR. CANNOT FIND CORRECT CAMERA FOR PLAYER");
                break;
        }

    }

    // to end the turn, the player must not be in trade mode and must have rolled dice.
    public void DisplayEndTurnButton()
    {
        endTurnButton.SetActive(true);
    }

    public void HideEndTurnButton()
    {
        endTurnButton.SetActive(false);
    }

    public void EndPlayerTurn()
    {
        turnNumber++;
        playerToPlay++;

        // reset dice
        if (allPlayersBuiltStart)
        {
            diceRolling.ResetDice();
        }

     //   Debug.Log("Players spawned: " + playersToSpawn);

        if (playerToPlay > playersToSpawn)
        {
            playerToPlay = 1;
        }
        DisplayCurrentPlayerTurn();
        Debug.Log("Player to play: " + playerToPlay);
    }

    public void ForcePlayerTurn(PlayerManager playerManagerTurn)
    {
        playerToPlay = playerManagerTurn.playerNumber;
        DisplayCurrentPlayerTurn();
        Debug.Log("Player to play: " + playerToPlay);
    }
}
