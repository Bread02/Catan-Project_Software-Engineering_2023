using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealCards : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;
    private Robber robber;
    private HelpText helpText;
    private DiceRolling diceRolling;

    [Header("GameObjects")]
    public GameObject donateCardsObject;
    private GameObject bankMangObj;
    [SerializeField] private GameObject endTurnButton;

    [Header("Buttons")]
    public GameObject player1StealFromButton;
    public GameObject player2StealFromButton;
    public GameObject player3StealFromButton;
    public GameObject player4StealFromButton;

    // Start is called before the first frame update
    void Start()
    {
        RemovePlayerTheftOptions();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        helpText = GameObject.Find("HelpTextBox").GetComponent<HelpText>();
        diceRolling = GameObject.Find("DiceRolling").GetComponent<DiceRolling>();
        bankMangObj = GameObject.Find("THE_BANK");

    }

    // finds the players with a settlement adjacent to the tile of the robber.
    // ALSO MAKE SURE THE BUTTON DOES NOT APPEAR FOR THE PLAYER'S TURN.
    // To steal from a player. the player must also have at least ONE resource card.
    public void FindAdjacentSettlementPlayers()
    {
        bool canSteal = false; // false until proven

        // find adjacent settlements and who owns this.
        List<GameObject> adjacentSettlements = robber.occupiedHex.GetComponent<TerrainHex>().adjacentSettlements;

        foreach (GameObject adjacentSettlement in adjacentSettlements)
        {
            int playerOwned = adjacentSettlement.GetComponent<ChooseSettlement>().playerClaimedBy;

            switch (playerOwned)
            {
                case 1:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 1)
                    {
                        if (turnManager.playerList[0].ReturnNumberOfRCCards() > 0)
                        {
                            player1StealFromButton.SetActive(true);
                            canSteal = true;
                        }
                    }
                    break;
                case 2:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 2)
                    {
                        if (turnManager.playerList[1].ReturnNumberOfRCCards() > 0)
                        {
                            player2StealFromButton.SetActive(true);
                            canSteal = true;
                        }
                    }
                    break;
                case 3:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 3)
                    {
                        if (turnManager.playerList[2].ReturnNumberOfRCCards() > 0)
                        {
                            player3StealFromButton.SetActive(true);
                            canSteal = true;
                        }
                    }
                    break;
                case 4:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 4)
                    {
                        if (turnManager.playerList[3].ReturnNumberOfRCCards() > 0)
                        {
                            player4StealFromButton.SetActive(true);
                            canSteal = true;
                        }
                    }
                    break;
            }
        }

        if(canSteal == true)
        {
            StartCoroutine(helpText.HelpTextBox("Choose the player you want to steal from."));
        }
        else
        {
            // if cannot steal anything, continue turn.
            FinishTheft(false);
        }

    }

    public void ClickPlayerToStealFrom(int playerToStealFrom)
    {
        StartCoroutine(helpText.HelpTextBox("Player wants to steal your card, choose a card to discard."));
        donateCardsObject.SetActive(true);
        switch (playerToStealFrom)
        {
            case 1:
                ForcePlayerDonateCard(turnManager.playerList[0]);
                break;
            case 2:
                ForcePlayerDonateCard(turnManager.playerList[1]);
                break;
            case 3:
                ForcePlayerDonateCard(turnManager.playerList[2]);
                break;
            case 4:
                ForcePlayerDonateCard(turnManager.playerList[3]);
                break;

        }
        // ForcePlayerDonateCard(playerWhoRolledSeven);
    }

    public void ForcePlayerDonateCard(PlayerManager playerManager)
    {
        // player now must donate card
        donateCardsObject.SetActive(true);
        turnManager.ForcePlayerTurn(playerManager);
        donateCardsObject.GetComponent<DonateCardsObject>().SetPlayerDonatingTo(turnManager.playerWhoRolledSeven);
        Debug.Log("Set player donating to");
    }

    // if dice not yet rolled, roll dice.
    public void FinishTheft(bool didSteal)
    {
        turnManager.ForcePlayerTurn(turnManager.playerWhoRolledSeven);
        RemovePlayerTheftOptions();

        //Can now show interactable objects again
        foreach (GameObject playerDropZone in turnManager.playerDropZones)
        {
            playerDropZone.SetActive(true);
        }
        bankMangObj.SetActive(true);
        endTurnButton.SetActive(true);
        //

        if (!diceRolling.redRolled)
        {
            diceRolling.TimeToRollDice();
            Debug.Log("Time to roll dice");
        }
        else
        {
            Debug.Log("Displaying End Turn Button");
            turnManager.DisplayEndTurnButton();
        }

        if (didSteal)
        {
            StartCoroutine(helpText.HelpTextBox("Theft complete. Continue your round."));
        }
        else
        {
            StartCoroutine(helpText.HelpTextBox("No cards to steal. Continue your round."));
        }
    }

    public void RemovePlayerTheftOptions()
    {
        player1StealFromButton.SetActive(false);
        player2StealFromButton.SetActive(false);
        player3StealFromButton.SetActive(false);
        player4StealFromButton.SetActive(false);
    }
}
