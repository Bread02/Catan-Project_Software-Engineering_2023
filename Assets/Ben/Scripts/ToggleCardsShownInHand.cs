using UnityEngine;
using UnityEngine.UI;

/**
 * This script allows the player to toggle between viewing their resource cards and their development cards.
 * 
 * @author Ben Conway
 * @version 28/04/2023
 */
public class ToggleCardsShownInHand : MonoBehaviour
{
    private TurnManager turnManager;
    [SerializeField] private Button showRCbutton, showDCbutton;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    //Called by buttons
    public void ShowResourceCardsButtonPressed()
    {
        showRCbutton.gameObject.SetActive(false);
        turnManager.ReturnCurrentPlayer().ShowResourceCardsOnly();
        showDCbutton.gameObject.SetActive(true);
    }

    public void ShowDevelopmentCardsButtonPressed()
    {
        showDCbutton.gameObject.SetActive(false);
        turnManager.ReturnCurrentPlayer().ShowDevelopmentCardsOnly();
        showRCbutton.gameObject.SetActive(true);
    }
}
