using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
// ONLY ENABLE THIS CLASS IF COMING FROM PLAYMENU TO GAME.

/**
 * This script interacts with the playtogame script in order to grab the relevant data transferred into this scene.
 * With the data in the playtogame, this script setup the required functionality using the player's custom settings they would
 * like for the game, such as enabling players, AI controlled players, player icons, abridged mode, etc.
 *
 * @author Altair Robinson
 * @version 26/04/2023
 */
public class PlayerDataTrack : MonoBehaviour
{
    [Header("ONLY ENABLE THIS CLASS IF COMING FROM PLAYMENU TO GAME.")]
    private PlayToGame playToGame;
    private TurnManager turnManager;
    private AbridgedMode abridgedMode;
    private WinConditions winConditions;

    [Header("Victory Points Text")]
    private int p1VP;
    private int p2VP;
    private int p3VP;
    private int p4VP;

    [Header("Player Stat Board")]
    public GameObject player1Stat;
    public GameObject player2Stat;
    public GameObject player3Stat;
    public GameObject player4Stat;

    public GameObject victoryPlayerStat;

    [Header("Player Victory Points Text")]
    [SerializeField] private TextMeshProUGUI p1VictoryPointsText;
    [SerializeField] private TextMeshProUGUI p2VictoryPointsText;
    [SerializeField] private TextMeshProUGUI p3VictoryPointsText;
    [SerializeField] private TextMeshProUGUI p4VictoryPointsText;

    [SerializeField] private TextMeshProUGUI victoryPlayerVictoryPointsText;

    // players ranked
    public PlayerManager player1stPlace;
    public PlayerManager player2ndPlace;
    public PlayerManager player3rdPlace;
    public PlayerManager player4thPlace;


    [SerializeField] private TextMeshProUGUI p1PlaceText;
    [SerializeField] private TextMeshProUGUI p2PlaceText;
    [SerializeField] private TextMeshProUGUI p3PlaceText;
    [SerializeField] private TextMeshProUGUI p4PlaceText;

    public List<int> playerRankings = new List<int>();

    public PlayerManager playerWithMostVPs;

    [Header("Abridged settings")]
    public int abridgeTime;
    public bool isAbridged;

    // these are IDENTICAL to the playmenu icons due to integer conversion.
    [Header("Player Icons - DO NOT CHANGE")]
    [SerializeField] private Sprite portraitIcon1;
    [SerializeField] private Sprite portraitIcon2;
    [SerializeField] private Sprite portraitIcon3;
    [SerializeField] private Sprite portraitIcon4;
    [SerializeField] private Sprite portraitIcon5;
    [SerializeField] private Sprite portraitIcon6;
    [SerializeField] private Sprite portraitIcon7;
    [SerializeField] private Sprite portraitIcon8;
    [SerializeField] private Sprite portraitIcon9;
    [SerializeField] private Sprite portraitIcon10;

    [Header("Player UI Icons")]
    [Header("Player Color")]
    private Color player1Color;
    private Color player2Color;
    private Color player3Color;
    private Color player4Color;

    private Color victoryPlayerColor;

    // play to game needs this
    [Header("Player Name")]
    private string player1NameUI;
    private string player2NameUI;
    private string player3NameUI;
    private string player4NameUI;

    private string victoryPlayerNameUI;

    [Header("Player Text")]
    [SerializeField] private TextMeshProUGUI player1NameText;
    [SerializeField] private TextMeshProUGUI player2NameText;
    [SerializeField] private TextMeshProUGUI player3NameText;
    [SerializeField] private TextMeshProUGUI player4NameText;

    [SerializeField] private TextMeshProUGUI victoryPlayerNameText;

    // play to game needs this
    [Header("Player Enabled")]
    private bool player1Enabled;
    private bool player2Enabled;
    private bool player3Enabled;
    private bool player4Enabled;

    // play to game needs this
    [Header("Player AI Enabled")]
    private bool player1AI;
    private bool player2AI;
    private bool player3AI;
    private bool player4AI;

    // play to game needs this
    [Header("Player Icons")]
    [SerializeField] private Image player1PortraitIconUI;
    [SerializeField] private Image player2PortraitIconUI;
    [SerializeField] private Image player3PortraitIconUI;
    [SerializeField] private Image player4PortraitIconUI;

