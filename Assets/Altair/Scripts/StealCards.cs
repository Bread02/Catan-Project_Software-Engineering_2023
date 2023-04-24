using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealCards : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;
    private Robber robber;
    private HelpText helpText;

    [Header("GameObjects")]
    public GameObject donateCardsObject;

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

    }

    // finds the players with a settlement adjacent to the tile of the robber.
    // ALSO MAKE SURE THE BUTTON DOES NOT APPEAR FOR THE PLAYER'S TURN.
    public void FindAdjacentSettlementPlayers()
    {
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
                        player1StealFromButton.SetActive(true);
                    }
                    break;
                case 2:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 2)
                    {
                        player2StealFromButton.SetActive(true);
                    }
                    break;
                case 3:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 3)
                    {
                        player3StealFromButton.SetActive(true);
                    }
                    break;
                case 4:
                    if (turnManager.ReturnCurrentPlayer().playerNumber != 4)
                    {
                        player4StealFromButton.SetActive(true);
                    }
                    break;
            }
        }

        StartCoroutine(helpText.HelpTextBox("Choose the player you want to steal from."));
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
        turnManager.ForcePlayerTurn(playerManager);
        donateCardsObject.SetActive(true);
        donateCardsObject.GetComponent<DonateCardsObject>().SetPlayerDonatingTo(turnManager.playerWhoRolledSeven);
        Debug.Log("Set player donating to");
    }

    public void FinishTheft()
    {
        turnManager.ForcePlayerTurn(turnManager.playerWhoRolledSeven);
        RemovePlayerTheftOptions();
        StartCoroutine(helpText.HelpTextBox("Continue round."));

    }

    public void RemovePlayerTheftOptions()
    {
        player1StealFromButton.SetActive(false);
        player2StealFromButton.SetActive(false);
        player3StealFromButton.SetActive(false);
        player4StealFromButton.SetActive(false);
    }
}
