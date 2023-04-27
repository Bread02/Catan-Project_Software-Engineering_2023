using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/**
 * This script controls the overall turn taking functionality of the game. It also sets up the game when loaded.
 *
 * @author Altair, Ben
 * @version 26/04/2023
 */
public class TurnManager : MonoBehaviour
{
    [Header("Other Scripts")]
    private DiceRolling diceRolling;
    private TradeManager tradeManager;
    private MakeTrade makeTrade;
    private HelpText helpText;
    private WinConditions winConditions;
    private PlayerDataTrack playerDataTrack;
    private TerrainAssigner terrainAssigner;

    [Header("Stat BG to Light Up on Turn")]
    public GameObject p1StatBG;
    public GameObject p2StatBG;
    public GameObject p3StatBG;
    public GameObject p4StatBG;

    [Header("Ints")]
    public int playerToPlay;
    public int playersToSpawn;

    [Header("Lists")]
    public List<PlayerManager> playerList = new List<PlayerManager>();
    public List<GameObject> playerDropZones = new List<GameObject>();

    [Header("Bools")]
    public bool finishedDiceRolling;
    public bool isTrading;
    private bool cardDiscardingComplete;
    bool playerDiscarded = false;
    public bool hasUsedDevCardThisTurn;

    public PlayerManager playerWhoRolledSeven;

    // prevents dice rolling
    public bool doNotRoll;
    public bool allPlayersBuiltStart;
    private bool playerOneBuilt;

    public TextMeshProUGUI playerTurnText;

    [Header("Start  Up Bools")]
    public bool isSetUpPhase;
    public bool isSetUpPart2;

    // if this is toggled. GAME ENDS on final player's turn.
    [Header("Abridged Bools")]
    private bool abridgedFinalTurn;
    private bool finalTurn;

    [Header("Lists of All Objects")]
    public List<GameObject> allSettlementBuildSites;
    public List<GameObject> allRoadBuildSites;

    public int turnNumber, roadAndSettlementPlacedSetUpCounter;

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
    public GameObject toggleCardsInPlayerHand;
    public GameObject AIHandPrefab; 

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

    [Header("Turn Time Limit")]
    public float turnTimeLimit;
    public float currentTimeLimit;
    public TextMeshProUGUI turnTimeLimitText;
    public GameObject turnTimeLimitObject;

    public bool turnTimeLimitEnforced;

    // Start is called before the first frame update
    // instantiate correct number of player managers.
    // instantiate players by their correct name.

  // pls clean up this script, awake should be for toggling methods.
    void Awake()
    {
        // false until proven otherwise
        turnTimeLimitEnforced = false;

        FindObjects();
        SetStartingBools();

        // when starting the game, the first player has not finished turn.
        HideEndTurnButton();

        playerToPlay = 1;
        playersToSpawn = 4; // default is 4 players to spawn.

        int playerNumber = 1;

        for (int i = 1; i <= playersToSpawn; i++)
        {
            InstantiatePlayerHandLocations(i);
            playerList.Add(playerHandPrefab.GetComponent<PlayerManager>());
            //    playerHandPrefab.GetComponent<PlayerManager>().PlayerColor(;
            playerList[i - 1].SetPlayerNumber(playerNumber);
            playerNumber++;
        }

        AssignPlayerToColor(null); // COMMENT THIS OUT IF SETUPO GAME FINAL IS USED
        DisplayCurrentPlayerTurn();

        SetAllPlayerPositions();

        //Add player dropZones to playerDropZones list
        AddPlayerDropZonesToList();
    }

    // sets the starting booleans for the game.
    private void SetStartingBools()
    {
        abridgedFinalTurn = false;
        doNotRoll = true;
        allPlayersBuiltStart = false;
        finishedDiceRolling = false;
        isTrading = true;
        donateCardsObject.SetActive(false);
    }

    private void TurnTimer()
    {
        currentTimeLimit -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(currentTimeLimit / 60);
        float seconds = Mathf.FloorToInt(currentTimeLimit % 60);


        turnTimeLimitText.text = minutes.ToString() + ":" + seconds.ToString();

        if (currentTimeLimit <= 0)
        {
            EndPlayerTurn();
           
        }
    }

    private void StartTurnTimer()
    {
        currentTimeLimit = turnTimeLimit;

        // start turn timer.
    }


