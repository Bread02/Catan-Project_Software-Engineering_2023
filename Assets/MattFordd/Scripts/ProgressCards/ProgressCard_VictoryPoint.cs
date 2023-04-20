using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCard_VictoryPoint : ProgressCards
{
    //public VictoryPoints player;

    public override void Use() {
        //player.AddPoints(1);
        Debug.Log("Victory Point Card Used!");
    }
}
