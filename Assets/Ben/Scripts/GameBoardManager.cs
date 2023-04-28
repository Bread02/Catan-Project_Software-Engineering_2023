using UnityEngine;

/**
 * This script is vital for the drag and drop mechanic. It is attached to the 'TableTop' object in the game and provides an area
 * that a CardPrefab object can be controlled by the player.
 * 
 * The author of this script takes no credit for the code that enables this functionality, which is in the Update method.
 * The original source can be found via the following YouTube tutorial: https://youtu.be/h6y7QtDNfpA
 * 
 * @author Ben Conway
 * @version 28/04/2023
 */
public class GameBoardManager : MonoBehaviour
{
    [HideInInspector] public Vector3 CurrentMousePosition;
    private Camera mainCamera;

    private TurnManager turnManager;

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
