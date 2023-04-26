using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * This script controls the mechanic for the player needing to discard half of their cards
 * if a robber is rolled.
 *
 * @author Altair, Ben
 * @version 26/04/2023
 */
public class DiscardHalfOfCards : MonoBehaviour
{
    [Header("Other Scripts")]
    private Robber robber;
    private HelpText helpText;
    private TurnManager turnManager;

    [Header("Bools")]
    private bool cardDiscardingComplete;
    bool playerDiscarded = false;

    [Header("GameObjects")]
    // the first instructions that appear when starting the game
    // this is to aid the player so they know what to do when the game starts.
    public GameObject loseCardsObject;

    public void Awake()
    {
        FindObjects();
    }

    // Finds the scripts needed for this script
    private void FindObjects()
    {
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        helpText = GameObject.Find("HelpTextBox").GetComponent<HelpText>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }


    // Triggers the lose half of cards functionality.
    public void LoseHalfOfCards(PlayerManager playerManagerRollSeven)
    {
        turnManager.playerWhoRolledSeven = playerManagerRollSeven;
        cardDiscardingComplete = false;
        StartCoroutine(TriggerRobberMovement());
        List<PlayerManager> playersMustDiscard = new List<PlayerManager>();
        Debug.Log("Players now lose half of cards if needed. Checking number of resource cards.");
        foreach (PlayerManager playerManager in turnManager.playerList)
        {
            //     Debug.Log("Player : " + playerManager.playerNumber + " has " + playerManager.ReturnNumberOfRCCards() + " cards");

            if (playerManager.ReturnNumberOfRCCards() > 7)
            {
                Debug.Log("Player " + playerManager.playerNumber + " has too many cards. now must discard");
                // make player choose cards to lose.
                playersMustDiscard.Add(playerManager);
            }
            else
            {
                Debug.Log("Player " + playerManager.playerNumber + " does not need to discard cards");
            }
        }
        StartCoroutine(PlayerLoseCardsTurn(playersMustDiscard));
    }

    // This checks if players have to lose cards.
    public IEnumerator PlayerLoseCardsTurn(List<PlayerManager> playerLoseCards)
    {
        if (playerLoseCards.Count == 0)
        {
            Debug.Log("No cards to discard, now returning");
            cardDiscardingComplete = true;
            yield break;
        }
        loseCardsObject.SetActive(true);
        StartCoroutine(helpText.HelpTextBox("Player must discard half of cards"));

        // make player turn according to list.
        for (int i = 0; i < playerLoseCards.Count; i++)
        {
            Debug.Log("Making player discard");
            playerDiscarded = false;
            turnManager.playerToPlay = playerLoseCards[i].playerNumber;
            int totalCards = playerLoseCards[i].ReturnNumberOfRCCards();
            turnManager.DisplayCurrentPlayerTurn();
            StartCoroutine(CardDiscard(turnManager.playerToPlay, totalCards));
            yield return new WaitUntil(() => playerDiscarded);
            Debug.Log("Ended lose cards loop");
        }

        Debug.Log("Card discarding fully complete. Returning to round");
        cardDiscardingComplete = true;
    }

    // checks if the player has discarded enough cards.
    public IEnumerator CardDiscard(int playerNumber, int totalCards)
    {
        playerDiscarded = false;

        // dividing integers always round down, this adhires to Catan's rules.
        int numberOfCardsTarget = totalCards / 2;


        StartCoroutine(CheckDiscardedCards(numberOfCardsTarget));


        yield return new WaitUntil(() => playerDiscarded);

    }

    // Repeat coroutine until number of cards target is equal.
    public IEnumerator CheckDiscardedCards(int numberOfCardsToRemain)
    {
        int numberOfCards = 0;
        // grab player number from list and check script
        switch (turnManager.playerToPlay)
        {

            case 1:
                numberOfCards = turnManager.playerList[0].GetComponent<PlayerManager>().ReturnNumberOfRCCards();
                break;
            case 2:
                numberOfCards = turnManager.playerList[1].GetComponent<PlayerManager>().ReturnNumberOfRCCards();
                break;
            case 3:
                numberOfCards = turnManager.playerList[2].GetComponent<PlayerManager>().ReturnNumberOfRCCards();
                break;
            case 4:
                numberOfCards = turnManager.playerList[3].GetComponent<PlayerManager>().ReturnNumberOfRCCards();
                break;
            default:
                Debug.LogError("NUMBER OF CCARD CHECK ERROR");
                break;

        }

        if (numberOfCards <= numberOfCardsToRemain)
        {
            playerDiscarded = true;
            Debug.Log("Player finished discarding");
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(CheckDiscardedCards(numberOfCardsToRemain));
        }
    }

    // after card discarding complete, trigger robber movement.
    public IEnumerator TriggerRobberMovement()
    {

        yield return new WaitUntil(() => cardDiscardingComplete);

        //force turn set to player who rolled seven
        turnManager.ForcePlayerTurn(turnManager.playerWhoRolledSeven);


        Debug.Log("Card Discarding now complete");
        loseCardsObject.SetActive(false);
        robber.TriggerRobberMovement();
    }
}
