using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// data we need to bring from the play menu to the game
public class PlayToGame : MonoBehaviour
{
    private PlayMenu playMenu;

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

    // play to game needs this
    // Icons MUST be converted to integers to be transferred across scene.
    private int player1PortraitIcon;
    private int player2PortraitIcon;
    private int player3PortraitIcon;
    private int player4PortraitIcon;

    [Header("Game Mode")]
    // play to game needs this
    private string gameMode;
    private int timeLimit;

    public Color Player1Color { get => player1Color; set => player1Color = value; }
    public Color Player2Color { get => player2Color; set => player2Color = value; }
    public Color Player3Color { get => player3Color; set => player3Color = value; }
    public Color Player4Color { get => player4Color; set => player4Color = value; }
    public string Player1Name { get => player1Name; set => player1Name = value; }
    public string Player2Name { get => player2Name; set => player2Name = value; }
    public string Player3Name { get => player3Name; set => player3Name = value; }
    public string Player4Name { get => player4Name; set => player4Name = value; }
    public bool Player1Enabled { get => player1Enabled; set => player1Enabled = value; }
    public bool Player2Enabled { get => player2Enabled; set => player2Enabled = value; }
    public bool Player3Enabled { get => player3Enabled; set => player3Enabled = value; }
    public bool Player4Enabled { get => player4Enabled; set => player4Enabled = value; }
    public bool Player1AI { get => player1AI; set => player1AI = value; }
    public bool Player2AI { get => player2AI; set => player2AI = value; }
    public bool Player3AI { get => player3AI; set => player3AI = value; }
    public bool Player4AI { get => player4AI; set => player4AI = value; }
    public int Player1PortraitIcon { get => player1PortraitIcon; set => player1PortraitIcon = value; }
    public int Player2PortraitIcon { get => player2PortraitIcon; set => player2PortraitIcon = value; }
    public int Player3PortraitIcon { get => player3PortraitIcon; set => player3PortraitIcon = value; }
    public int Player4PortraitIcon { get => player4PortraitIcon; set => player4PortraitIcon = value; }
    public string GameMode { get => gameMode; set => gameMode = value; }
    public int TimeLimit { get => timeLimit; set => timeLimit = value; }

    // Start is called before the first frame update
    void Start()
    {
        // this allows this object to carry across data between scenes.
        DontDestroyOnLoad(this.gameObject);

        playMenu = GameObject.Find("PlayMenuManager").GetComponent<PlayMenu>();

    }

    public void SetMode(string gameModeString, int timeLimitInt)
    {
        GameMode = gameModeString;
        TimeLimit = timeLimitInt;
    }

    // called on clicking play.
    public void GetData(string gameModeString, int timeLimitInt)
    {
        GameMode = gameModeString;
        TimeLimit = timeLimitInt;

        Player1Color = playMenu.Player1Color;
        Player2Color = playMenu.Player2Color;
        Player3Color = playMenu.Player3Color;
        Player4Color = playMenu.Player4Color;


        Player1Name = playMenu.Player1Name;
        Player2Name = playMenu.Player2Name;
        Player3Name = playMenu.Player3Name;
        Player4Name = playMenu.Player4Name;

        Player1Enabled = playMenu.Player1Enabled;
        Player2Enabled = playMenu.Player2Enabled;
        Player3Enabled = playMenu.Player3Enabled;
        Player4Enabled = playMenu.Player4Enabled;

        Player1AI = playMenu.Player1AI;
        Player2AI = playMenu.Player2AI;
        Player3AI = playMenu.Player3AI;
        Player4AI = playMenu.Player4AI;

        // we get the number on the list for the icon
        Player1PortraitIcon = playMenu.Player1PortraitIconNumber;
        Player2PortraitIcon = playMenu.Player2PortraitIconNumber;
        Player3PortraitIcon = playMenu.Player3PortraitIconNumber;
        Player4PortraitIcon = playMenu.Player4PortraitIconNumber;
    }
}
