using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSettlement : MonoBehaviour
{
    private GameObject settlement;
    private int[] hexNumbers = new int[3];
    private BoardVertex[] roadVerticies = new BoardVertex[3];
    public bool isOnEdge;

    public BoardSettlement(KeyValuePair<string, GameObject> keyValuePair, List<BoardVertex> verticies){
        string[] strlist = keyValuePair.Key.Split(",");
        settlement = keyValuePair.Value;

        for(int i = 0; i < strlist.Length; i++){
            hexNumbers[i] = int.Parse(strlist[i]);
        }

        if(hexNumbers[1] == -1 && hexNumbers[2] == -1){
            isOnEdge = true;
        } else {
            isOnEdge = false;
        }

        // - - - - - - - - - - - - WORKS TO HERE - - - - - - - - - - - -

        for(int j = 0; j < 3; j++){
            if(hexNumbers[j] == -1){
                roadVerticies[j] = null;
            } else {
                roadVerticies[j] = verticies[hexNumbers[j]];
            }
        }

    }

    public GameObject getSettlment(){
        return settlement;
    }

    public BoardVertex[] getHexObjects(){
        return roadVerticies;
    }
}