    #region  SETUP FINAL VERSION. KEEP DISABLED UNTIL NEEDED.
    // In FINAL VERSION, this will be used and NOT awake method.
    // this is triggered by the game data track to setup the game PROPERLY with the correct number of players.
    // ONLY UNCOMMENT THIS IF YOU PLAN TO USE THIS INSTEAD AND FOR THE FINAL VERSION

    public void SetupGameFinal(int numberOfPlayers, List<int> colorInt, bool beginnerMap, int timePerTurn)
    {
        turnTimeLimit = timePerTurn;

        turnTimeLimitObject.SetActive(false);

        if(turnTimeLimit != 0)
        {
            // setup timer
            turnTimeLimitObject.SetActive(true);
            turnTimeLimitEnforced = true;
        }

        Debug.Log("Setup final");
        FindObjects();
        SetStartingBools();

        // when starting the game, the first player has not finished turn.
        HideEndTurnButton();


        playerToPlay = 1;
        playersToSpawn = numberOfPlayers;

        int playerNumber = 1;

        for (int i = 1; i <= playersToSpawn; i++)
        {
            InstantiatePlayerHandLocations(i);
            playerList.Add(playerHandPrefab.GetComponent<PlayerManager>());
            //    playerHandPrefab.GetComponent<PlayerManager>().PlayerColor(;
            playerList[i - 1].SetPlayerNumber(playerNumber);
            playerNumber++;
        }



        AssignPlayerToColor(colorInt);

        DisplayCurrentPlayerTurn();

        SetAllPlayerPositions();

        if(beginnerMap)
        {
            terrainAssigner.AssignTilesBeginner();
        }
        else
        {
            terrainAssigner.AssignTilesRandom();
        }

        //Add player dropZones to playerDropZones list
        playerDropZones.Add(player1DropZone);
        playerDropZones.Add(player2DropZone);
        playerDropZones.Add(player3DropZone);
        playerDropZones.Add(player4DropZone);
    }
    
    
    #endregion


    /*
    For testing purposes
    Blue = Player 1
    Orange = player 2
    Red = player 3
    White = player 4
    */
    // assigns colors to player based on the inserted list.
    // If list is null, then the turnmanager has not communicated with the playerdatatrack.
    // If list is not null, playerdatatrack has fed data from the previous scene into here.
    private void AssignPlayerToColor(List<int> playerColor)
    {
        if(playerColor != null)
        {
            playerList[0].PlayerColor(playerColor[0]);
            playerList[1].PlayerColor(playerColor[1]);
            playerList[2].PlayerColor(playerColor[2]);
            playerList[3].PlayerColor(playerColor[3]);
            return;
        }
        else
        {
            // default
            playerList[0].PlayerColor(0);
            playerList[1].PlayerColor(1);
            playerList[2].PlayerColor(2);
            playerList[3].PlayerColor(3);
        }

    }

    private void Start()
    {
        finalTurn = false;
        abridgedFinalTurn = false;
        loseCardsObject.SetActive(false);
        hasUsedDevCardThisTurn = false;
    }

