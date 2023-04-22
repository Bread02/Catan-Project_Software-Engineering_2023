using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ONLY ENABLE THIS CLASS IF COMING FROM PLAYMENU TO GAME.
public class PlayerDataTrack : MonoBehaviour
{
    [Header ("ONLY ENABLE THIS CLASS IF COMING FROM PLAYMENU TO GAME.")]

    private PlayToGame playToGame;
    private TurnManager turnManager;
    private AbridgedMode abridgedMode;

    [Header("Player Stat Board")]
    public GameObject player1Stat;
    public GameObject player2Stat;
    public GameObject player3Stat;
    public GameObject player4Stat;

    [Header("Abridged settings")]
    public int abridgeTime;
    public bool isAbridged;

    // these are IDENTICAL to the playmenu icons due to integer conversion.
    [Header("Player Icons")]
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

    // play to game needs this
    [Header("Player Name")]
    private string player1NameUI;
    private string player2NameUI;
    private string player3NameUI;
    private string player4NameUI;

    [Header("Player Text")]
    [SerializeField] private TextMeshProUGUI player1NameText;
    [SerializeField] private TextMeshProUGUI player2NameText;
    [SerializeField] private TextMeshProUGUI player3NameText;
    [SerializeField] private TextMeshProUGUI player4NameText;

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

    [Header("AI or Human Icon")]
    [SerializeField] private Sprite playerHumanIcon;
    [SerializeField] private Sprite playerAIIcon;

    [Header("AI or Human Icon Portrait")]
    [SerializeField] private Image player1PlayerAIUI;
    [SerializeField] private Image player2PlayerAIUI;
    [SerializeField] private Image player3PlayerAIUI;
    [SerializeField] private Image player4PlayerAIUI;

    // Start is called before the first frame update
    void Start()
    {
        playToGame = GameObject.Find("PlayToGame").GetComponent<PlayToGame>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        abridgedMode = GameObject.Find("AbridgedUI").GetComponent<AbridgedMode>();
        GrabPlayToGameData();
    }

    public void CheckEnabledPlayers()
    {
        // check enabled players
        player1Enabled = playToGame.Player1Enabled;
        player2Enabled = playToGame.Player2Enabled;
        player3Enabled = playToGame.Player3Enabled;
        player4Enabled = playToGame.Player4Enabled;

        int numberOfPlayers = 0;
        if(player1Enabled)
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
      //  turnManager.SetupGameFinal(numberOfPlayers, CheckColors());


    }

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


        // check abridged

        // check enabled players
        AICheck();
        CheckEnabledPlayers();
        CheckColors();
        CheckGameMode();

    }

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
    List<int> CheckColors()
    {
        // normal colors can be pulled across as normal
         player1Color = playToGame.Player1Color;
         player2Color = playToGame.Player2Color;
         player3Color = playToGame.Player3Color;
         player4Color = playToGame.Player4Color;


        // child 0 is the BG
        // color list to int
        Debug.Log("Setting stat color BGs");
        player1Stat.transform.GetChild(0).GetComponent<Image>().color = player1Color;
        player2Stat.transform.GetChild(0).GetComponent<Image>().color = player2Color;
        player3Stat.transform.GetChild(0).GetComponent<Image>().color = player3Color;
        player4Stat.transform.GetChild(0).GetComponent<Image>().color = player4Color;

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

    void CheckGameMode()
    {
        Debug.Log("Checking game mode");
        if(playToGame.GameMode == "abridged")
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
            abridgedMode.SetupAbridged(playToGame.TimeLimit);
            return;
        }

        Debug.Log("ERRROR. game mode is : " + playToGame.GameMode);
    }
}
