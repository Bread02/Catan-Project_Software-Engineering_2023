using UnityEngine;

/**
 * This script enables a player to 'drag and drop' a CardPrefab object
 * 
 * The author of this script takes no credit for the code that enables this functionality, which can be found on lines 78-85.
 * The original source can be found via the following YouTube tutorial: https://youtu.be/h6y7QtDNfpA
 */
public class DragAndDropControl : MonoBehaviour
{
    private TurnManager turnManager;
    private new Rigidbody rigidbody;
    private GameBoardManager board;
    private MakeTrade makeTrade;

    private int playerNumWhoOwnsThisCard;

    private WarningText warningText;

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        board = GameObject.FindGameObjectWithTag("GameBoard").GetComponent<GameBoardManager>();
        rigidbody = GetComponent<Rigidbody>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
        makeTrade = GameObject.FindGameObjectWithTag("MakeTrade").GetComponent<MakeTrade>();
    }

    public void SetPlayerNumWhoOwnsThisCard(int playerNum)
    {
        playerNumWhoOwnsThisCard = playerNum;
    }

    public int GetPlayerNumWhoOwnsThisCard()
    {
        return playerNumWhoOwnsThisCard;
    }

    private void OnMouseDrag()
    {
        if(playerNumWhoOwnsThisCard != turnManager.ReturnCurrentPlayer().playerNumber)
        {
            StartCoroutine(warningText.WarningTextBox("You're not allowed to move another player's cards!"));
        }
        else if(this.gameObject.tag == "victoryPoints")
        {
            StartCoroutine(warningText.WarningTextBox("Victory Point cards cannot be controlled!"));
        }
        else if (!turnManager.finishedDiceRolling && (this.gameObject.tag == "brick" || this.gameObject.tag == "ore" || this.gameObject.tag == "lumber" || this.gameObject.tag == "grain" || this.gameObject.tag == "wool"))
        {
            StartCoroutine(warningText.WarningTextBox("Must roll dice before using resource cards!"));
        }
        else if (turnManager.hasUsedDevCardThisTurn && (this.gameObject.tag == "knight" || this.gameObject.tag == "monopoly" || this.gameObject.tag == "roadBuilding" || this.gameObject.tag == "yearOfPlenty"))
        {
            StartCoroutine(warningText.WarningTextBox("Only one development card can be played per turn!"));
        }
        else if (makeTrade.GetRoadBought())
        {
            StartCoroutine(warningText.WarningTextBox("Place road(s) pieces before moving cards!"));
        }
        else if (makeTrade.GetSettlementBought())
        {
            StartCoroutine(warningText.WarningTextBox("Place settlement(s) pieces before moving cards!"));
        }
        else if (makeTrade.GetCityBought())
        {
            StartCoroutine(warningText.WarningTextBox("Place city(s) pieces before moving cards!"));
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            Vector3 newWorldPosition = new Vector3(board.CurrentMousePosition.x, 0.4f, board.CurrentMousePosition.z);

            var difference = newWorldPosition - transform.position;

            var speed = 10 * difference;
            rigidbody.velocity = speed;
        }
    }
}
