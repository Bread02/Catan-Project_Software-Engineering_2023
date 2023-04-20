using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCard_Knight : ProgressCards
{
    //public Robber robber;

    public ProgressCard_Knight() { 
        
    }

    public override void Use()
    {
        //robber.moveHex();
        Debug.Log("Knight Card Used!");
    }
}
