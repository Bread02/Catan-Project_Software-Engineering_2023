using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DiceRolling : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;
    private TradeManager tradeManager;
    public DiceReader yellowDiceReader;
    public DiceReader redDiceReader;
    private TerrainAssigner terrainAssigner;
    private DiscardHalfOfCards discardHalfOfCards;

    [Header("Bools")]
    public bool yellowRolled;
    public bool redRolled;
    public bool triggerNumberActionActive;
    public bool timeToRoll;


    //[SerializeField] private TextMeshProUGUI diceRollText;
    public GameObject rollDiceButton;

    // Start is called before the first frame update
    void Awake()
    {
        // game starts with player putting down structures.
        DisableTimeToRollDice();

        yellowRolled = false;
        redRolled = false;
        triggerNumberActionActive = false;
        FindScripts();
    }

    private void FindScripts()
    {
        terrainAssigner = GameObject.Find("TileHolder").GetComponent<TerrainAssigner>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        tradeManager = GameObject.Find("THE_TRADE_GUI").GetComponent<TradeManager>();
        discardHalfOfCards = GameObject.Find("DiscardHalfOfCards").GetComponent<DiscardHalfOfCards>();
    }

    public void EndDiceRoll()
    {
        triggerNumberActionActive = true;
       int yellowResult = yellowDiceReader.RollResult();
       int redResult = redDiceReader.RollResult();

       int totalResult = redResult + yellowResult;

       //diceRollText.text = "Rolled: " + totalResult.ToString();


       TriggerNumberAction(totalResult);

    }

    public void TimeToRollDice()
    {
        timeToRoll = true;
        rollDiceButton.SetActive(true);
    }

    public void DisableTimeToRollDice()
    {
        timeToRoll = false;
        rollDiceButton.SetActive(false);
    }


    public void TriggerNumberAction(int totalResult)
    {
       
        if(totalResult != 7)
        {
            List<GameObject> tiles = terrainAssigner.FindMatchingHexNumbers(totalResult);

            // for each player manager
            foreach(PlayerManager playerManager in turnManager.playerList)
            {
                playerManager.CheckIfNewCards(tiles);
            }
            turnManager.finishedDiceRolling = true;
        }
        else
        {
            // toggle discard cards. Once complete. Trigger robber movement (within turnmanager script)
            Debug.Log("Triggering lose half of cards");
            discardHalfOfCards.LoseHalfOfCards(turnManager.ReturnCurrentPlayer());
        }

        // add card to each matching tile with settlement.
    }

    public void ResetDice()
    {
        redDiceReader.ResetDicePosition();
        yellowDiceReader.ResetDicePosition();
        redRolled = false;
        yellowRolled = false;
        triggerNumberActionActive = false;
    }

    public void DiceRollTrigger(bool red)
    {
        if(red)
        {
            redRolled = true;
        }
        else
        {
            yellowRolled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(yellowRolled && redRolled && !triggerNumberActionActive)
        {
            EndDiceRoll();
        }
        if(!yellowRolled && !redRolled)
        {
            //diceRollText.text = "Rolled: ?";
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            ResetDice();
        }

        if(!tradeManager.inTradeMode && !yellowRolled && !redRolled)
        {
            TimeToRollDice();
        }
        else
        {
            DisableTimeToRollDice();
        }


        if(!tradeManager.inTradeMode && redRolled && yellowRolled && !triggerNumberActionActive)
        {
            turnManager.DisplayEndTurnButton();
        }
    }
}
