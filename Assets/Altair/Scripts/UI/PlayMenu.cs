using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/**
 * This script is responsbie for controlling the play menu
 *
 * @author Altair
 * @version 27/04/2023
 */

public class PlayMenu : MonoBehaviour
{
    [Header("Other Scripts")]
    private PlayToGame playToGame;
    private LoadScene loadScene;

    [Header("Game Mode Text")]
    private string gameModeInfoTextStandard = "The classic Settlers experience.";
    private string gameModeInfoTextAbridged = "The classic game with a time limit. Once everyone has taken turns within the time limit, the player with the most victory points win.";
    [SerializeField] private GameObject gameModeInfo;
    [SerializeField] private GameObject abridgedButton;
    [SerializeField] private GameObject standardButton;

    [Header("Player Icons - DO NOT TOUCH")]
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

    private List<Sprite> IconList = new List<Sprite>();

    [Header("Player Color Options")]
    [SerializeField] private Color blue;
    [SerializeField] private Color orange;
    [SerializeField] private Color red;
    [SerializeField] private Color white;

    private List<Color> colorList = new List<Color>();

    [Header("Play Options")]

    // play to game needs this
    [Header("Player Color")]
    private Color player1Color;
    private Color player2Color;
    private Color player3Color;
    private Color player4Color;

    // PLAYER COLORS MUST BE CONVERTED TO INT TO BE TRANSFERRED ACROSS SCENES
    [Header("Player Int")]
    private int player1ColorInt;
    private int player2ColorInt;
    private int player3ColorInt;
    private int player4ColorInt;

    // play to game needs this
    [Header("Player Name")]
    private string player1Name;
    private string player2Name;
    private string player3Name;
    private string player4Name;

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

    [Header("Game Mode")]
    // play to game needs this
    private GameMode gameMode;
    private TimeLimit timeLimit;
    [SerializeField] private TextMeshProUGUI timeLimitText;

    public int timeLimitInt; // THIS IS IN SECONDS
    public string gameModeString;

    // THIS IS STANDARD MODE OPTIONS
    private VictoryPointsLimit victoryPointsLimit;

    public GameObject victoryPointsOptions;
    public GameObject abridgedModeOptions;

    public enum VictoryPointsLimit
    {
        five,
        eight,
        ten,
        twelve,
        fifteen,
        twenty
    }

    [Header("Player Color Icon")]
    [SerializeField] private Image player1ColorIcon;
    [SerializeField] private Image player2ColorIcon;
    [SerializeField] private Image player3ColorIcon;
    [SerializeField] private Image player4ColorIcon;

    [Header("Player AI Icon")]
    [SerializeField] private Image player1AIIcon;
    [SerializeField] private Image player2AIIcon;
    [SerializeField] private Image player3AIIcon;
    [SerializeField] private Image player4AIIcon;

    [Header("Player Enabled Icon")]
    [SerializeField] private Image player1EnabledIcon;
    [SerializeField] private Image player2EnabledIcon;
    [SerializeField] private Image player3EnabledIcon;
    [SerializeField] private Image player4EnabledIcon;

    [Header("Player Icon")]
    [SerializeField] private Image player1PortraitIcon;
    [SerializeField] private Image player2PortraitIcon;
    [SerializeField] private Image player3PortraitIcon;
    [SerializeField] private Image player4PortraitIcon;

    [SerializeField] private int player1PortraitIconNumber;
    [SerializeField] private int player2PortraitIconNumber;
    [SerializeField] private int player3PortraitIconNumber;
    [SerializeField] private int player4PortraitIconNumber;

    [Header("ButtonToggles")]
    [SerializeField] private Color colorEnabled;
    [SerializeField] private Color colorDisabled;

    [Header("Icon Enabled")]
    [SerializeField] private Sprite iconEnabled;
    [SerializeField] private Sprite iconDisabled;

    [Header("Player Info For Enabling Player")]
    [SerializeField] private GameObject playerInfo1;
    [SerializeField] private GameObject playerInfo2;
    [SerializeField] private GameObject playerInfo3;
    [SerializeField] private GameObject playerInfo4;

