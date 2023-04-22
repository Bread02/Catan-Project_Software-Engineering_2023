using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    private PlayToGame playToGame;

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

    }


    // Start is called before the first frame update
    void Awake()
    {
        playToGame = GameObject.Find("PlayToGame").GetComponent<PlayToGame>();
        InvokeRepeating("ReadPlayerName", 0.5f, 0.5f);

        // default time limit
        TimeLimit1 = TimeLimit.twenty;
        timeLimitText.text = "20:00";
        timeLimitInt = 1200;


        ColorListCreate();
        IconListCreate();
        DefaultPlayerColors();

        // standard is default mode
        ClickStandard();

        // default settings
        ClickEnablePlayer(1);
        ClickEnableAI(1);
        ClickEnablePlayer(2);
        ClickEnableAI(2);
        ClickEnablePlayer(3);
        ClickEnableAI(3);
        ClickEnablePlayer(4);
        ClickEnableAI(4);

        DefaultPlayerIcons();

    }

    private void Start()
    {
        Invoke("InvokeStart", 0.01f);
    }

    public void InvokeStart()
    {
        ClickChangeColorForward(1);
        ClickChangeColorForward(2);
        ClickChangeColorForward(3);
        ClickChangeColorForward(4);


    }

    private void DefaultPlayerIcons()
    {
        Player1PortraitIcon.sprite = portraitIcon1;
        Player2PortraitIcon.sprite = portraitIcon4;
        Player3PortraitIcon.sprite = portraitIcon6;
        Player4PortraitIcon.sprite = portraitIcon2;

        Player1PortraitIconNumber = 1;
        Player2PortraitIconNumber = 4;
        Player3PortraitIconNumber = 6;
        Player4PortraitIconNumber = 2;


    }

    private void ColorListCreate()
    {
        colorList.Add(blue);
        colorList.Add(orange);
        colorList.Add(red);
        colorList.Add(white);
    }

    private void DefaultPlayerColors()
    {
        Player1Color = blue;
        Player2Color = orange;
        Player3Color = red;
        Player4Color = white;
    }

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

    public void ClickStandard()
    {
        GameMode1 = GameMode.standard;
        abridgedButton.GetComponent<Image>().color = colorDisabled;
        standardButton.GetComponent<Image>().color = colorEnabled;
        gameModeInfo.GetComponent<TextMeshProUGUI>().text = gameModeInfoTextStandard;
        gameModeString = "standard";
        playToGame.SetMode(gameModeString, timeLimitInt);
    }

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

    public void ClickBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuFinal");
    }

    // click play button, loads the next scene, pulls all information in this scene that player has inputted across.
    public void ClickPlay()
    {
        SceneManager.LoadScene("MAINSCENE2");
    }
    #endregion

    #region Player Options

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
                    return;
                }
                else
                {
                    Player1Enabled = true;
                    player1EnabledIcon.sprite = iconEnabled;
                    playerInfo1.SetActive(true);

                    return;
                }
                break;
            case 2:
                if (Player2Enabled)
                {
                    Player2Enabled = false;
                    player2EnabledIcon.sprite = iconDisabled;
                    playerInfo2.SetActive(false);

                    return;
                }
                else
                {
                    Player2Enabled = true;
                    player2EnabledIcon.sprite = iconEnabled;
                    playerInfo2.SetActive(true);

                    return;
                }
                break;
            case 3:
                if (Player3Enabled)
                {
                    Player3Enabled = false;
                    player3EnabledIcon.sprite = iconDisabled;
                    playerInfo3.SetActive(false);
                    return;
                }
                else
                {
                    Player3Enabled = true;
                    player3EnabledIcon.sprite = iconEnabled;
                    playerInfo3.SetActive(true);

                    return;
                }
                break;
            case 4:
                if (Player4Enabled)
                {
                    Player4Enabled = false;
                    player4EnabledIcon.sprite = iconDisabled;
                    playerInfo4.SetActive(false);

                    return;
                }
                else
                {
                    Player4Enabled = true;
                    player4EnabledIcon.sprite = iconEnabled;
                    playerInfo4.SetActive(true);

                    return;
                }
                break;
        }


    }

    public void ClickEnableAI(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                if (Player1AI)
                {
                    Player1AI = false;
                    player1AIIcon.sprite = iconDisabled;
                    return;
                }
                else
                {
                    Player1AI = true;
                    player1AIIcon.sprite = iconEnabled;
                    return;
                }
                break;
            case 2:
                if (Player2AI)
                {
                    Player2AI = false;
                    player2AIIcon.sprite = iconDisabled;
                    return;
                }
                else
                {
                    Player2AI = true;
                    player2AIIcon.sprite = iconEnabled;
                    return;
                }
                break;
            case 3:
                if (Player3AI)
                {
                    Player3AI = false;
                    player3AIIcon.sprite = iconDisabled;
                    return;
                }
                else
                {
                    Player3AI = true;
                    player3AIIcon.sprite = iconEnabled;
                    return;
                }
            case 4:
                if (Player4AI)
                {
                    Player4AI = false;
                    player4AIIcon.sprite = iconDisabled;
                    return;
                }
                else
                {
                    Player4AI = true;
                    player4AIIcon.sprite = iconEnabled;
                    return;
                }
                break;
        }
    }

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
                            return;
                        }
                        else
                        {
                            Debug.Log("cahging icon ++");
                            Player1PortraitIcon.sprite = IconList[i + 1];
                            Player1PortraitIconNumber++;
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
                            return;
                        }
                        else
                        {
                            Player2PortraitIcon.sprite = IconList[i + 1];
                            Player2PortraitIconNumber++;
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
                            return;
                        }
                        else
                        {
                            Player3PortraitIcon.sprite = IconList[i + 1];
                            Player3PortraitIconNumber++;
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
                            return;
                        }
                        else
                        {
                            Player4PortraitIcon.sprite = IconList[i + 1];
                            Player4PortraitIconNumber++;
                            return;
                        }
                    }
                }
                break;

        }
    }

    public void ClickChangeIconBackward(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                // get player color from list
                for (int i = 0; i < IconList.Count; i++)
                {
                    if (Player1PortraitIcon.sprite == IconList[i])
                    {
                        if (i == 0)
                        {
                            Player1PortraitIcon.sprite = IconList[IconList.Count - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player1PortraitIconNumber = 9;
                            return;
                        }
                        else
                        {
                            Player1PortraitIcon.sprite = IconList[i - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player1PortraitIconNumber--;
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
                        if (i == 0)
                        {
                            Player2PortraitIcon.sprite = IconList[IconList.Count - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player2PortraitIconNumber = 9;
                            return;
                        }
                        else
                        {
                            Player2PortraitIcon.sprite = IconList[i - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player2PortraitIconNumber--;
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
                        if (i == 0)
                        {
                            Player3PortraitIcon.sprite = IconList[IconList.Count - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player3PortraitIconNumber = 9;
                            return;

                        }
                        else
                        {
                            Player3PortraitIcon.sprite = IconList[i - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player3PortraitIconNumber--;
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
                        if (i == 0)
                        {
                            Player4PortraitIcon.sprite = IconList[IconList.Count - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player4PortraitIconNumber = 9;
                            return;

                        }
                        else
                        {
                            Player4PortraitIcon.sprite = IconList[i - 1];
                            playToGame.GetData(gameModeString, timeLimitInt);
                            Player4PortraitIconNumber--;
                            return;

                        }
                    }
                }
                break;

        }
    }

    // find current color it is, then ++ on list.
    // If there is time, come back to make it more compact as this code can be simplified.
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player1Color = colorList[i + 1];
                            Debug.Log("Changing P1 Color");
                            player1ColorIcon.color = Player1Color;
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;


                        }
                        else
                        {
                            Player2Color = colorList[i + 1];
                            player2ColorIcon.color = Player2Color;
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player3Color = colorList[i + 1];
                            player3ColorIcon.color = Player3Color;
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player4Color = colorList[i + 1];
                            player4ColorIcon.color = Player4Color;
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                    }
                }
                break;

        }
    }

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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player1Color = colorList[i - 1];
                            player1ColorIcon.color = Player1Color;
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player2Color = colorList[i - 1];
                            player2ColorIcon.color = Player2Color;
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player3Color = colorList[i - 1];
                            player3ColorIcon.color = Player3Color;
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
                            playToGame.GetData(gameModeString, timeLimitInt);
                            return;
                        }
                        else
                        {
                            Player4Color = colorList[i - 1];
                            player4ColorIcon.color = Player4Color;
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
