using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Checks which player has the largest army.
public class LargestArmyCheck : MonoBehaviour
{
    public TurnManager turnManager;

    public List<PlayerManager> playersWithMoreThan3;
    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // check if any player has largest army
    // if any player has 3 or more army cards, give them the award.
    // If more than 1 player has 3 or more cards, award to player with most cards, or player who got achievement first.
    public void CheckLongestArmy()
    {
        // GO THROUGH PLAYER LIST

        for (int i = 0; i < turnManager.playerList.Count; i++)
        {
        //    if(turnManager.playerList[i].GetComponent<PlayerManager>().n)
        }
    }
}
