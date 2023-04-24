using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVertex 
{
    private GameObject hex;
    private int key;

    public BoardVertex(KeyValuePair<string, GameObject> keyValuePair){
        key = int.Parse(keyValuePair.Key);
        hex = keyValuePair.Value;
    }

    public GameObject getHexTile(){
        return hex;
    }

    public int getKey(){
        return key;
    }
}