    [SerializeField] private Image victoryPlayerPortraitIconUI;

    [Header("AI or Human Icon")]
    [SerializeField] private Sprite playerHumanIcon;
    [SerializeField] private Sprite playerAIIcon;

    [Header("AI or Human Icon Portrait")]
    [SerializeField] private Image player1PlayerAIUI;
    [SerializeField] private Image player2PlayerAIUI;
    [SerializeField] private Image player3PlayerAIUI;
    [SerializeField] private Image player4PlayerAIUI;

    [SerializeField] private Image victoryPlayerAIUI;


    // Start is called before the first frame update
    void Start()
    {
        FindScripts();
        InvokeRepeating("VictoryPoints", 0.5f, 0.5f);
        GrabPlayToGameData();
    }

    // Finds the relevant game objects this script requires.
    private void FindScripts()
    {
        playToGame = GameObject.Find("PlayToGame").GetComponent<PlayToGame>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        abridgedMode = GameObject.Find("AbridgedUI").GetComponent<AbridgedMode>();
        winConditions = GameObject.Find("WinConditionsAndScreen").GetComponent<WinConditions>();
    }


    public void PlayerStatToVictoryScreen(int winningPlayerNumber)
    {
        switch (winningPlayerNumber)
        {
            case 1:
                victoryPlayerNameText.text = player1NameUI;
                victoryPlayerPortraitIconUI = player1PortraitIconUI;
                victoryPlayerAIUI = player1PlayerAIUI;

                // winning is by TRUE victory points. We now reveal who has won.
                victoryPlayerVictoryPointsText.text = player1stPlace.playerTrueVictoryPoints.ToString();
                victoryPlayerStat.transform.GetChild(0).GetComponent<Image>().color = playToGame.Player1Color;
                break;
            case 2:
                victoryPlayerNameText.text = player2NameUI;
                victoryPlayerPortraitIconUI.sprite = player2PortraitIconUI.sprite;
                victoryPlayerAIUI.sprite = player2PlayerAIUI.sprite;
                victoryPlayerVictoryPointsText.text = player1stPlace.playerTrueVictoryPoints.ToString();
                victoryPlayerStat.transform.GetChild(0).GetComponent<Image>().color = playToGame.Player2Color;

                break;
            case 3:
                victoryPlayerNameText.text = player3NameUI;
                victoryPlayerPortraitIconUI.sprite = player3PortraitIconUI.sprite;
                victoryPlayerAIUI.sprite = player3PlayerAIUI.sprite;
                victoryPlayerVictoryPointsText.text = player1stPlace.playerTrueVictoryPoints.ToString();
                victoryPlayerStat.transform.GetChild(0).GetComponent<Image>().color = playToGame.Player3Color;
                break;
            case 4:
                victoryPlayerNameText.text = player4NameUI;
                victoryPlayerPortraitIconUI.sprite = player4PortraitIconUI.sprite;
                victoryPlayerAIUI.sprite = player4PlayerAIUI.sprite;
                victoryPlayerVictoryPointsText.text = player1stPlace.playerTrueVictoryPoints.ToString();
                victoryPlayerStat.transform.GetChild(0).GetComponent<Image>().color = playToGame.Player4Color;
                break;
        }
    }

    // Checks which players were enabled in the playtogame script.
    // Removes player stat card if disabled.
    // Also does not instantiate a player in the turnmanager if disabled.
    public void CheckEnabledPlayers()
    {
        // check enabled players
        player1Enabled = playToGame.Player1Enabled;
        player2Enabled = playToGame.Player2Enabled;
        player3Enabled = playToGame.Player3Enabled;
        player4Enabled = playToGame.Player4Enabled;

        int numberOfPlayers = 0;
        if (player1Enabled)
        {
            numberOfPlayers++;
        }
        if (player2Enabled)
        {
            numberOfPlayers++;
        }
        if (player3Enabled)
        {
            numberOfPlayers++;
        }
        if (player4Enabled)
        {
            numberOfPlayers++;
        }

        if (!player2Enabled)
        {
            player2Stat.SetActive(false);
        }
        if (!player3Enabled)
        {
            player3Stat.SetActive(false);
        }
        if (!player4Enabled)
        {
            player4Stat.SetActive(false);
        }


        CheckColors();
        turnManager.SetupGameFinal(numberOfPlayers, CheckColors(), playToGame.BeginnersModeToggled);
    }

