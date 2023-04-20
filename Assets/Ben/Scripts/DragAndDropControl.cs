/*
 * Code mainly sourced from: https://youtu.be/h6y7QtDNfpA
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropControl : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private GameBoardManager board;

    void Start()
    {
        board = GameObject.FindGameObjectWithTag("GameBoard").GetComponent<GameBoardManager>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        Vector3 newWorldPosition = new Vector3(board.CurrentMousePosition.x, 0.4f, board.CurrentMousePosition.z);

        var difference = newWorldPosition - transform.position;

        var speed = 10 * difference;
        rigidbody.velocity = speed;
        //rigidbody.rotation = Quaternion.Euler(new Vector3(speed.z, 0, -speed.x));
    }
}
