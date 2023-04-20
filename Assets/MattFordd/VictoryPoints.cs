using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoints : MonoBehaviour
{
    private int victoryPoints;
    private bool hasWon = false;
    
    //initialises points to 0.
    void Start()
    {
        victoryPoints = 0;
    }

    // adds a specified amount of victory points to the players point count. Checks if the player has won.
    // an int representing the amount of points to be added.
    void AddPoints(int amount)
    {
        victoryPoints += amount;
        
        if (victoryPoints >= 10)
        {
            hasWon = true;
        }
    }

    // removes a specified amount of victory points from the players point count.
    // an int representingh the amount of points to be removed.
    void RemovePoints(int amount)
    {
        victoryPoints -= amount;
    }

}
