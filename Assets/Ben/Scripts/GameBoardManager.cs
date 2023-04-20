/*
 * Code mainly sourced from: https://youtu.be/h6y7QtDNfpA
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    [HideInInspector] public Vector3 CurrentMousePosition;
    private Camera mainCamera;

    private TurnManager turnManager;

  //  [SerializeField] private GameObject playerMang;

    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    void Update()
    {
        mainCamera = Camera.main;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("GameBoard")) continue;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);

            CurrentMousePosition = hit.point;

            break;
        }
    }

    
    private void OnTriggerEnter(Collider cardPlayed)
    {
        if (!cardPlayed.gameObject.CompareTag("Dice") && !cardPlayed.gameObject.CompareTag("RollTable") && !cardPlayed.gameObject.CompareTag("Furniture"))
        {
            turnManager.ReturnCurrentPlayer().GetComponent<PlayerManager>().IncOrDecValue(cardPlayed.gameObject.tag, -1, cardPlayed.gameObject);
            turnManager.ReturnCurrentPlayer().GetComponent<PlayerManager>().IncOrDecValue(cardPlayed.gameObject.tag, 1);
        }
    }
    
}