    // Parameters: Insert the icon number of the player, then matches the number to the correct icon.
    private void NumberToIcons(int player1Num, int player2Num, int player3Num, int player4Num)
    {
        switch (player1Num)
        {
            case 0:
                player1PortraitIconUI.sprite = portraitIcon1;
                break;
            case 1:
                player1PortraitIconUI.sprite = portraitIcon2;
                break;
            case 2:
                player1PortraitIconUI.sprite = portraitIcon3;
                break;
            case 3:
                player1PortraitIconUI.sprite = portraitIcon4;
                break;
            case 4:
                player1PortraitIconUI.sprite = portraitIcon5;
                break;
            case 5:
                player1PortraitIconUI.sprite = portraitIcon6;
                break;
            case 6:
                player1PortraitIconUI.sprite = portraitIcon7;
                break;
            case 7:
                player1PortraitIconUI.sprite = portraitIcon8;
                break;
            case 8:
                player1PortraitIconUI.sprite = portraitIcon9;
                break;
            case 9:
                player1PortraitIconUI.sprite = portraitIcon10;
                break;
        }

        switch (player2Num)
        {
            case 0:
                player2PortraitIconUI.sprite = portraitIcon1;
                break;
            case 1:
                player2PortraitIconUI.sprite = portraitIcon2;
                break;
            case 2:
                player2PortraitIconUI.sprite = portraitIcon3;
                break;
            case 3:
                player2PortraitIconUI.sprite = portraitIcon4;
                break;
            case 4:
                player2PortraitIconUI.sprite = portraitIcon5;
                break;
            case 5:
                player2PortraitIconUI.sprite = portraitIcon6;
                break;
            case 6:
                player2PortraitIconUI.sprite = portraitIcon7;
                break;
            case 7:
                player2PortraitIconUI.sprite = portraitIcon8;
                break;
            case 8:
                player2PortraitIconUI.sprite = portraitIcon9;
                break;
            case 9:
                player2PortraitIconUI.sprite = portraitIcon10;
                break;
        }

        switch (player3Num)
        {
            case 0:
                player3PortraitIconUI.sprite = portraitIcon1;
                break;
            case 1:
                player3PortraitIconUI.sprite = portraitIcon2;
                break;
            case 2:
                player3PortraitIconUI.sprite = portraitIcon3;
                break;
            case 3:
                player3PortraitIconUI.sprite = portraitIcon4;
                break;
            case 4:
                player3PortraitIconUI.sprite = portraitIcon5;
                break;
            case 5:
                player3PortraitIconUI.sprite = portraitIcon6;
                break;
            case 6:
                player3PortraitIconUI.sprite = portraitIcon7;
                break;
            case 7:
                player3PortraitIconUI.sprite = portraitIcon8;
                break;
            case 8:
                player3PortraitIconUI.sprite = portraitIcon9;
                break;
            case 9:
                player3PortraitIconUI.sprite = portraitIcon10;
                break;
        }

        switch (player4Num)
        {
            case 0:
                player4PortraitIconUI.sprite = portraitIcon1;
                break;
            case 1:
                player4PortraitIconUI.sprite = portraitIcon2;
                break;
            case 2:
                player4PortraitIconUI.sprite = portraitIcon3;
                break;
            case 3:
                player4PortraitIconUI.sprite = portraitIcon4;
                break;
            case 4:
                player4PortraitIconUI.sprite = portraitIcon5;
                break;
            case 5:
                player4PortraitIconUI.sprite = portraitIcon6;
                break;
            case 6:
                player4PortraitIconUI.sprite = portraitIcon7;
                break;
            case 7:
                player4PortraitIconUI.sprite = portraitIcon8;
                break;
            case 8:
                player4PortraitIconUI.sprite = portraitIcon9;
                break;
            case 9:
                player4PortraitIconUI.sprite = portraitIcon10;
                break;
        }
    }

