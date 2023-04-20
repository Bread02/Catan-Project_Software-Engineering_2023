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
    private Image player1PortraitIcon;
    private Image player2PortraitIcon;
    private Image player3PortraitIcon;
    private Image player4PortraitIcon;

    [Header("Game Mode")]
    // play to game needs this
    private string gameMode;
    private int timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        // this allows this object to carry across data between scenes.
        DontDestroyOnLoad(this.gameObject);

        playMenu = GameObject.Find("PlayMenuManager").GetComponent<PlayMenu>();

    }

    // called on clicking play.
    public void GetData(string gameModeString, int timeLimitInt)
    {
        gameMode = gameModeString;
        timeLimit = timeLimitInt;

        player1Color = playMenu.Player1Color;
        player2Color = playMenu.Player2Color;
        player3Color = playMenu.Player3Color;
        player4Color = playMenu.Player4Color;


        player1Name = playMenu.Player1Name;
        player2Name = playMenu.Player2Name;
        player3Name = playMenu.Player3Name;
        player4Name = playMenu.Player4Name;

        player1Enabled = playMenu.Player1Enabled;
        player2Enabled = playMenu.Player2Enabled;
        player3Enabled = playMenu.Player3Enabled;
        player4Enabled = playMenu.Player4Enabled;

        player1AI = playMenu.Player1AI;
        player2AI = playMenu.Player2AI;
        player3AI = playMenu.Player3AI;
        player4AI = playMenu.Player4AI;

        player1PortraitIcon = playMenu.Player1PortraitIcon;
        player2PortraitIcon = playMenu.Player2PortraitIcon;
        player3PortraitIcon = playMenu.Player3PortraitIcon;
        player4PortraitIcon = playMenu.Player4PortraitIcon;

    }
}
