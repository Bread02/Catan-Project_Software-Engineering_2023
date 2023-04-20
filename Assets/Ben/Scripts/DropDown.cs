using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    [SerializeField] private GameObject playerParentObj;
    [SerializeField] private GameObject bankMang;

    public TurnManager turnManager;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void SelectCard(int val)
    {
        string key = "";
        switch (val)
        {
            case 0: //grain
                key = "grain";
                break;
            case 1: //wool
                key = "wool";
                break;
            case 2: //ore
                key = "ore";
                break;
            case 3: //brick
                key = "brick";
                break;
            case 4: //lumber
                key = "lumber";
                break;
            case 5: //knight
                key = "knight";
                break;
            case 6: //yearOfPlenty
                key = "yearOfPlenty";
                break;
            case 7: //monopoly
                key = "monopoly";
                break;
            case 8: //roadBuilding
                key = "roadBuilding";
                break;
            case 9: //victoryPoints
                key = "victoryPoints";
                break;
        }
        turnManager.ReturnCurrentPlayer().IncOrDecValue(key, 1);
        bankMang.GetComponent<BankManager>().IncOrDecValue(key, -1);
    }
}
