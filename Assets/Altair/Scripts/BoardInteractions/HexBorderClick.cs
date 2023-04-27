using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script the clicking of borders.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class HexBorderClick : MonoBehaviour
{
    public HexClick boardHexClick;
    public HexHover boardHexHover;

    public HexBorderHover hexBorderHover;


    public void UnselectAllBorders()
    {
        foreach (var border in hexBorderHover.listOfBorders)
        {
            if (border != boardHexClick.selectedHexOrBorder)
            {
                border.GetComponent<MeshRenderer>().material = hexBorderHover.borderDefaultMaterial;
            }
        }
    }

    public void UnselectAllBordersDirect()
    {
        foreach (var border in hexBorderHover.listOfBorders)
        {
            if (border != boardHexClick.selectedHexOrBorder)
            {
                border.GetComponent<MeshRenderer>().material = hexBorderHover.borderDefaultMaterial;
            }
        }
        boardHexClick.UnselectAllHex();
      //  boardHexHover.UnselectAllHoverHex();
    }

    public void ClickHex1Border1()
    {
        hexBorderHover.Hex1Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex1Border1;
        boardHexClick.notificationText.text = "Selected Hex 1 Border 1";
        UnselectAllBordersDirect();  
    }
    public void ClickHex1Border2()
    {
        hexBorderHover.Hex1Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex1Border2;
        boardHexClick.notificationText.text = "Selected Hex 1 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex1Border3()
    {
        hexBorderHover.Hex1Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex1Border3;
        boardHexClick.notificationText.text = "Selected Hex 1 Border 3";
        UnselectAllBordersDirect();
    }

    public void ClickHex1Border4()
    {
        hexBorderHover.Hex1Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex1Border4;
        boardHexClick.notificationText.text = "Selected Hex 1 Border 4";
        UnselectAllBordersDirect();
    }

    public void ClickHex1Border5()
    {
        hexBorderHover.Hex1Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex1Border5;
        boardHexClick.notificationText.text = "Selected Hex 1 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex1Border6()
    {
        hexBorderHover.Hex1Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex1Border6;
        boardHexClick.notificationText.text = "Selected Hex 1 Border 6";
        UnselectAllBordersDirect();
    }


    public void ClickHex2Border1()
    {
        hexBorderHover.Hex2Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex2Border1;
        boardHexClick.notificationText.text = "Selected Hex 2 Border 1";
        UnselectAllBordersDirect();
    }

    public void ClickHex2Border2()
    {
        hexBorderHover.Hex2Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex2Border2;
        boardHexClick.notificationText.text = "Selected Hex 2 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex2Border3()
    {
        hexBorderHover.Hex2Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex2Border3;
        boardHexClick.notificationText.text = "Selected Hex 2 Border 3";
        UnselectAllBordersDirect();
    }

    public void ClickHex2Border4()
    {
        hexBorderHover.Hex2Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex2Border4;
        boardHexClick.notificationText.text = "Selected Hex 2 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex2Border5()
    {
        hexBorderHover.Hex2Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex2Border5;
        boardHexClick.notificationText.text = "Selected Hex 2 Border 5";
        UnselectAllBordersDirect();
    }
    */

    public void ClickHex2Border6()
    {
        hexBorderHover.Hex2Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex2Border6;
        boardHexClick.notificationText.text = "Selected Hex 2 Border 6";
        UnselectAllBordersDirect();
    }

    public void ClickHex3Border1()
    {
        hexBorderHover.Hex3Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex3Border1;
        boardHexClick.notificationText.text = "Selected Hex 3 Border 1";
        UnselectAllBordersDirect();
    }

    public void ClickHex3Border2()
    {
        hexBorderHover.Hex3Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex3Border2;
        boardHexClick.notificationText.text = "Selected Hex 3 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex3Border3()
    {
        hexBorderHover.Hex3Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex3Border3;
        boardHexClick.notificationText.text = "Selected Hex 3 Border 3";
        UnselectAllBordersDirect();
    }

    public void ClickHex3Border4()
    {
        hexBorderHover.Hex3Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex3Border4;
        boardHexClick.notificationText.text = "Selected Hex 3 Border 4";
        UnselectAllBordersDirect();
    }
    /*
    public void ClickHex3Border5()
    {
        hexBorderHover.Hex3Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex3Border5;
        boardHexClick.notificationText.text = "Selected Hex 3 Border 5";
        UnselectAllBordersDirect();
    }
    */
    public void ClickHex3Border6()
    {
        hexBorderHover.Hex3Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex3Border6;
        boardHexClick.notificationText.text = "Selected Hex 3 Border 6";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex4Border1()
    {
        hexBorderHover.Hex4Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border1;
        boardHexClick.notificationText.text = "Selected Hex 4 Border 1";
        UnselectAllBordersDirect();
    }
    */
    public void ClickHex4Border2()
    {
        hexBorderHover.Hex4Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border2;
        boardHexClick.notificationText.text = "Selected Hex 4 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex4Border3()
    {
        hexBorderHover.Hex4Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border3;
        boardHexClick.notificationText.text = "Selected Hex 4 Border 3";
        UnselectAllBordersDirect();
    }

    public void ClickHex4Border4()
    {
        hexBorderHover.Hex4Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border4;
        boardHexClick.notificationText.text = "Selected Hex 4 Border 4";
        UnselectAllBordersDirect();
    }

    public void ClickHex4Border5()
    {
        hexBorderHover.Hex4Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border5;
        boardHexClick.notificationText.text = "Selected Hex 4 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex4Border6()
    {
        hexBorderHover.Hex4Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border6;
        boardHexClick.notificationText.text = "Selected Hex 4 Border 6";
        UnselectAllBordersDirect();
    }

    // hex 5
    /*
public void ClickHex4Border1()
{
    hexBorderHover.Hex4Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border1;
    boardHexClick.notificationText.text = "Selected Hex 4 Border 1";
    UnselectAllBordersDirect();
}
*/
    public void ClickHex5Border2()
    {
        hexBorderHover.Hex5Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex5Border2;
        boardHexClick.notificationText.text = "Selected Hex 5 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex5Border3()
    {
        hexBorderHover.Hex5Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex5Border3;
        boardHexClick.notificationText.text = "Selected Hex 5 Border 3";
        UnselectAllBordersDirect();
    }

    public void ClickHex5Border4()
    {
        hexBorderHover.Hex5Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex5Border4;
        boardHexClick.notificationText.text = "Selected Hex 5 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex5Border5()
    {
        hexBorderHover.Hex5Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex5Border5;
        boardHexClick.notificationText.text = "Selected Hex 5 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex5Border6()
    {
        hexBorderHover.Hex5Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex5Border6;
        boardHexClick.notificationText.text = "Selected Hex 5 Border 6";
        UnselectAllBordersDirect();
    }
    */

    /*
public void ClickHex4Border1()
{
    hexBorderHover.Hex4Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex4Border1;
    boardHexClick.notificationText.text = "Selected Hex 4 Border 1";
    UnselectAllBordersDirect();
}
*/
    /*
    public void ClickHex6Border1()
    {
        hexBorderHover.Hex6Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex6Border1;
        boardHexClick.notificationText.text = "Selected Hex 6 Border 2";
        UnselectAllBordersDirect();
    }
    */

    public void ClickHex6Border2()
    {
        hexBorderHover.Hex6Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex6Border2;
        boardHexClick.notificationText.text = "Selected Hex 6 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex6Border3()
    {
        hexBorderHover.Hex6Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex6Border3;
        boardHexClick.notificationText.text = "Selected Hex 6 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex6Border4()
    {
        hexBorderHover.Hex6Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex6Border4;
        boardHexClick.notificationText.text = "Selected Hex 6 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex6Border5()
    {
        hexBorderHover.Hex6Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex6Border5;
        boardHexClick.notificationText.text = "Selected Hex 6 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex6Border6()
    {
        hexBorderHover.Hex6Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex6Border6;
        boardHexClick.notificationText.text = "Selected Hex 6 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 7
    public void ClickHex7Border1()
    {
        hexBorderHover.Hex7Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex7Border1;
        boardHexClick.notificationText.text = "Selected Hex 7 Border 1";
        UnselectAllBordersDirect();
    }
    

    public void ClickHex7Border2()
    {
        hexBorderHover.Hex7Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex7Border2;
        boardHexClick.notificationText.text = "Selected Hex 7 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex7Border3()
    {
        hexBorderHover.Hex7Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex7Border3;
        boardHexClick.notificationText.text = "Selected Hex 7 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex7Border4()
    {
        hexBorderHover.Hex7Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex7Border4;
        boardHexClick.notificationText.text = "Selected Hex 7 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex7Border5()
    {
        hexBorderHover.Hex7Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex7Border5;
        boardHexClick.notificationText.text = "Selected Hex 7 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex7Border6()
    {
        hexBorderHover.Hex7Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex7Border6;
        boardHexClick.notificationText.text = "Selected Hex 7 Border 6";
        UnselectAllBordersDirect();
    }

    */

    // hex 8
    /*
    public void ClickHex8Border1()
    {
        hexBorderHover.Hex8Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex8Border1;
        boardHexClick.notificationText.text = "Selected Hex 8 Border 1";
        UnselectAllBordersDirect();
    }

    */
    public void ClickHex8Border2()
    {
        hexBorderHover.Hex8Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex8Border2;
        boardHexClick.notificationText.text = "Selected Hex 8 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex8Border3()
    {
        hexBorderHover.Hex8Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex8Border3;
        boardHexClick.notificationText.text = "Selected Hex 8 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex8Border4()
    {
        hexBorderHover.Hex8Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex8Border4;
        boardHexClick.notificationText.text = "Selected Hex 8 Border 4";
        UnselectAllBordersDirect();
    }
    
    
    public void ClickHex8Border5()
    {
        hexBorderHover.Hex8Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex8Border5;
        boardHexClick.notificationText.text = "Selected Hex 8 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex8Border6()
    {
        hexBorderHover.Hex8Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex8Border6;
        boardHexClick.notificationText.text = "Selected Hex 8 Border 6";
        UnselectAllBordersDirect();
    }

    // hex 9
    
    /*
    public void ClickHex9Border1()
    {
        hexBorderHover.Hex9Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex9Border1;
        boardHexClick.notificationText.text = "Selected Hex 9 Border 1";
        UnselectAllBordersDirect();
    }
    */
    public void ClickHex9Border2()
    {
        hexBorderHover.Hex9Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex9Border2;
        boardHexClick.notificationText.text = "Selected Hex 9 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex9Border3()
    {
        hexBorderHover.Hex9Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex9Border3;
        boardHexClick.notificationText.text = "Selected Hex 9 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex9Border4()
    {
        hexBorderHover.Hex9Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex9Border4;
        boardHexClick.notificationText.text = "Selected Hex 9 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex9Border5()
    {
        hexBorderHover.Hex9Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex9Border5;
        boardHexClick.notificationText.text = "Selected Hex 9 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex9Border6()
    {
        hexBorderHover.Hex9Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex9Border6;
        boardHexClick.notificationText.text = "Selected Hex 9 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 10
    /*
public void ClickHex10Border1()
{
    hexBorderHover.Hex10Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex10Border1;
    boardHexClick.notificationText.text = "Selected Hex 10 Border 1";
    UnselectAllBordersDirect();
}
    */
    public void ClickHex10Border2()
    {
        hexBorderHover.Hex10Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex10Border2;
        boardHexClick.notificationText.text = "Selected Hex 10 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex10Border3()
    {
        hexBorderHover.Hex10Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex10Border3;
        boardHexClick.notificationText.text = "Selected Hex 10 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex10Border4()
    {
        hexBorderHover.Hex10Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex10Border4;
        boardHexClick.notificationText.text = "Selected Hex 10 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex10Border5()
    {
        hexBorderHover.Hex10Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex10Border5;
        boardHexClick.notificationText.text = "Selected Hex 10 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex10Border6()
    {
        hexBorderHover.Hex10Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex10Border6;
        boardHexClick.notificationText.text = "Selected Hex 10 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 11
    
    /*
public void ClickHex11Border1()
{
    hexBorderHover.Hex11Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border1;
    boardHexClick.notificationText.text = "Selected Hex 11 Border 1";
    UnselectAllBordersDirect();
}
    */
    
    public void ClickHex11Border2()
    {
        hexBorderHover.Hex11Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border2;
        boardHexClick.notificationText.text = "Selected Hex 11 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex11Border3()
    {
        hexBorderHover.Hex11Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border3;
        boardHexClick.notificationText.text = "Selected Hex 11 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex11Border4()
    {
        hexBorderHover.Hex11Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border4;
        boardHexClick.notificationText.text = "Selected Hex 11 Border 4";
        UnselectAllBordersDirect();
    }
    /*
    
    public void ClickHex11Border5()
    {
        hexBorderHover.Hex11Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border5;
        boardHexClick.notificationText.text = "Selected Hex 11 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex11Border6()
    {
        hexBorderHover.Hex11Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border6;
        boardHexClick.notificationText.text = "Selected Hex 11 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 12

    
public void ClickHex12Border1()
{
    hexBorderHover.Hex12Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex12Border1;
    boardHexClick.notificationText.text = "Selected Hex 12 Border 1";
    UnselectAllBordersDirect();
}
    

    public void ClickHex12Border2()
    {
        hexBorderHover.Hex12Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex12Border2;
        boardHexClick.notificationText.text = "Selected Hex 12 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex12Border3()
    {
        hexBorderHover.Hex12Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex12Border3;
        boardHexClick.notificationText.text = "Selected Hex 12 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex12Border4()
    {
        hexBorderHover.Hex11Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex12Border4;
        boardHexClick.notificationText.text = "Selected Hex 12 Border 4";
        UnselectAllBordersDirect();
    }
    /*
    
    public void ClickHex12Border5()
    {
        hexBorderHover.Hex12Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex11Border5;
        boardHexClick.notificationText.text = "Selected Hex 12 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex12Border6()
    {
        hexBorderHover.Hex12Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex12Border6;
        boardHexClick.notificationText.text = "Selected Hex 12 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 13

    /*
    public void ClickHex13Border1()
    {
        hexBorderHover.Hex13Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex13Border1;
        boardHexClick.notificationText.text = "Selected Hex 13 Border 1";
        UnselectAllBordersDirect();
    }

    */
    public void ClickHex13Border2()
    {
        hexBorderHover.Hex13Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex13Border2;
        boardHexClick.notificationText.text = "Selected Hex 13 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex13Border3()
    {
        hexBorderHover.Hex13Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex13Border3;
        boardHexClick.notificationText.text = "Selected Hex 13 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex13Border4()
    {
        hexBorderHover.Hex13Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex13Border4;
        boardHexClick.notificationText.text = "Selected Hex 13 Border 4";
        UnselectAllBordersDirect();
    }
    
    
    public void ClickHex13Border5()
    {
        hexBorderHover.Hex13Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex13Border5;
        boardHexClick.notificationText.text = "Selected Hex 13 Border 5";
        UnselectAllBordersDirect();
    }
    /*

    public void ClickHex12Border6()
    {
        hexBorderHover.Hex12Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex13Border6;
        boardHexClick.notificationText.text = "Selected Hex 13 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 14

    
    /*
    public void ClickHex14Border1()
    {
        hexBorderHover.Hex14Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex14Border1;
        boardHexClick.notificationText.text = "Selected Hex 14 Border 1";
        UnselectAllBordersDirect();
    }
    */
    
    public void ClickHex14Border2()
    {
        hexBorderHover.Hex14Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex14Border2;
        boardHexClick.notificationText.text = "Selected Hex 14 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex14Border3()
    {
        hexBorderHover.Hex14Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex14Border3;
        boardHexClick.notificationText.text = "Selected Hex 14 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex14Border4()
    {
        hexBorderHover.Hex14Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex14Border4;
        boardHexClick.notificationText.text = "Selected Hex 14 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex14Border5()
    {
        hexBorderHover.Hex14Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex14Border5;
        boardHexClick.notificationText.text = "Selected Hex 14 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex14Border6()
    {
        hexBorderHover.Hex14Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex14Border6;
        boardHexClick.notificationText.text = "Selected Hex 14 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 15
    
    /*
public void ClickHex15Border1()
{
    hexBorderHover.Hex15Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border1;
    boardHexClick.notificationText.text = "Selected Hex 15 Border 1";
    UnselectAllBordersDirect();
}
    */

    public void ClickHex15Border2()
    {
        hexBorderHover.Hex15Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border2;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex15Border3()
    {
        hexBorderHover.Hex15Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border3;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex15Border4()
    {
        hexBorderHover.Hex15Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border4;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex15Border5()
    {
        hexBorderHover.Hex15Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border5;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex15Border6()
    {
        hexBorderHover.Hex15Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border6;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 6";
        UnselectAllBordersDirect();
    }
    
    */

    // hex 16

    /*
public void ClickHex16Border1()
{
    hexBorderHover.Hex15Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border1;
    boardHexClick.notificationText.text = "Selected Hex 15 Border 1";
    UnselectAllBordersDirect();
}
    */

    public void ClickHex16Border2()
    {
        hexBorderHover.Hex16Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex16Border2;
        boardHexClick.notificationText.text = "Selected Hex 16 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex16Border3()
    {
        hexBorderHover.Hex16Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex16Border3;
        boardHexClick.notificationText.text = "Selected Hex 16 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex16Border4()
    {
        hexBorderHover.Hex16Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex16Border4;
        boardHexClick.notificationText.text = "Selected Hex 16 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex16Border5()
    {
        hexBorderHover.Hex15Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border5;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 5";
        UnselectAllBordersDirect();
    }

    public void ClickHex16Border6()
    {
        hexBorderHover.Hex15Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex15Border6;
        boardHexClick.notificationText.text = "Selected Hex 15 Border 6";
        UnselectAllBordersDirect();
    }
    
    */

    // hex 17

    /*
public void ClickHex17Border1()
{
    hexBorderHover.Hex17Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border1;
    boardHexClick.notificationText.text = "Selected Hex 17 Border 1";
    UnselectAllBordersDirect();
}
    */

    public void ClickHex17Border2()
    {
        hexBorderHover.Hex17Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border2;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex17Border3()
    {
        hexBorderHover.Hex17Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border3;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex17Border4()
    {
        hexBorderHover.Hex17Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border4;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 4";
        UnselectAllBordersDirect();
    }

    
    public void ClickHex17Border5()
    {
        hexBorderHover.Hex17Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border5;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 5";
        UnselectAllBordersDirect();
    }
    /*

    public void ClickHex16Border6()
    {
        hexBorderHover.Hex17Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border6;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 6";
        UnselectAllBordersDirect();
    }
    */

    // hex 18

    /*
public void ClickHex18Border1()
{
    hexBorderHover.Hex18Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex18Border1;
    boardHexClick.notificationText.text = "Selected Hex 18 Border 1";
    UnselectAllBordersDirect();
}
    */

    public void ClickHex18Border2()
    {
        hexBorderHover.Hex18Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex18Border2;
        boardHexClick.notificationText.text = "Selected Hex 18 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex18Border3()
    {
        hexBorderHover.Hex18Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex18Border3;
        boardHexClick.notificationText.text = "Selected Hex 18 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex18Border4()
    {
        hexBorderHover.Hex18Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex18Border4;
        boardHexClick.notificationText.text = "Selected Hex 18 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex18Border5()
    {
        hexBorderHover.Hex18Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex18Border5;
        boardHexClick.notificationText.text = "Selected Hex 18 Border 5";
        UnselectAllBordersDirect();
    }
    

    public void ClickHex16Border6()
    {
        hexBorderHover.Hex17Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex17Border6;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 6";
        UnselectAllBordersDirect();
    }
    
    */

    // hex 19

    /*
public void ClickHex19Border1()
{
    hexBorderHover.Hex19Border1.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
    boardHexClick.selectedHexOrBorder = hexBorderHover.Hex19Border1;
    boardHexClick.notificationText.text = "Selected Hex 19 Border 1";
    UnselectAllBordersDirect();
}
    */

    public void ClickHex19Border2()
    {
        hexBorderHover.Hex19Border2.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex19Border2;
        boardHexClick.notificationText.text = "Selected Hex 19 Border 2";
        UnselectAllBordersDirect();
    }

    public void ClickHex19Border3()
    {
        hexBorderHover.Hex19Border3.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex19Border3;
        boardHexClick.notificationText.text = "Selected Hex 19 Border 3";
        UnselectAllBordersDirect();
    }



    public void ClickHex19Border4()
    {
        hexBorderHover.Hex19Border4.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex19Border4;
        boardHexClick.notificationText.text = "Selected Hex 19 Border 4";
        UnselectAllBordersDirect();
    }

    /*
    public void ClickHex19Border5()
    {
        hexBorderHover.Hex19Border5.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex19Border5;
        boardHexClick.notificationText.text = "Selected Hex 18 Border 5";
        UnselectAllBordersDirect();
    }
    

    public void ClickHex16Border6()
    {
        hexBorderHover.Hex19Border6.GetComponent<MeshRenderer>().material = hexBorderHover.borderSelectedMaterial;
        boardHexClick.selectedHexOrBorder = hexBorderHover.Hex19Border6;
        boardHexClick.notificationText.text = "Selected Hex 17 Border 6";
        UnselectAllBordersDirect();
    }
    */
    
}
