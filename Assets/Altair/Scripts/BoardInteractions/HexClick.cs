using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HexClick : MonoBehaviour
{
    public HexBorderClick hexBorderClick;


    [Header("SELECTED HEX OR BORDER")]
    [SerializeField] public GameObject selectedHexOrBorder;



    [SerializeField] public List<GameObject> listOfHex;

    // plan to encapsulate later
    // public access needed for BoardHexHover
    [Header("Hexes")]
    [SerializeField] public GameObject hex1;
    [SerializeField] public GameObject hex2;
    [SerializeField] public GameObject hex3;
    [SerializeField] public GameObject hex4;
    [SerializeField] public GameObject hex5;
    [SerializeField] public GameObject hex6;
    [SerializeField] public GameObject hex7;
    [SerializeField] public GameObject hex8;
    [SerializeField] public GameObject hex9;
    [SerializeField] public GameObject hex10;
    [SerializeField] public GameObject hex11;
    [SerializeField] public GameObject hex12;
    [SerializeField] public GameObject hex13;
    [SerializeField] public GameObject hex14;
    [SerializeField] public GameObject hex15;
    [SerializeField] public GameObject hex16;
    [SerializeField] public GameObject hex17;
    [SerializeField] public GameObject hex18;
    [SerializeField] public GameObject hex19;

    [SerializeField] public Color hexDefaultColor;
    [SerializeField] public Color hexHoveredColor;
    [SerializeField] public Color hexSelectedColor;



    [SerializeField] public TextMeshProUGUI notificationText;


    // Start is called before the first frame update
    void Start()
    {
        AddAllHexToList();
    }

    private void AddAllHexToList()
    {
        listOfHex.Add(hex1);
        listOfHex.Add(hex2);
        listOfHex.Add(hex3);
        listOfHex.Add(hex4);
        listOfHex.Add(hex5);
        listOfHex.Add(hex6);
        listOfHex.Add(hex7);
        listOfHex.Add(hex8);
        listOfHex.Add(hex9);
        listOfHex.Add(hex10);
        listOfHex.Add(hex11);
        listOfHex.Add(hex12);
        listOfHex.Add(hex13);
        listOfHex.Add(hex14);
        listOfHex.Add(hex15);
        listOfHex.Add(hex16);
        listOfHex.Add(hex17);
        listOfHex.Add(hex18);
        listOfHex.Add(hex19);

    }

    public void UnselectAllHexDirect()
    {
        foreach (var hex in listOfHex)
        {
            if (hex != selectedHexOrBorder)
            {
                hex.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexDefaultColor;
            }
        }
        hexBorderClick.UnselectAllBorders();
    }

    public void UnselectAllHex()
    {
        foreach (var hex in listOfHex)
        {
            hex.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexDefaultColor;
        }
    }

    // click hex
    #region ClickHex
    // each method in the click hex region is connected to the hex button.
    // Clicking the button will select the hex where the player can do further actions with the specific hex.
    public void ClickHex1()
    {
        hex1.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex1;
        notificationText.text = "Selected Hex 1";
        UnselectAllHexDirect();

    }
    public void ClickHex2()
    {
        hex2.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex2;
        notificationText.text = "Selected Hex 2";
        UnselectAllHexDirect();


    }

    public void ClickHex3()
    {
        hex3.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex3;
        notificationText.text = "Selected Hex 3";
        UnselectAllHexDirect();

    }

    public void ClickHex4()
    {
        hex4.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex4;
        notificationText.text = "Selected Hex 4";
        UnselectAllHexDirect();

    }

    public void ClickHex5()
    {
        hex5.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex5;
        notificationText.text = "Selected Hex 5";
        UnselectAllHexDirect();

    }

    public void ClickHex6()
    {
        hex6.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex6;
        notificationText.text = "Selected Hex 6";
        UnselectAllHexDirect();

    }

    public void ClickHex7()
    {
        hex7.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex7;
        notificationText.text = "Selected Hex 7";
        UnselectAllHexDirect();

    }

    public void ClickHex8()
    {
        hex8.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex8;
        notificationText.text = "Selected Hex 8";
        UnselectAllHexDirect();

    }

    public void ClickHex9()
    {
        UnselectAllHexDirect();
        hex9.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex9;
        notificationText.text = "Selected Hex 9";

    }

    public void ClickHex10()
    {
        UnselectAllHexDirect();
        hex10.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex10;
        notificationText.text = "Selected Hex 10";

    }

    public void ClickHex11()
    {
        UnselectAllHexDirect();
        hex11.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex11;
        notificationText.text = "Selected Hex 11";

    }

    public void ClickHex12()
    {
        UnselectAllHexDirect();
        hex12.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex12;
        notificationText.text = "Selected Hex 12";

    }

    public void ClickHex13()
    {
        UnselectAllHexDirect();
        hex13.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex13;
        notificationText.text = "Selected Hex 13";

    }
    public void ClickHex14()
    {
        UnselectAllHexDirect();
        hex14.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex14;
        notificationText.text = "Selected Hex 14";

    }
    public void ClickHex15()
    {
        UnselectAllHexDirect();
        hex15.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex15;
        notificationText.text = "Selected Hex 15";


    }
    public void ClickHex16()
    {
        UnselectAllHexDirect();
        hex16.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex16;
        notificationText.text = "Selected Hex 16";

    }
    public void ClickHex17()
    {
        UnselectAllHexDirect();
        hex17.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex17;
        notificationText.text = "Selected Hex 17";

    }
    public void ClickHex18()
    {
        UnselectAllHexDirect();
        hex18.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex18;
        notificationText.text = "Selected Hex 18";

    }
    public void ClickHex19()
    {
        UnselectAllHexDirect();
        hex19.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = hexSelectedColor;
        selectedHexOrBorder = hex19;
        notificationText.text = "Selected Hex 19";

    }
    #endregion
    // hover hex

}
