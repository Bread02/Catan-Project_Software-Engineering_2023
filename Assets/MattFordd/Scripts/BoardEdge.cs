using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEdge : MonoBehaviour
{
    private GameObject road;
    private int[] hexes = new int[2];
    private BoardVertex[] settlementVerticies = new BoardVertex[2];
    public bool isOnEdge;

    public BoardEdge(KeyValuePair<string, GameObject> keyValuePair, List<BoardVertex> verticies){
        string[] strlist = keyValuePair.Key.Split(",");
        for(int i = 0; i < strlist.Length - 1; i++){
            hexes[i] = int.Parse(strlist[i]);
        }

        if(hexes[1] == -1){
            isOnEdge = true;
        } else {
            isOnEdge = false;
        }

        for(int j = 0; j < 2; j++){
            if(hexes[j] == -1){
                settlementVerticies[j] = null;
            } else {
                settlementVerticies[j] = verticies[hexes[j]];
            }
        }

        road = keyValuePair.Value;
    }

    public GameObject getRoad(){
        return road;
    }

    public BoardVertex[] getHexObjects(){
        return settlementVerticies;
    }
    
}