    // Grabs information from the play to game script to insert into the game.
    public void GrabPlayToGameData()
    {
        int player1PortraitIconUINum = playToGame.Player1PortraitIcon;
        int player2PortraitIconUINum = playToGame.Player2PortraitIcon;
        int player3PortraitIconUINum = playToGame.Player3PortraitIcon;
        int player4PortraitIconUINum = playToGame.Player4PortraitIcon;

        // number to icons
        NumberToIcons(player1PortraitIconUINum, player2PortraitIconUINum, player3PortraitIconUINum, player4PortraitIconUINum);

        // names
        player1NameUI = playToGame.Player1Name;
        player2NameUI = playToGame.Player2Name;
        player3NameUI = playToGame.Player3Name;
        player4NameUI = playToGame.Player4Name;

        player1NameText.text = player1NameUI;
        player2NameText.text = player2NameUI;
        player3NameText.text = player3NameUI;
        player4NameText.text = player4NameUI;

        // check enabled players
        AICheck();
        CheckEnabledPlayers();
        CheckColors();
        CheckGameMode();

    }

    // Checks if the AI is toggled and updates the sprite and turns that player into an AI.
    public void AICheck()
    {
        // AI icon
        player1AI = playToGame.Player1AI;
        player2AI = playToGame.Player2AI;
        player3AI = playToGame.Player3AI;
        player4AI = playToGame.Player4AI;

        if (player1AI)
        {
            player1PlayerAIUI.sprite = playerAIIcon;
        }
        else
        {
            player1PlayerAIUI.sprite = playerHumanIcon;
        }

        if (player2AI)
        {
            player2PlayerAIUI.sprite = playerAIIcon;
        }
        else
        {
            player2PlayerAIUI.sprite = playerHumanIcon;
        }

        if (player3AI)
        {
            player3PlayerAIUI.sprite = playerAIIcon;
        }
        else
        {
            player3PlayerAIUI.sprite = playerHumanIcon;
        }

        if (player4AI)
        {
            player4PlayerAIUI.sprite = playerAIIcon;
        }
        else
        {
            player4PlayerAIUI.sprite = playerHumanIcon;
        }
    }

    // change player stat BG to correct color of player
    public List<int> CheckColors()
    {
        // normal colors can be pulled across as normal
        player1Color = playToGame.Player1Color;
        player2Color = playToGame.Player2Color;
        player3Color = playToGame.Player3Color;
        player4Color = playToGame.Player4Color;


        // child 0 is the BG
        // color list to int
        Debug.Log("Setting stat color BGs");
        player1Stat.transform.GetChild(1).GetComponent<Image>().color = player1Color;
        player2Stat.transform.GetChild(1).GetComponent<Image>().color = player2Color;
        player3Stat.transform.GetChild(1).GetComponent<Image>().color = player3Color;
        player4Stat.transform.GetChild(1).GetComponent<Image>().color = player4Color;

        int player1ColorInt = playToGame.Player1ColorInt;
        int player2ColorInt = playToGame.Player2ColorInt;
        int player3ColorInt = playToGame.Player3ColorInt;
        int player4ColorInt = playToGame.Player4ColorInt;

        // send color info to turnmanager.
        List<int> playerColorList = new List<int>();
        playerColorList.Add(player1ColorInt);
        playerColorList.Add(player2ColorInt);
        playerColorList.Add(player3ColorInt);
        playerColorList.Add(player4ColorInt);

        return playerColorList;
    }

    // Checks the gamemode on the play to game script, if it's abridged mode, setup the abridged mode functionality.
    void CheckGameMode()
    {
        Debug.Log("Checking game mode");
        if (playToGame.GameMode == "abridged")
        {
            // abridged mode on.
            Debug.Log("Game mode is abridged");
            abridgedMode.SetupAbridged(playToGame.TimeLimit);
            return;
        }
        if (playToGame.GameMode == "standard")
        {
            // abridged mode on.
            Debug.Log("Game mode is standard");
            return;
        }

        Debug.Log("ERRROR. game mode is : " + playToGame.GameMode);
    }


