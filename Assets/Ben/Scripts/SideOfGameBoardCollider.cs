using UnityEngine;

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