    [Header("Player Name Input")]
    public TextMeshProUGUI player1NameText;
    public TextMeshProUGUI player2NameText;
    public TextMeshProUGUI player3NameText;
    public TextMeshProUGUI player4NameText;

    [Header("Beginner Map")]
    private bool beginnerMap;
    [SerializeField] private Image beginnerToggle;


    // play to game needs this data
    public string Player1Name { get => Player1Name1; set => Player1Name1 = value; }
    public string Player2Name { get => Player2Name1; set => Player2Name1 = value; }
    public string Player3Name { get => Player3Name1; set => Player3Name1 = value; }
    public string Player4Name { get => Player4Name1; set => Player4Name1 = value; }
    public string Player1Name1 { get => player1Name; set => player1Name = value; }
    public string Player2Name1 { get => player2Name; set => player2Name = value; }
    public string Player3Name1 { get => player3Name; set => player3Name = value; }
    public string Player4Name1 { get => player4Name; set => player4Name = value; }
    public bool Player1Enabled { get => player1Enabled; set => player1Enabled = value; }
    public bool Player2Enabled { get => player2Enabled; set => player2Enabled = value; }
    public bool Player3Enabled { get => player3Enabled; set => player3Enabled = value; }
    public bool Player4Enabled { get => player4Enabled; set => player4Enabled = value; }
    public bool Player1AI { get => player1AI; set => player1AI = value; }
    public bool Player2AI { get => player2AI; set => player2AI = value; }
    public bool Player3AI { get => player3AI; set => player3AI = value; }
    public bool Player4AI { get => player4AI; set => player4AI = value; }
    private GameMode GameMode1 { get => GameMode2; set => GameMode2 = value; }
    private TimeLimit TimeLimit1 { get => TimeLimit2; set => TimeLimit2 = value; }
    public Color Player1Color { get => player1Color; set => player1Color = value; }
    public Color Player2Color { get => player2Color; set => player2Color = value; }
    public Color Player3Color { get => player3Color; set => player3Color = value; }
    public Color Player4Color { get => player4Color; set => player4Color = value; }
    private GameMode GameMode2 { get => gameMode; set => gameMode = value; }
    private TimeLimit TimeLimit2 { get => timeLimit; set => timeLimit = value; }
    public Image Player1PortraitIcon { get => player1PortraitIcon; set => player1PortraitIcon = value; }
    public Image Player2PortraitIcon { get => player2PortraitIcon; set => player2PortraitIcon = value; }
    public Image Player3PortraitIcon { get => player3PortraitIcon; set => player3PortraitIcon = value; }
    public Image Player4PortraitIcon { get => player4PortraitIcon; set => player4PortraitIcon = value; }
    public int Player1PortraitIconNumber { get => player1PortraitIconNumber; set => player1PortraitIconNumber = value; }
    public int Player2PortraitIconNumber { get => player2PortraitIconNumber; set => player2PortraitIconNumber = value; }
    public int Player3PortraitIconNumber { get => player3PortraitIconNumber; set => player3PortraitIconNumber = value; }
    public int Player4PortraitIconNumber { get => player4PortraitIconNumber; set => player4PortraitIconNumber = value; }
    public int Player1ColorInt { get => player1ColorInt; set => player1ColorInt = value; }
    public int Player2ColorInt { get => player2ColorInt; set => player2ColorInt = value; }
    public int Player3ColorInt { get => player3ColorInt; set => player3ColorInt = value; }
    public int Player4ColorInt { get => player4ColorInt; set => player4ColorInt = value; }
    public bool BeginnerMap { get => beginnerMap; set => beginnerMap = value; }

    private enum GameMode
        {
        abridged,
        standard,
        }

    private enum TimeLimit
    {
        five,
        ten,
        fifteen,
        twenty,
        twentyfive,
        thirty,
        thirtyfive,
        forty
    }

    private void ReadPlayerName()
    {
        Player1Name = player1NameText.text;
        Player2Name = player2NameText.text;
        Player3Name = player3NameText.text;
        Player4Name = player4NameText.text;
        playToGame.GetData(gameModeString, timeLimitInt);
    }