    // victory points. Grab from playermanager each player's VP's
    // This is based on a 4 player system, but will work with 3 or 2 players.
    public void VictoryPoints()
    {
        // grab each game manager

        List<PlayerManager> playerManagers = turnManager.playerList;

        // grab all VPs
        int player1Points = playerManagers[0].playerVictoryPoints;
        int player2Points = playerManagers[1].playerVictoryPoints;
        int player3Points = playerManagers[2].playerVictoryPoints;
        int player4Points = playerManagers[3].playerVictoryPoints;

        p1VP = playerManagers[0].playerVictoryPoints;
        p2VP = playerManagers[1].playerVictoryPoints;
        p3VP = playerManagers[2].playerVictoryPoints;
        p4VP = playerManagers[3].playerVictoryPoints;
        // this list can be ordered differently with no issues
        List<PlayerManager> playerManagersRanked = new List<PlayerManager>();
        playerManagersRanked.Add(playerManagers[3]);
        playerManagersRanked.Add(playerManagers[2]);
        playerManagersRanked.Add(playerManagers[1]);
        playerManagersRanked.Add(playerManagers[0]);

        p1VictoryPointsText.text = player1Points.ToString();
        p2VictoryPointsText.text = player2Points.ToString();
        p3VictoryPointsText.text = player3Points.ToString();
        p4VictoryPointsText.text = player4Points.ToString();


        FindWinningPlayer(playerManagersRanked);
    }

    // find who has most VP
    // https://www.geeksforgeeks.org/bubble-sort/
    public void FindWinningPlayer(List<PlayerManager> playerManagersRanked)
    {
        // bubble sort
        for (int i = 0; i < playerManagersRanked.Count - 1; i++)
        {
            for (int j = 0; j < playerManagersRanked.Count - i - 1; j++)
            {
                if (playerManagersRanked[j].playerVictoryPoints > playerManagersRanked[j + 1].playerVictoryPoints)
                {
                    PlayerManager temp = playerManagersRanked[j];
                    playerManagersRanked[j] = playerManagersRanked[j + 1];
                    playerManagersRanked[j + 1] = temp;
                }
            }
        }

        // if abridged mode, whoever order by player number.

        // players ranked
        player1stPlace = playerManagersRanked[playerManagersRanked.Count - 1];
        player2ndPlace = playerManagersRanked[playerManagersRanked.Count - 2];
        player3rdPlace = playerManagersRanked[playerManagersRanked.Count - 3];
        player4thPlace = playerManagersRanked[playerManagersRanked.Count - 4];

        // now put the rankings on the GUI
        if (player1stPlace.playerNumber == 1)
        {
            p1PlaceText.text = "1st";
        }
        if (player1stPlace.playerNumber == 2)
        {
            p2PlaceText.text = "1st";
        }
        if (player1stPlace.playerNumber == 3)
        {
            p3PlaceText.text = "1st";
        }
        if (player1stPlace.playerNumber == 4)
        {
            p4PlaceText.text = "1st";
        }

        //2nd
        if (player2ndPlace.playerNumber == 1)
        {
            p1PlaceText.text = "2nd";
        }
        if (player2ndPlace.playerNumber == 2)
        {
            p2PlaceText.text = "2nd";
        }
        if (player2ndPlace.playerNumber == 3)
        {
            p3PlaceText.text = "2nd";
        }
        if (player2ndPlace.playerNumber == 4)
        {
            p4PlaceText.text = "2nd";
        }

        //3rd
        if (player3rdPlace.playerNumber == 1)
        {
            p1PlaceText.text = "3rd";
        }
        if (player3rdPlace.playerNumber == 2)
        {
            p2PlaceText.text = "3rd";
        }
        if (player3rdPlace.playerNumber == 3)
        {
            p3PlaceText.text = "3rd";
        }
        if (player3rdPlace.playerNumber == 4)
        {
            p4PlaceText.text = "3rd";
        }

        //4th
        if (player4thPlace.playerNumber == 1)
        {
            p1PlaceText.text = "4th";
        }
        if (player4thPlace.playerNumber == 2)
        {
            p2PlaceText.text = "4th";
        }
        if (player4thPlace.playerNumber == 3)
        {
            p3PlaceText.text = "4th";
        }
        if (player4thPlace.playerNumber == 4)
        {
            p4PlaceText.text = "4th";
        }


        // if game is on standard mode. first to 10 true VPs wins.
        if (player1stPlace.playerTrueVictoryPoints >= 10 && playToGame.GameMode == "standard")
        {
            winConditions.TriggerVictory(player1stPlace);
            PlayerStatToVictoryScreen(player1stPlace.playerNumber);
        }
    }
}
