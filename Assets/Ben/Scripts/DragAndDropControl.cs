/*
 * Code mainly sourced from: https://youtu.be/h6y7QtDNfpA
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropControl : MonoBehaviour
{
    private TurnManager turnManager;
    private new Rigidbody rigidbody;
    private GameBoardManager board;

    private int playerNumWhoOwnsThisCard;

    private WarningText warningText;

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        board = GameObject.FindGameObjectWithTag("GameBoard").GetComponent<GameBoardManager>();
        rigidbody = GetComponent<Rigidbody>();
        warningText = GameObject.Find("PlayerWarningBox").GetComponent<WarningText>();
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
        if(this.gameObject.tag == "victoryPoints")
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
        else if (turnManager.ReturnCurrentPlayer().playerNumber == playerNumWhoOwnsThisCard)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            Vector3 newWorldPosition = new Vector3(board.CurrentMousePosition.x, 0.4f, board.CurrentMousePosition.z);

            var difference = newWorldPosition - transform.position;

            var speed = 10 * difference;
            rigidbody.velocity = speed;
        }
    }
}