    private void DefaultMode()
    {
        VictoryPointsOptions.SetActive(true);
        abridgedModeOptions.SetActive(false);
    }

    // Start is called before the first frame update
    void Awake()
    {
        DefaultMode();

        FindScripts();
        InvokeRepeating("ReadPlayerName", 0.5f, 0.5f);

        // default time limit
        TimeLimit1 = TimeLimit.twenty;
        timeLimitText.text = "20:00";
        timeLimitInt = 1200;


        ColorListCreate();
        IconListCreate();

        // standard is default mode
        ClickStandard();

        // default settings
        Invoke("EnablePlayers", 0.01f) ;

        DefaultPlayerIcons();
        DefaultPlayerColors();

        // beginner map default
        beginnerMap = true;
        beginnerToggle.sprite = iconEnabled;

    }

    // Finds scripts needed for this class.
    void FindScripts()
    {
        loadScene = GameObject.Find("LoadingBar").GetComponent<LoadScene>();
        playToGame = GameObject.Find("PlayToGame").GetComponent<PlayToGame>();
    }


    // enables all players and enables all ai.
    public void EnablePlayers()
    {
        ClickEnablePlayer(1);
        ClickEnableAI(1);
        ClickEnablePlayer(2);
        ClickEnableAI(2);
        ClickEnablePlayer(3);
        ClickEnableAI(3);
        ClickEnablePlayer(4);
        ClickEnableAI(4);
    }

    private void Start()
    {
        Invoke("InvokeStart", 0.01f);
    }

    // Changes all colors forward.
    public void InvokeStart()
    {
        ClickChangeColorForward(1);
        ClickChangeColorForward(2);
        ClickChangeColorForward(3);
        ClickChangeColorForward(4);
    }

    // Sets the default player icons and the default numbers.
    private void DefaultPlayerIcons()
    {
        Player1PortraitIcon.sprite = portraitIcon1;
        Player2PortraitIcon.sprite = portraitIcon4;
        Player3PortraitIcon.sprite = portraitIcon6;
        Player4PortraitIcon.sprite = portraitIcon2;

        Player1PortraitIconNumber = 0;
        Player2PortraitIconNumber = 3;
        Player3PortraitIconNumber = 5;
        Player4PortraitIconNumber = 1;


    }

    // Creates the color list.
    private void ColorListCreate()
    {
        colorList.Add(blue); //0
        colorList.Add(orange); // 1
        colorList.Add(red); // 2
        colorList.Add(white); // 3
    }

    // Sets the default player colors and corresponding numbers.
    private void DefaultPlayerColors()
    {
        Player1Color = blue;
        Player1ColorInt = 0;

        Player2Color = orange;
        Player2ColorInt = 1;

        Player3Color = red;
        Player3ColorInt = 2;


        Player4Color = white;
        Player4ColorInt = 3;
    }

    // Creates an icon list using all available icons.
    private void IconListCreate()
    {
        IconList.Add(portraitIcon1);
        IconList.Add(portraitIcon2);
        IconList.Add(portraitIcon3);
        IconList.Add(portraitIcon4);
        IconList.Add(portraitIcon5);
        IconList.Add(portraitIcon6);
        IconList.Add(portraitIcon7);
        IconList.Add(portraitIcon8);
        IconList.Add(portraitIcon9);
        IconList.Add(portraitIcon10);
    }

    #region Game Mode Options

