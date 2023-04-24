using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGraph : MonoBehaviour
{

    [Header("Board Keys")]
    [SerializeField] public List<string> keys;

    [Header("Board Game Objects")]
    [SerializeField] public List<GameObject> values;

    [Header("Graph")]
    public List<BoardVertex> verticies = new List<BoardVertex>();
    public List<BoardEdge> edges = new List<BoardEdge>();
    public List<BoardSettlement> settlements = new List<BoardSettlement>();

    void Awake()
    {
        int i = 0;
        foreach(string key in keys){
            switch(key[0]){
                case 'h':
                    AddHex(new KeyValuePair<string, GameObject>(key.Substring(1), values[i]));
                    break;
                case 'r':
                    AddRoad(new KeyValuePair<string, GameObject>(key.Substring(1), values[i]));
                    break;
                case 's':
                    AddSettlement(new KeyValuePair<string, GameObject>(key.Substring(1), values[i]));
                    break;
                default:
                    break;
            }    
            i++;
        }
        
    }

    void AddHex(KeyValuePair<string, GameObject> keyAndValue){
        verticies.Add(new BoardVertex(keyAndValue));
    }

    void AddRoad(KeyValuePair<string, GameObject> keyAndValue){
        edges.Add(new BoardEdge(keyAndValue, verticies));
    }

    void AddSettlement(KeyValuePair<string, GameObject> keyAndValue){
        settlements.Add(new BoardSettlement(keyAndValue, verticies));
    }

    public List<BoardVertex> getVertexArray(){
        return verticies;
    }
}