    // if dice rolling is false, and trade is false, show button.
    // REMOVE THIS ON FINAL VERSION, NOT NEEDED.
     void Update()
    {
        /*
        if (finishedDiceRolling && !isTrading)
        {
            DisplayEndTurnButton();
        }
        else
        {
            HideEndTurnButton();
        }
        */
        // force next player turn
        // REMOVE THIS ON FINAL VERSION.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EndPlayerTurn();
        }
        if(turnTimeLimitEnforced)
        {
            TurnTimer();
        }


    }

    // Instantiates the player hand locations with the given playernumber.
    public void InstantiatePlayerHandLocations(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                playerHandPrefab = Instantiate(playerHandPrefab, player1SpawnPosition);
                break;
            case 2:
            /*
            *   FOR TESTING
            */
                AIHandPrefab = Instantiate(AIHandPrefab, player2SpawnPosition);
                //playerHandPrefab = Instantiate(playerHandPrefab, player2SpawnPosition);
                break;
            case 3:
                playerHandPrefab = Instantiate(playerHandPrefab, player3SpawnPosition);
                break;
            case 4:
                playerHandPrefab = Instantiate(playerHandPrefab, player4SpawnPosition);
                break;
        }
    }

    // before ANY dice rolling can commence, players must all select the road and settlement locations they want to start at.
    public void SetAllPlayerPositions()
    {
        StartCoroutine(WaitForPlayerBuild());
    }

    // player builds 2 roads and 2 settlements when they start.
    IEnumerator WaitForPlayerBuild()
    {
        toggleCardsInPlayerHand.SetActive(false);
        isSetUpPhase = true;
        bool isRoundOne = true;
        
        for (int i = 0; i < playersToSpawn; i++)
        {
            string helpText1 = "Build your first settlement and adjacent road.";
            StartCoroutine(helpText.HelpTextBox(helpText1));
            helpText.SetHelpTextBoxActive();

            tradeManager.inTradeMode = true;
            isTrading = true;
            
            makeTrade.SetSettlementBought(true);
            makeTrade.SetRoadBought(true);
            yield return new WaitUntil(() => roadAndSettlementPlacedSetUpCounter == 2);
            roadAndSettlementPlacedSetUpCounter = 0;
            EndPlayerTurn();
        }

        //Must add cards in reverse order
        for(int i = playersToSpawn; i > 0; i--)
        {
            isSetUpPart2 = true;
            ForcePlayerTurn(playerList[i - 1]);
          //  playerTurnText.text = "Turn: Player " + playerToPlay.ToString();
            string helpText2 = "Build your second settlement and adjacent road.";
            StartCoroutine(helpText.HelpTextBox(helpText2));
            helpText.SetHelpTextBoxActive();

            tradeManager.inTradeMode = true;
            isTrading = true;

            makeTrade.SetSettlementBought(true);
            makeTrade.SetRoadBought(true);
            yield return new WaitUntil(() => roadAndSettlementPlacedSetUpCounter == 2);
            roadAndSettlementPlacedSetUpCounter = 0;
            ReturnCurrentPlayer().CheckIfNewCardsReverse();

            if (ReturnCurrentPlayer().playerNumber != 1)
            {
                EndPlayerTurn();
            }
        }

        Debug.Log("Finished adding cards in reverse");
        tradeManager.inTradeMode = false;
        isTrading = false;
        helpText.SetHelpTextBoxOff();
        makeTrade.SetSettlementBought(false);
        makeTrade.SetRoadBought(false);
        makeTrade.SetIsSetUpPhase(false);
        allPlayersBuiltStart = true;
        doNotRoll = false;
        isSetUpPhase = false;
        Debug.Log("Can now roll, new turn started. Finished waitforplayerbuild");
        toggleCardsInPlayerHand.SetActive(true);
    }

    // returns the playerManager by the playernumber inserted in.
    public PlayerManager ReturnPlayerManagerByNumber(int number)
    {
        return playerList[number - 1];
    }

    //For setup phase ONLY
    public void EndPlayerTurnReverseOrder()
    {
        finishedDiceRolling = false;

        turnNumber++;

        if (playerToPlay >= playerList.Count)
        {
            playerToPlay = 1;
        }
        else
        {
            playerToPlay++;
        }

        playerTurnText.text = "Turn: Player " + playerToPlay.ToString();

        DisplayCurrentPlayerTurn();
        Debug.Log("Player to play: " + playerToPlay);
    }


    // returns the current player who's turn it is.
    public PlayerManager ReturnCurrentPlayer()
    {
        //    Debug.Log("player to play: " + playerToPlay);
          return playerList[playerToPlay - 1];
     //   return playerList[playerToPlay];

    }

    // Ends the player's turn.
    public void EndPlayerTurn()
    {
        //Resets hasUsedDevCard
        hasUsedDevCardThisTurn = false;

        //Ensures that if player whose turn it is has their development cards shown, the cards are switched back to showing resource cards
        ReturnCurrentPlayer().ShowResourceCardsOnly();

        // if set on final turn, check if the game ends
        if(abridgedFinalTurn)
        {
            AbridgedFinalPlayersTurn();
        }


        finishedDiceRolling = false;

        turnNumber++;

        if(playerToPlay >= playerList.Count)
        {
            playerToPlay = 1;
        }
        else
        {
            playerToPlay++;
        }

        // reset dice
        if (allPlayersBuiltStart)
        {
            diceRolling.ResetDice();
        }


        if (playerToPlay > playersToSpawn)
        {
            playerToPlay = 1;
        }
        DisplayCurrentPlayerTurn();
        if (turnTimeLimitEnforced)
        {
            StartTurnTimer();
        }
        Debug.Log("Player to play: " + playerToPlay);
    }

    // Forces the given player's turn to play.
    public void ForcePlayerTurn(PlayerManager playerManagerTurn)
    {
        playerToPlay = playerManagerTurn.playerNumber;
        DisplayCurrentPlayerTurn();
        Debug.Log("Player to play: " + playerToPlay);
    }

    // adds the player drop zones to the list
    private void AddPlayerDropZonesToList()
    {
        playerDropZones.Add(player1DropZone);
        playerDropZones.Add(player2DropZone);
        playerDropZones.Add(player3DropZone);
        playerDropZones.Add(player4DropZone);
    }

    // Displays the current player's turn by ensuring the correct camera is displayed.
    public void DisplayCurrentPlayerTurn()
    {
        // display correct camera
        switch (playerToPlay)
        {
            case 1:
                player1Camera.enabled = true;
                player2Camera.enabled = false;
                player3Camera.enabled = false;
                player4Camera.enabled = false;

                // highlight stat bg
                p1StatBG.SetActive(true);
                p2StatBG.SetActive(false);
                p3StatBG.SetActive(false);
                p4StatBG.SetActive(false);
                break;
            case 2:
                player1Camera.enabled = false;
                player2Camera.enabled = true;
                player3Camera.enabled = false;
                player4Camera.enabled = false;

                // highlight stat bg
                p1StatBG.SetActive(false);
                p2StatBG.SetActive(true);
                p3StatBG.SetActive(false);
                p4StatBG.SetActive(false);
                break;
            case 3:
                player1Camera.enabled = false;
                player2Camera.enabled = false;
                player3Camera.enabled = true;
                player4Camera.enabled = false;

                // highlight stat bg
                p1StatBG.SetActive(false);
                p2StatBG.SetActive(false);
                p3StatBG.SetActive(true);
                p4StatBG.SetActive(false);
                break;
            case 4:
                player1Camera.enabled = false;
                player2Camera.enabled = false;
                player3Camera.enabled = false;
                player4Camera.enabled = true;

                // highlight stat bg
                p1StatBG.SetActive(false);
                p2StatBG.SetActive(false);
                p3StatBG.SetActive(false);
                p4StatBG.SetActive(true);
                break;
            default:
                Debug.LogError("ERROR. CANNOT FIND CORRECT CAMERA FOR PLAYER");
                break;
        }

        // highlight player's stat BG


    }

    // to end the turn, the player must not be in trade mode and must have rolled dice.
    #region Turn  Button
    // displays the end turn button the player can interract with
    public void DisplayEndTurnButton()
    {
        endTurnButton.SetActive(true);
    }

    // hides the end turn button fropm the player.
    public void HideEndTurnButton()
    {
        endTurnButton.SetActive(false);
    }
    #endregion

    #region ABRIDGED MODE
    // sets the abridged mode final turn.
    public void AbridgedFinalPlayersTurn()
    {

        Debug.Log("Final turn. Abridge check:");
        Debug.Log("Current player:" + ReturnCurrentPlayer().playerNumber);
        Debug.Log("playerstospawn" + playersToSpawn);


        if (ReturnCurrentPlayer().playerNumber == playersToSpawn)
        {
            Debug.Log("Final turn. On Final Player");
            // final turn
            finalTurn = true;

            playerDataTrack.VictoryPoints();
            winConditions.TriggerVictory(playerDataTrack.player1stPlace);
            playerDataTrack.PlayerStatToVictoryScreen(playerDataTrack.player1stPlace.playerNumber);

        }
        // if on player 4, and play 4 clicks end turn. Game will end
    }

