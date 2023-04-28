using UnityEngine;

/**
 * This script ensures that if a player 'throws' a card away from the table in the game,
 * the card is returned back to the player's hand.
 * 
 * @author Ben Conway
 * @version 28/04/2023
 */
public class SideOfGameBoardCollider : MonoBehaviour
{
    private TurnManager turnManager;

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    private void OnTriggerEnter(Collider cardPlayed)
    {
        turnManager.ReturnCurrentPlayer().GetComponent<PlayerManager>().IncOrDecValue(cardPlayed.gameObject.tag, -1, cardPlayed.gameObject);
        turnManager.ReturnCurrentPlayer().GetComponent<PlayerManager>().IncOrDecValue(cardPlayed.gameObject.tag, 1);
    }
}
