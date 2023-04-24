using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSettlement : MonoBehaviour
{
    private GameObject settlement;
    private int[] hexNumbers = new int[3];
    public BoardGraph bg;
    private BoardVertex[] verticies = new BoardVertex[3];
    public bool isOnEdge;

    public BoardSettlement(KeyValuePair<string, GameObject> keyValuePair){
        string[] strlist = keyValuePair.Key.Split(",");
        for(int i = 0; i < strlist.Length - 1; i++){
            hexNumbers[i] = int.Parse(strlist[i]);
        }

        if(hexNumbers[1] == -1 && hexNumbers[2] == -1){
            isOnEdge = true;
        } else {
            isOnEdge = false;
        }

        for(int j = 0; j < 3; j++){
            if(hexNumbers[j] == -1){
                verticies[j] = null;
            } else {
                verticies[j] = bg.verticies[hexNumbers[j]];
            }
        }
    }

    public GameObject getSettlment(){
        return settlement;
    }

    public BoardVertex[] getHexObjects(){
        return verticies;
    }
}