// sets the 
    public void SetAbridgedFinalTurn()
    {
        Debug.Log("Final turn now set");
        abridgedFinalTurn = true;
    }

    #endregion

    #region  Find  Objects
    // finds the objects and scripts needed for this script.
    private void FindObjects()
    {
        diceRolling = GameObject.Find("DiceRolling").GetComponent<DiceRolling>();
        tradeManager = GameObject.Find("THE_TRADE_GUI").GetComponent<TradeManager>();
        makeTrade = GameObject.Find("EMPTY_OBJ_MakeTrade").GetComponent<MakeTrade>();
        helpText = GameObject.Find("HelpTextBox").GetComponent<HelpText>();
        winConditions = GameObject.Find("WinConditionsAndScreen").GetComponent<WinConditions>();
        terrainAssigner = GameObject.Find("TileHolder").GetComponent<TerrainAssigner>();

        try
        {
            playerDataTrack = GameObject.Find("PlayerDataTrack").GetComponent<PlayerDataTrack>();
            
        }
        catch (System.Exception)
        {

            Debug.Log("Player data track not found in scene. Will randomize tiles.");
            terrainAssigner.AssignTilesRandom();
        }
    }
    #endregion

    #region AI

    private bool isAI(PlayerManager playerManager){
        return (playerManager.AIScript != null);
    }


    #endregion
}
