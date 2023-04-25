using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Checks which player has the largest army.
public class LargestArmyCheck : MonoBehaviour
{
    private TurnManager turnManager;
    private BankManager bankManager;

    public List<PlayerManager> playersWithMoreThan2;

    // current largest player
    public PlayerManager playerWithBiggestArmy;

    public GameObject largestArmyCard;

    [Header("Largest Army Points")]
    public Transform largestArmy0Point;
    public Transform largestArmyP1Point;
    public Transform largestArmyP2Point;
    public Transform largestArmyP3Point;
    public Transform largestArmyP4Point;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        bankManager = GameObject.Find("THE_BANK").GetComponent<BankManager>();

        largestArmyCard.transform.position = largestArmy0Point.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // check if any player has largest army
    // if any player has 3 or more army cards, give them the award.
    // If more than 1 player has 3 or more cards, award to player with most cards, or player who got achievement first.
    public void CheckLargestArmy()
    {
        // Find players with more than 2
        for (int i = 0; i < turnManager.playerList.Count; i++)
        {
            if(turnManager.playerList[i].GetComponent<PlayerManager>().ReturnNumberOfKnightCardsPlayed() > 2)
            {
                if (!playersWithMoreThan2.Contains(turnManager.playerList[i]))
                {
                    playersWithMoreThan2.Add(turnManager.playerList[i]);
                }
            }
        }

        SetAllPlayersToFalse();

        if (playersWithMoreThan2.Count == 0)
        {
            // there is no player who wins this card.
        }

        if(playersWithMoreThan2.Count == 1)
        {
            // one player will win this card, we will give it to them.
            //    playersWithMoreThan2[0].PlayerHasLargestArmy = true;
            playerWithBiggestArmy = playersWithMoreThan2[0];
            playerWithBiggestArmy.SetLargestArmy(true);
            MoveLargestArmyCard();
            Debug.Log("Player now has largest army");
            return;
        }


        // else find who has the largest count
        // we will already have a max by this point.
        // if both are equal, keep to player who had highest first.
        if (playersWithMoreThan2.Count > 1)
        {
            // find largest
            for (int i = 0; i < playersWithMoreThan2.Count; i++)
            {
                if((playerWithBiggestArmy.ReturnNumberOfKnightCardsPlayed() < playersWithMoreThan2[i].ReturnNumberOfKnightCardsPlayed()) && (playerWithBiggestArmy != playersWithMoreThan2[i]))
                {
                    playerWithBiggestArmy = playersWithMoreThan2[i];
                    SetAllPlayersToFalse();
                    playerWithBiggestArmy.SetLargestArmy(true);
                    MoveLargestArmyCard();
                    // set all players to false
                    // then give it to this player
                }
            }

        }
    }

    public void SetAllPlayersToFalse()
    {
        for (int i = 0; i < turnManager.playerList.Count; i++)
        {
            turnManager.playerList[i].SetLargestArmy(false);
        }
    }

    public void MoveLargestArmyCard()
    {
        int playerNumber = 0;
        if (playerWithBiggestArmy != null)
        {
            playerNumber = playerWithBiggestArmy.playerNumber;

        }
        switch (playerNumber)
        {
            // no one has it
            case 0:
                return;
            case 1:
                largestArmyCard.transform.position = largestArmyP1Point.position;
                break;
            case 2:
                largestArmyCard.transform.position = largestArmyP2Point.position;
                break;
            case 3:
                largestArmyCard.transform.position = largestArmyP3Point.position;
                break;
            case 4:
                largestArmyCard.transform.position = largestArmyP4Point.position;
                break;
        }
    }
}
