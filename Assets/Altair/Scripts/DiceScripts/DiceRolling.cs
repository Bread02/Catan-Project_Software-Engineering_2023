using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/**
 * This script controls the dice rolling mechanic.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class DiceRolling : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;
    private TradeManager tradeManager;
    public DiceReader yellowDiceReader;
    public DiceReader redDiceReader;
    private TerrainAssigner terrainAssigner;
    private DiscardHalfOfCards discardHalfOfCards;
    private BankManager bankMang;

    [Header("Bools")]
    public bool yellowRolled;
    public bool redRolled;
    public bool triggerNumberActionActive;
    public bool timeToRoll;

    [Header("Ints")]
    public int totalResult;

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
        bankMang = GameObject.Find("THE_BANK").GetComponent<BankManager>();
    }

    // Ends the dice roll.
    public void EndDiceRoll()
    {
        triggerNumberActionActive = true;
       int yellowResult = yellowDiceReader.RollResult();
       int redResult = redDiceReader.RollResult();

       totalResult = redResult + yellowResult;

       //diceRollText.text = "Rolled: " + totalResult.ToString();


       TriggerNumberAction(totalResult);

    }

    // Enables the roll button, enables the time to roll.
    public void TimeToRollDice()
    {
        timeToRoll = true;
        rollDiceButton.SetActive(true);
    }

    // Disables the button for dice rolling and bool
    public void DisableTimeToRollDice()
    {
        timeToRoll = false;
        rollDiceButton.SetActive(false);
    }


    // Triggers the number action for whatever the dice lands on.
    public void TriggerNumberAction(int totalResult)
    {

        if (totalResult != 7)
        {
            List<GameObject> tiles = terrainAssigner.FindMatchingHexNumbers(totalResult);

            //Must now check if there are enough resources
            //E.g. if there are 4 players that each should receive a brick card, but there are only 3 brick cards in the bank, then NO ONE gets a brick card
            //However in the same dice roll, if 3 players should receive a grain card, and there are 4 grain cards in the bank, then these 3 players get a grain card.
            //Solution: Have a dictionary where the key is the player number, and value is another dictionary
            //that stores the quantity of each resource card that the player should receive.
            Dictionary<PlayerManager, Dictionary<string, int>> cardsToGiveToPlrsDict = new Dictionary<PlayerManager, Dictionary<string, int>>();
            foreach (PlayerManager playerManager in turnManager.playerList)
            {
                cardsToGiveToPlrsDict.Add(playerManager, playerManager.GetDictForCardsFromDiceRoll(tiles));
            }

            //Go through each card type and find if the sum of all cards that need to be given to players is less than or equal to amount in bank
            //If it greater, then this resource card CANNOT be taken from the bank!
            Dictionary<string, int> sumOfEachRCtoTakeFromBankDict = new Dictionary<string, int>()
            {
                {"grain", 0},
                {"wool", 0},
                {"ore", 0},
                {"brick", 0},
                {"lumber", 0}
            };
            Dictionary<string, bool> canTakeRCfromBank = new Dictionary<string, bool>()
            {
                {"grain", true},
                {"wool", true},
                {"ore", true},
                {"brick", true},
                {"lumber", true}
            };

            foreach(Dictionary<string, int> cardsToGiveToOnePlrDict in cardsToGiveToPlrsDict.Values)
            {
                foreach(KeyValuePair<string, int> kvp in cardsToGiveToOnePlrDict)
                {
                    sumOfEachRCtoTakeFromBankDict[kvp.Key] += kvp.Value;
                }
            }
            foreach (KeyValuePair<string, int> singleRCsumToTakeFromBank in sumOfEachRCtoTakeFromBankDict)
            {
                if (singleRCsumToTakeFromBank.Value > bankMang.GetValue(singleRCsumToTakeFromBank.Key)) {
                    canTakeRCfromBank[singleRCsumToTakeFromBank.Key] = false;
                    Debug.Log("NOT ENOUGH "+singleRCsumToTakeFromBank.Key+" CARDS TO GIVE TO ALL PLAYERS!");
                }
            }
            foreach (KeyValuePair<PlayerManager, Dictionary<string, int>> kvp in cardsToGiveToPlrsDict)
            {
                PlayerManager player = kvp.Key;
                foreach(KeyValuePair<string, int> cardsToGiveToOnePlrDict in kvp.Value)
                {
                    string cardType = cardsToGiveToOnePlrDict.Key;
                    int amntToTakeFromBank = cardsToGiveToOnePlrDict.Value;
                    if (canTakeRCfromBank[cardType])
                    {
                        bankMang.IncOrDecValue(cardType, -amntToTakeFromBank); //Return value doesn't matter as we have already checked if cards can be taken from bank
                        player.IncOrDecValue(cardType, amntToTakeFromBank);
                    }
                }
            }
        }
        else
        {
            // toggle discard cards. Once complete. Trigger robber movement (within turnmanager script)
            Debug.Log("Triggering lose half of cards");
            discardHalfOfCards.LoseHalfOfCards(turnManager.ReturnCurrentPlayer());
        }
        turnManager.finishedDiceRolling = true;
        turnManager.DisplayEndTurnButton();
        // add card to each matching tile with settlement.
    }

    // Resets the dice position to be reused again in the next turn.
    public void ResetDice()
    {
        redDiceReader.ResetDicePosition();
        yellowDiceReader.ResetDicePosition();
        redRolled = false;
        yellowRolled = false;
        triggerNumberActionActive = false;
    }

    // Resets the dice position to be reused again.
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
            turnManager.HideEndTurnButton();
            //diceRollText.text = "Rolled: ?";
        }

        /*
        if (Input.GetKeyDown(KeyCode.O))
        {
            ResetDice();
        }
        */

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


    public int GetDiceRollResult(){
        return totalResult;
    }
}
