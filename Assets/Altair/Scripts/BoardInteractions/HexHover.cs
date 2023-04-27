using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * This script is responsbie for controlling hex hovering.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class HexHover : MonoBehaviour
{
    [SerializeField] private HexClick boardHexClick;
    [SerializeField] private HexBorderHover hexBorderHover;

    public void UnselectAllHoverHexDirect()
    {
        foreach (var hex in boardHexClick.listOfHex)
        {
            if (hex != boardHexClick.selectedHexOrBorder)
            {
                hex.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexDefaultColor;
            }
        }
        hexBorderHover.UnhoverAllBorders();

    }

    // This script is responsbie for unselecting the hover hex.
    public void UnselectAllHoverHex()
    {
        foreach (var hex in boardHexClick.listOfHex)
        {
            if (hex != boardHexClick.selectedHexOrBorder)
            {
                hex.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexDefaultColor;
            }
        }
    }

    // each method is tied to a button in the hover hex region.
    // putting a pointer over a button will trigger the method.

    // Each method is responsible for a different hex.
    public void HoverHex1()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex1.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex2()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex2.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex3()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex3.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex4()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex4.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex5()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex5.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex6()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex6.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex7()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex7.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex8()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex8.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex9()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex9.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex10()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex10.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex11()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex11.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex12()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex12.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex13()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex13.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex14()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex14.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex15()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex15.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex16()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex16.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex17()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex17.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex18()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex18.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }

    public void HoverHex19()
    {
        UnselectAllHoverHexDirect();
        boardHexClick.hex19.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = boardHexClick.hexHoveredColor;
    }
}