    // Method triggered by a button which toggles the beginner mode map.
    public void BeginnerModeToggle()
    {
        if (beginnerMap)
        {
            beginnerMap = false;
            beginnerToggle.sprite = iconDisabled;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        else
        {
            beginnerMap = true;
            beginnerToggle.sprite = iconEnabled;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
    }

    // victory points
    public void ClickIncreaseVictoryPoints()
    {
        if (TimeLimit1 == TimeLimit.five)
        {
            TimeLimit1 = TimeLimit.ten;
            timeLimitText.text = "10:00";
            timeLimitInt = 600;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.ten)
        {
            TimeLimit1 = TimeLimit.fifteen;
            timeLimitText.text = "15:00";
            timeLimitInt = 900;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.fifteen)
        {
            TimeLimit1 = TimeLimit.twenty;
            timeLimitText.text = "20:00";
            timeLimitInt = 1200;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twenty)
        {
            TimeLimit1 = TimeLimit.twentyfive;
            timeLimitText.text = "25:00";
            timeLimitInt = 1500;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twentyfive)
        {
            TimeLimit1 = TimeLimit.thirty;
            timeLimitText.text = "30:00";
            timeLimitInt = 1800;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirty)
        {
            TimeLimit1 = TimeLimit.thirtyfive;
            timeLimitText.text = "35:00";
            timeLimitInt = 2100;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirtyfive)
        {
            TimeLimit1 = TimeLimit.forty;
            timeLimitText.text = "40:00";
            timeLimitInt = 2400;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
    }

    // Method triggered by a button which DECREASES the time limit for abridged mode.
    public void ClickDecreaseVictoryPoints()
    {
        if (TimeLimit1 == TimeLimit.ten)
        {
            TimeLimit1 = TimeLimit.five;
            timeLimitText.text = "5:00";
            timeLimitInt = 300;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.fifteen)
        {
            TimeLimit1 = TimeLimit.ten;
            timeLimitText.text = "10:00";
            timeLimitInt = 600;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twenty)
        {
            TimeLimit1 = TimeLimit.fifteen;
            timeLimitText.text = "15:00";
            timeLimitInt = 900;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twentyfive)
        {
            TimeLimit1 = TimeLimit.twenty;
            timeLimitText.text = "20:00";
            timeLimitInt = 1200;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirty)
        {
            TimeLimit1 = TimeLimit.twentyfive;
            timeLimitText.text = "25:00";
            timeLimitInt = 1500;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirtyfive)
        {
            TimeLimit1 = TimeLimit.thirty;
            timeLimitText.text = "30:00";
            timeLimitInt = 1800;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.forty)
        {
            TimeLimit1 = TimeLimit.thirtyfive;
            timeLimitText.text = "35:00";
            timeLimitInt = 2100;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
    }

    // Method triggered by a button which increases the time limit for abridged mode.
    public void ClickIncreaseTimeLimit()
    {
        if(TimeLimit1 == TimeLimit.five)
        {
            TimeLimit1 = TimeLimit.ten;
            timeLimitText.text = "10:00";
            timeLimitInt = 600;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.ten)
        {
            TimeLimit1 = TimeLimit.fifteen;
            timeLimitText.text = "15:00";
            timeLimitInt = 900;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.fifteen)
        {
            TimeLimit1 = TimeLimit.twenty;
            timeLimitText.text = "20:00";
            timeLimitInt = 1200;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twenty)
        {
            TimeLimit1 = TimeLimit.twentyfive;
            timeLimitText.text = "25:00";
            timeLimitInt = 1500;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twentyfive)
        {
            TimeLimit1 = TimeLimit.thirty;
            timeLimitText.text = "30:00";
            timeLimitInt = 1800;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirty)
        {
            TimeLimit1 = TimeLimit.thirtyfive;
            timeLimitText.text = "35:00";
            timeLimitInt = 2100;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirtyfive)
        {
            TimeLimit1 = TimeLimit.forty;
            timeLimitText.text = "40:00";
            timeLimitInt = 2400;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
    }

    // Method triggered by a button which DECREASES the time limit for abridged mode.
    public void ClickDecreaseTimeLimit()
    {
        if (TimeLimit1 == TimeLimit.ten)
        {
            TimeLimit1 = TimeLimit.five;
            timeLimitText.text = "5:00";
            timeLimitInt = 300;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.fifteen)
        {
            TimeLimit1 = TimeLimit.ten;
            timeLimitText.text = "10:00";
            timeLimitInt = 600;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twenty)
        {
            TimeLimit1 = TimeLimit.fifteen;
            timeLimitText.text = "15:00";
            timeLimitInt = 900;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.twentyfive)
        {
            TimeLimit1 = TimeLimit.twenty;
            timeLimitText.text = "20:00";
            timeLimitInt = 1200;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirty)
        {
            TimeLimit1 = TimeLimit.twentyfive;
            timeLimitText.text = "25:00";
            timeLimitInt = 1500;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;

        }
        if (TimeLimit1 == TimeLimit.thirtyfive)
        {
            TimeLimit1 = TimeLimit.thirty;
            timeLimitText.text = "30:00";
            timeLimitInt = 1800;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
        if (TimeLimit1 == TimeLimit.forty)
        {
            TimeLimit1 = TimeLimit.thirtyfive;
            timeLimitText.text = "35:00";
            timeLimitInt = 2100;
            playToGame.GetData(gameModeString, timeLimitInt);
            return;
        }
    }

    // Method triggered by a button which enables standard mode.
    public void ClickStandard()
    {
        GameMode1 = GameMode.standard;
        abridgedButton.GetComponent<Image>().color = colorDisabled;
        standardButton.GetComponent<Image>().color = colorEnabled;
        gameModeInfo.GetComponent<TextMeshProUGUI>().text = gameModeInfoTextStandard;
        gameModeString = "standard";
        playToGame.SetMode(gameModeString, timeLimitInt);
    }

    // Method triggered by a button which enables abridged mode.
    public void ClickAbridged()
    {
        GameMode1 = GameMode.abridged;
        abridgedButton.GetComponent<Image>().color = colorEnabled;
        standardButton.GetComponent<Image>().color = colorDisabled;
        gameModeInfo.GetComponent<TextMeshProUGUI>().text = gameModeInfoTextAbridged;
        gameModeString = "abridged";
        playToGame.SetMode(gameModeString, timeLimitInt);
    }
    #endregion

    #region PlayAndBack

    // Method triggered by a button which goes back to the main menu
    public void ClickBackToMainMenu()
    {
        StartCoroutine(loadScene.LoadSceneCoroutine("MainMenuFinal"));
    }

    // click play button, loads the next scene, pulls all information in this scene that player has inputted across.
    public void ClickPlay()
    {
        StartCoroutine(loadScene.LoadSceneCoroutine("MAINSCENE2"));
    }
    #endregion

    #region Player Options

    // Method triggered by a button which enables the selected player
    public void ClickEnablePlayer(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                if (Player1Enabled)
                {
                    Player1Enabled = false;
                    player1EnabledIcon.sprite = iconDisabled;
                    playerInfo1.SetActive(false);
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
                else
                {
                    Player1Enabled = true;
                    player1EnabledIcon.sprite = iconEnabled;
                    playerInfo1.SetActive(true);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
            case 2:
                if (Player2Enabled)
                {
                    Player2Enabled = false;
                    player2EnabledIcon.sprite = iconDisabled;
                    playerInfo2.SetActive(false);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
                else
                {
                    Player2Enabled = true;
                    player2EnabledIcon.sprite = iconEnabled;
                    playerInfo2.SetActive(true);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
            case 3:
                if (Player3Enabled)
                {
                    Player3Enabled = false;
                    player3EnabledIcon.sprite = iconDisabled;
                    playerInfo3.SetActive(false);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
                else
                {
                    Player3Enabled = true;
                    player3EnabledIcon.sprite = iconEnabled;
                    playerInfo3.SetActive(true);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
            case 4:
                if (Player4Enabled)
                {
                    Player4Enabled = false;
                    player4EnabledIcon.sprite = iconDisabled;
                    playerInfo4.SetActive(false);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
                else
                {
                    Player4Enabled = true;
                    player4EnabledIcon.sprite = iconEnabled;
                    playerInfo4.SetActive(true);
                    playToGame.GetData(gameModeString, timeLimitInt);

                    return;
                }
        }


    }
    // Method triggered by a button which enables the selected AI
    public void ClickEnableAI(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                if (Player1AI)
                {
                    Player1AI = false;
                    player1AIIcon.sprite = iconDisabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
                else
                {
                    Player1AI = true;
                    player1AIIcon.sprite = iconEnabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
            case 2:
                if (Player2AI)
                {
                    Player2AI = false;
                    player2AIIcon.sprite = iconDisabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
                else
                {
                    Player2AI = true;
                    player2AIIcon.sprite = iconEnabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
            case 3:
                if (Player3AI)
                {
                    Player3AI = false;
                    player3AIIcon.sprite = iconDisabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
                else
                {
                    Player3AI = true;
                    player3AIIcon.sprite = iconEnabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
            case 4:
                if (Player4AI)
                {
                    Player4AI = false;
                    player4AIIcon.sprite = iconDisabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
                else
                {
                    Player4AI = true;
                    player4AIIcon.sprite = iconEnabled;
                    playToGame.GetData(gameModeString, timeLimitInt);
                    return;
                }
        }
    }

    // Method triggered by a button which changes the icon forward of the selected player
    public void ClickChangeIconForward(int playerNumber)
    {
        Debug.Log("Change icon forward");
        switch (playerNumber)
        {
            case 1:
                // get player color from list
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player1PortraitIcon.sprite == IconList[i])
                    {
                        // if final number, icon is 0
                        if (i == IconList.Count - 1)
                        {
                            Debug.Log("cahging icon back to 0");
                            Player1PortraitIcon.sprite = IconList[0];
                            Player1PortraitIconNumber = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Debug.Log("cahging icon ++");
                            Player1PortraitIcon.sprite = IconList[i + 1];
                            Player1PortraitIconNumber++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 2:
                // get player color from list
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player2PortraitIcon.sprite == IconList[i])
                    {
                        // if final number, icon is 0
                        if (i == IconList.Count - 1)
                        {
                            Player2PortraitIcon.sprite = IconList[0];
                            Player2PortraitIconNumber = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player2PortraitIcon.sprite = IconList[i + 1];
                            Player2PortraitIconNumber++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 3:
                // get player color from list
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player3PortraitIcon.sprite == IconList[i])
                    {
                        // if final number, icon is 0
                        if (i == IconList.Count - 1)
                        {
                            Player3PortraitIcon.sprite = IconList[0];
                            Player3PortraitIconNumber = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player3PortraitIcon.sprite = IconList[i + 1];
                            Player3PortraitIconNumber++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 4:
                // get player color from list
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player4PortraitIcon.sprite == IconList[i])
                    {
                        // if final number, icon is 0
                        if (i == IconList.Count - 1)
                        {
                            Player4PortraitIcon.sprite = IconList[0];
                            Player4PortraitIconNumber = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player4PortraitIcon.sprite = IconList[i + 1];
                            Player4PortraitIconNumber++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;

        }
    }

    // Method triggered by a button which changes the icon backward of the selected player

    public void ClickChangeIconBackward(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player1PortraitIcon.sprite == IconList[i])
                    {
                        if (i == 0)
                        {
                            Player1PortraitIcon.sprite = IconList[IconList.Count - 1];
                            Player1PortraitIconNumber = 9;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player1PortraitIcon.sprite = IconList[i - 1];
                            Player1PortraitIconNumber--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player2PortraitIcon.sprite == IconList[i])
                    {
                        if (i == 0)
                        {
                            Player2PortraitIcon.sprite = IconList[IconList.Count - 1];
                            Player2PortraitIconNumber = 9;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player2PortraitIcon.sprite = IconList[i - 1];
                            Player2PortraitIconNumber--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 3:
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player3PortraitIcon.sprite == IconList[i])
                    {
                        if (i == 0)
                        {
                            Player3PortraitIcon.sprite = IconList[IconList.Count - 1];
                            Player3PortraitIconNumber = 9;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;

                        }
                        else
                        {
                            Player3PortraitIcon.sprite = IconList[i - 1];
                            Player3PortraitIconNumber--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;

                        }
                    }
                }
                break;
            case 4:
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player4PortraitIcon.sprite == IconList[i])
                    {
                        if (i == 0)
                        {
                            Player4PortraitIcon.sprite = IconList[IconList.Count - 1];
                            Player4PortraitIconNumber = 9;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;

                        }
                        else
                        {
                            Player4PortraitIcon.sprite = IconList[i - 1];
                            Player4PortraitIconNumber--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;

                        }
                    }
                }
                break;

        }
    }

    // find current color it is, then ++ on list.
    // If there is time, come back to make it more compact as this code can be simplified.
    // Method triggered by a button which changes the color forward of the selected player
    public void ClickChangeColorForward(int playerNumber)
    {
        Debug.Log("Change color forward");
        switch (playerNumber)
        {
            case 1:
                Debug.Log("Change color forward case 1");
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player1Color == colorList[i])
                    {
                        if(i == colorList.Count - 1)
                        {
                            Player1Color = colorList[0];
                            Debug.Log("Changing P1 Color");
                            player1ColorIcon.color = Player1Color;
                            Player1ColorInt = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player1Color = colorList[i + 1];
                            Debug.Log("Changing P1 Color");
                            player1ColorIcon.color = Player1Color;
                            Player1ColorInt++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 2:
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player2Color == colorList[i])
                    {
                        // if final number, color is 0
                        if (i == colorList.Count - 1)
                        {
                            Player2Color = colorList[0];
                            player2ColorIcon.color = Player2Color;
                            Player2ColorInt = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;


                        }
                        else
                        {
                            Player2Color = colorList[i + 1];
                            player2ColorIcon.color = Player2Color;
                            Player2ColorInt++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;

                        }
                    }
                }
                break;
            case 3:
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player3Color == colorList[i])
                    {
                        // if final number, color is 0
                        if (i == colorList.Count - 1)
                        {
                            Player3Color = colorList[0];
                            player3ColorIcon.color = Player3Color;
                            Player3ColorInt = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player3Color = colorList[i + 1];
                            player3ColorIcon.color = Player3Color;
                            Player3ColorInt++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 4:
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player4Color == colorList[i])
                    {
                        // if final number, color is 0
                        if (i == colorList.Count - 1)
                        {
                            Player4Color = colorList[0];
                            player4ColorIcon.color = Player4Color;
                            Player4ColorInt = 0;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player4Color = colorList[i + 1];
                            player4ColorIcon.color = Player4Color;
                            Player4ColorInt++;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;

        }
    }

    // Method triggered by a button which changes the color backward of the selected player
    public void ClickChangeColorBackward(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                Debug.Log("Player 1");
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player1Color == colorList[i])
                    {
                        if (i == 0)
                        {
                            Player1Color = colorList[colorList.Count - 1];
                            player1ColorIcon.color = Player1Color;
                            Player1ColorInt = 3;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player1Color = colorList[i - 1];
                            player1ColorIcon.color = Player1Color;
                            Player1ColorInt--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 2:
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player2Color == colorList[i])
                    {
                        if (i == 0)
                        {
                            Player2Color = colorList[colorList.Count - 1];
                            player2ColorIcon.color = Player2Color;
                            Player2ColorInt = 3;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player2Color = colorList[i - 1];
                            player2ColorIcon.color = Player2Color;
                            Player2ColorInt--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 3:
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player3Color == colorList[i])
                    {
                        if (i == 0)
                        {
                            Player3Color = colorList[colorList.Count - 1];
                            player3ColorIcon.color = Player3Color;
                            Player3ColorInt = 3;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player3Color = colorList[i - 1];
                            player3ColorIcon.color = Player3Color;
                            Player3ColorInt--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;
            case 4:
                // get player color from list
                for (int i = 0; i < colorList.Count; i++)
                {
                    if (Player4Color == colorList[i])
                    {
                        if (i == 0)
                        {
                            Player4Color = colorList[colorList.Count - 1];
                            player4ColorIcon.color = Player4Color;
                            Player4ColorInt = 3;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player4Color = colorList[i - 1];
                            player4ColorIcon.color = Player4Color;
                            Player4ColorInt--;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;

        }
    }

    #endregion
}
