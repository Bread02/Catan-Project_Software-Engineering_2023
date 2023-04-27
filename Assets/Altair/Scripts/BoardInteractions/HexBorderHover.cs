using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsbie for controlling hex border hover.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class HexBorderHover : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] private HexClick hexClick;
    [SerializeField] private HexHover hexHover;

    [Header("Lists")]
    public List<GameObject> listOfBorders = new List<GameObject>();

    [Header("Hex 1 Borders")]
    [SerializeField] public GameObject Hex1Border1;
    [SerializeField] public GameObject Hex1Border2;
    [SerializeField] public GameObject Hex1Border3;
    [SerializeField] public GameObject Hex1Border4;
    [SerializeField] public GameObject Hex1Border5;
    [SerializeField] public GameObject Hex1Border6;

    [Header("Hex 2 Borders")]
    [SerializeField] public GameObject Hex2Border1;
    [SerializeField] public GameObject Hex2Border2;
    [SerializeField] public GameObject Hex2Border3;
    [SerializeField] public GameObject Hex2Border4;
    [SerializeField] public GameObject Hex2Border6;

    [Header("Hex 3 Borders")]
    [SerializeField] public GameObject Hex3Border1;
    [SerializeField] public GameObject Hex3Border2;
    [SerializeField] public GameObject Hex3Border3;
    [SerializeField] public GameObject Hex3Border4;
    [SerializeField] public GameObject Hex3Border6;

    [Header("Hex 4 Borders")]
    [SerializeField] public GameObject Hex4Border2;
    [SerializeField] public GameObject Hex4Border3;
    [SerializeField] public GameObject Hex4Border4;
    [SerializeField] public GameObject Hex4Border5;
    [SerializeField] public GameObject Hex4Border6;

    [Header("Hex 5 Borders")]
    [SerializeField] public GameObject Hex5Border2;
    [SerializeField] public GameObject Hex5Border3;
    [SerializeField] public GameObject Hex5Border4;

    [Header("Hex 6 Borders")]
    [SerializeField] public GameObject Hex6Border2;
    [SerializeField] public GameObject Hex6Border3;
    [SerializeField] public GameObject Hex6Border4;

    [Header("Hex 7 Borders")]
    [SerializeField] public GameObject Hex7Border1;
    [SerializeField] public GameObject Hex7Border2;
    [SerializeField] public GameObject Hex7Border3;
    [SerializeField] public GameObject Hex7Border4;

    [Header("Hex 8 Borders")]
    [SerializeField] public GameObject Hex8Border2;
    [SerializeField] public GameObject Hex8Border3;
    [SerializeField] public GameObject Hex8Border4;
    [SerializeField] public GameObject Hex8Border5;
    [SerializeField] public GameObject Hex8Border6;

    [Header("Hex 9 Borders")]
    [SerializeField] public GameObject Hex9Border2;
    [SerializeField] public GameObject Hex9Border3;
    [SerializeField] public GameObject Hex9Border4;

    [Header("Hex 10 Borders")]
    [SerializeField] public GameObject Hex10Border2;
    [SerializeField] public GameObject Hex10Border3;
    [SerializeField] public GameObject Hex10Border4;

    [Header("Hex 11 Borders")]
    [SerializeField] public GameObject Hex11Border2;
    [SerializeField] public GameObject Hex11Border3;
    [SerializeField] public GameObject Hex11Border4;

    [Header("Hex 12 Borders")]
    [SerializeField] public GameObject Hex12Border1;
    [SerializeField] public GameObject Hex12Border2;
    [SerializeField] public GameObject Hex12Border3;
    [SerializeField] public GameObject Hex12Border4;

    [Header("Hex 13 Borders")]
    [SerializeField] public GameObject Hex13Border2;
    [SerializeField] public GameObject Hex13Border3;
    [SerializeField] public GameObject Hex13Border4;
    [SerializeField] public GameObject Hex13Border5;

    [Header("Hex 14 Borders")]
    [SerializeField] public GameObject Hex14Border2;
    [SerializeField] public GameObject Hex14Border3;
    [SerializeField] public GameObject Hex14Border4;

    [Header("Hex 15 Borders")]
    [SerializeField] public GameObject Hex15Border2;
    [SerializeField] public GameObject Hex15Border3;
    [SerializeField] public GameObject Hex15Border4;

    [Header("Hex 16 Borders")]
    [SerializeField] public GameObject Hex16Border2;
    [SerializeField] public GameObject Hex16Border3;
    [SerializeField] public GameObject Hex16Border4;

    [Header("Hex 17 Borders")]
    [SerializeField] public GameObject Hex17Border2;
    [SerializeField] public GameObject Hex17Border3;
    [SerializeField] public GameObject Hex17Border4;
    [SerializeField] public GameObject Hex17Border5;

    [Header("Hex 18 Borders")]
    [SerializeField] public GameObject Hex18Border2;
    [SerializeField] public GameObject Hex18Border3;
    [SerializeField] public GameObject Hex18Border4;

    [Header("Hex 19 Borders")]
    [SerializeField] public GameObject Hex19Border2;
    [SerializeField] public GameObject Hex19Border3;
    [SerializeField] public GameObject Hex19Border4;

    [SerializeField] public Material borderSelectedMaterial;
    [SerializeField] public Material borderHoveredMaterial;
    [SerializeField] public Material borderDefaultMaterial;

    public void Start()
    {
        AddAllBordersToList();
    }

    // adds all the borders to the list.
    public void AddAllBordersToList()
    {
        listOfBorders.Add(Hex1Border1);
        listOfBorders.Add(Hex1Border2);
        listOfBorders.Add(Hex1Border3);
        listOfBorders.Add(Hex1Border4);
        listOfBorders.Add(Hex1Border5);
        listOfBorders.Add(Hex1Border6);

        listOfBorders.Add(Hex2Border1);
        listOfBorders.Add(Hex2Border2);
        listOfBorders.Add(Hex2Border3);
        listOfBorders.Add(Hex2Border4);
  //      listOfBorders.Add(Hex2Border5);
        listOfBorders.Add(Hex2Border6);

        listOfBorders.Add(Hex3Border1);
        listOfBorders.Add(Hex3Border2);
        listOfBorders.Add(Hex3Border3);
        listOfBorders.Add(Hex3Border4);
  //      listOfBorders.Add(Hex3Border5);
        listOfBorders.Add(Hex3Border6);

   //     listOfBorders.Add(Hex4Border1);
        listOfBorders.Add(Hex4Border2);
        listOfBorders.Add(Hex4Border3);
        listOfBorders.Add(Hex4Border4);
        listOfBorders.Add(Hex4Border5);
        listOfBorders.Add(Hex4Border6);

 //       listOfBorders.Add(Hex5Border1);
        listOfBorders.Add(Hex5Border2);
        listOfBorders.Add(Hex5Border3);
        listOfBorders.Add(Hex5Border4);
  //      listOfBorders.Add(Hex5Border5);
  //      listOfBorders.Add(Hex5Border6);

   //     listOfBorders.Add(Hex6Border1);
        listOfBorders.Add(Hex6Border2);
        listOfBorders.Add(Hex6Border3);
        listOfBorders.Add(Hex6Border4);
   //     listOfBorders.Add(Hex6Border5);
    //    listOfBorders.Add(Hex6Border6);

        listOfBorders.Add(Hex7Border1);
        listOfBorders.Add(Hex7Border2);
        listOfBorders.Add(Hex7Border3);
        listOfBorders.Add(Hex7Border4);
     //   listOfBorders.Add(Hex7Border5);
  //      listOfBorders.Add(Hex7Border6);

    //    listOfBorders.Add(Hex8Border1);
        listOfBorders.Add(Hex8Border2);
        listOfBorders.Add(Hex8Border3);
        listOfBorders.Add(Hex8Border4);
        listOfBorders.Add(Hex8Border5);
        listOfBorders.Add(Hex8Border6);

   //     listOfBorders.Add(Hex9Border1);
        listOfBorders.Add(Hex9Border2);
        listOfBorders.Add(Hex9Border3);
        listOfBorders.Add(Hex9Border4);
  //      listOfBorders.Add(Hex9Border5);
 //       listOfBorders.Add(Hex9Border6);

   //     listOfBorders.Add(Hex10Border1);
        listOfBorders.Add(Hex10Border2);
        listOfBorders.Add(Hex10Border3);
        listOfBorders.Add(Hex10Border4);
  //      listOfBorders.Add(Hex10Border5);
  //      listOfBorders.Add(Hex10Border6);

   //     listOfBorders.Add(Hex11Border1);
        listOfBorders.Add(Hex11Border2);
        listOfBorders.Add(Hex11Border3);
        listOfBorders.Add(Hex11Border4);
   //     listOfBorders.Add(Hex11Border5);
     //   listOfBorders.Add(Hex11Border6);

        listOfBorders.Add(Hex12Border1);
        listOfBorders.Add(Hex12Border2);
        listOfBorders.Add(Hex12Border3);
        listOfBorders.Add(Hex12Border4);
   //     listOfBorders.Add(Hex12Border5);
  //      listOfBorders.Add(Hex12Border6);

     //   listOfBorders.Add(Hex13Border1);
        listOfBorders.Add(Hex13Border2);
        listOfBorders.Add(Hex13Border3);
        listOfBorders.Add(Hex13Border4);
        listOfBorders.Add(Hex13Border5);
   //     listOfBorders.Add(Hex13Border6);

    //    listOfBorders.Add(Hex14Border1);
        listOfBorders.Add(Hex14Border2);
        listOfBorders.Add(Hex14Border3);
        listOfBorders.Add(Hex14Border4);
   //     listOfBorders.Add(Hex14Border5);
   //     listOfBorders.Add(Hex14Border6);

   //     listOfBorders.Add(Hex15Border1);
        listOfBorders.Add(Hex15Border2);
        listOfBorders.Add(Hex15Border3);
        listOfBorders.Add(Hex15Border4);
  //      listOfBorders.Add(Hex15Border5);
   //     listOfBorders.Add(Hex15Border6);

   //     listOfBorders.Add(Hex16Border1);
        listOfBorders.Add(Hex16Border2);
        listOfBorders.Add(Hex16Border3);
        listOfBorders.Add(Hex16Border4);
    //    listOfBorders.Add(Hex16Border5);
     //   listOfBorders.Add(Hex16Border6);

   //     listOfBorders.Add(Hex17Border1);
        listOfBorders.Add(Hex17Border2);
        listOfBorders.Add(Hex17Border3);
        listOfBorders.Add(Hex17Border4);
        listOfBorders.Add(Hex17Border5);
   //     listOfBorders.Add(Hex17Border6);

    //    listOfBorders.Add(Hex18Border1);
        listOfBorders.Add(Hex18Border2);
        listOfBorders.Add(Hex18Border3);
        listOfBorders.Add(Hex18Border4);
   //     listOfBorders.Add(Hex18Border5);
    //    listOfBorders.Add(Hex18Border6);

     //   listOfBorders.Add(Hex19Border1);
        listOfBorders.Add(Hex19Border2);
        listOfBorders.Add(Hex19Border3);
        listOfBorders.Add(Hex19Border4);
     //   listOfBorders.Add(Hex19Border5);
   //     listOfBorders.Add(Hex19Border6);

    }

    // unhovers all borders
    public void UnhoverAllBorders()
    {
        foreach (var border in listOfBorders)
        {
            if (border != hexClick.selectedHexOrBorder)
            {
                border.GetComponent<MeshRenderer>().material = borderDefaultMaterial;
            }
        }
        
    }

    // unhovers all borders directly
    public void UnhoverAllBordersDirect()
    {
        foreach (var border in listOfBorders)
        {
            if (border != hexClick.selectedHexOrBorder)
            {
                border.GetComponent<MeshRenderer>().material = borderDefaultMaterial;
            }
        }
        hexHover.UnselectAllHoverHex();
    }

    #region HOVER OVER BORDER
    #region Hex 1

    public void HoverHex1Border1()
    {
        UnhoverAllBordersDirect();
        Hex1Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex1Border2()
    {
        UnhoverAllBordersDirect();

        Hex1Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex1Border3()
    {
        UnhoverAllBordersDirect();

        Hex1Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex1Border4()
    {
        UnhoverAllBordersDirect();

        Hex1Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex1Border5()
    {
        UnhoverAllBordersDirect();

        Hex1Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex1Border6()
    {
        UnhoverAllBordersDirect();

        Hex1Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    #endregion

    // hex 2
    public void HoverHex2Border1()
    {
        UnhoverAllBordersDirect();

        Hex2Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex2Border2()
    {
        UnhoverAllBordersDirect();

        Hex2Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex2Border3()
    {
        UnhoverAllBordersDirect();

        Hex2Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex2Border4()
    {
        UnhoverAllBordersDirect();

        Hex2Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex2Border5()
    {
        //  Hex2Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex2Border6()
    {
        UnhoverAllBordersDirect();

        Hex2Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 3
    public void HoverHex3Border1()
    {
        UnhoverAllBordersDirect();

        Hex3Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex3Border2()
    {
        UnhoverAllBordersDirect();

        Hex3Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex3Border3()
    {
        UnhoverAllBordersDirect();

        Hex3Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex3Border4()
    {
        UnhoverAllBordersDirect();

        Hex3Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex3Border5()
    {
        //  Hex3Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex3Border6()
    {
        UnhoverAllBordersDirect();

        Hex3Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 4
    public void HoverHex4Border1()
    {
        //    Hex4Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex4Border2()
    {
        UnhoverAllBordersDirect();

        Hex4Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex4Border3()
    {
        UnhoverAllBordersDirect();

        Hex4Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex4Border4()
    {
        UnhoverAllBordersDirect();

        Hex4Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex4Border5()
    {
        UnhoverAllBordersDirect();

        Hex4Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex4Border6()
    {
        UnhoverAllBordersDirect();

        Hex4Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 5
    public void HoverHex5Border1()
    {
        //    Hex5Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex5Border2()
    {
        UnhoverAllBordersDirect();

        Hex5Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex5Border3()
    {
        UnhoverAllBordersDirect();

        Hex5Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex5Border4()
    {
        UnhoverAllBordersDirect();

        Hex5Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex5Border5()
    {
        //   Hex5Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex5Border6()
    {
        //    Hex5Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 6
    public void HoverHex6Border1()
    {
        //   Hex6Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex6Border2()
    {
        UnhoverAllBordersDirect();

        Hex6Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex6Border3()
    {
        UnhoverAllBordersDirect();

        Hex6Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex6Border4()
    {
        UnhoverAllBordersDirect();

        Hex6Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex6Border5()
    {
        //    Hex6Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex6Border6()
    {
        //   Hex6Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 7
    public void HoverHex7Border1()
    {
        UnhoverAllBordersDirect();

        Hex7Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex7Border2()
    {
        UnhoverAllBordersDirect();

        Hex7Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex7Border3()
    {
        UnhoverAllBordersDirect();

        Hex7Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex7Border4()
    {
        UnhoverAllBordersDirect();

        Hex7Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex7Border5()
    {
        //   Hex7Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex7Border6()
    {
        //    Hex7Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 8
    public void HoverHex8Border1()
    {
        //     Hex8Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex8Border2()
    {
        UnhoverAllBordersDirect();

        Hex8Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex8Border3()
    {
        UnhoverAllBordersDirect();

        Hex8Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex8Border4()
    {
        UnhoverAllBordersDirect();

        Hex8Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex8Border5()
    {
        UnhoverAllBordersDirect();

        Hex8Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex8Border6()
    {
        UnhoverAllBordersDirect();

        Hex8Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 9
    public void HoverHex9Border1()
    {
        //   Hex9Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex9Border2()
    {
        UnhoverAllBordersDirect();

        Hex9Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex9Border3()
    {
        UnhoverAllBordersDirect();

        Hex9Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex9Border4()
    {
        UnhoverAllBordersDirect();

        Hex9Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex9Border5()
    {
        //    Hex9Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex9Border6()
    {
        //     Hex9Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 10
    public void HoverHex10Border1()
    {
        //    Hex10Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex10Border2()
    {
        UnhoverAllBordersDirect();

        Hex10Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex10Border3()
    {
        UnhoverAllBordersDirect();

        Hex10Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex10Border4()
    {
        UnhoverAllBordersDirect();

        Hex10Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex10Border5()
    {
        //    Hex10Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex10Border6()
    {
        //      Hex10Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 11
    public void HoverHex11Border1()
    {
        //      Hex11Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex11Border2()
    {
        UnhoverAllBordersDirect();

        Hex11Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex11Border3()
    {
        UnhoverAllBordersDirect();

        Hex11Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex11Border4()
    {
        UnhoverAllBordersDirect();

        Hex11Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex11Border5()
    {
        //      Hex11Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex11Border6()
    {
        //   Hex11Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 12
    public void HoverHex12Border1()
    {
        UnhoverAllBordersDirect();

        Hex12Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex12Border2()
    {
        UnhoverAllBordersDirect();

        Hex12Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex12Border3()
    {
        UnhoverAllBordersDirect();

        Hex12Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex12Border4()
    {
        UnhoverAllBordersDirect();

        Hex12Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex12Border5()
    {
        //     Hex12Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex12Border6()
    {
        //     Hex12Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 13

    public void HoverHex13Border1()
    {
        //     Hex13Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex13Border2()
    {
        UnhoverAllBordersDirect();

        Hex13Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex13Border3()
    {
        UnhoverAllBordersDirect();

        Hex13Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex13Border4()
    {
        UnhoverAllBordersDirect();

        Hex13Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex13Border5()
    {
        UnhoverAllBordersDirect();

        Hex13Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex13Border6()
    {
        //   Hex13Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 14
    public void HoverHex14Border1()
    {
        //    Hex14Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex14Border2()
    {
        UnhoverAllBordersDirect();

        Hex14Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex14Border3()
    {
        UnhoverAllBordersDirect();

        Hex14Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex14Border4()
    {
        UnhoverAllBordersDirect();

        Hex14Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex14Border5()
    {
        //      Hex14Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex14Border6()
    {
        //   Hex14Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 15
    public void HoverHex15Border1()
    {
        //    Hex15Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex15Border2()
    {
        UnhoverAllBordersDirect();

        Hex15Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex15Border3()
    {
        UnhoverAllBordersDirect();

        Hex15Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex15Border4()
    {
        UnhoverAllBordersDirect();

        Hex15Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex15Border5()
    {
        //    Hex15Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex15Border6()
    {
        //   Hex15Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 16

    public void HoverHex16Border1()
    {
        //    Hex16Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex16Border2()
    {
        UnhoverAllBordersDirect();

        Hex16Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex16Border3()
    {
        UnhoverAllBordersDirect();

        Hex16Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex16Border4()
    {
        UnhoverAllBordersDirect();

        Hex16Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex16Border5()
    {
        //   Hex16Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex16Border6()
    {
        //  Hex16Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;
    }

    // hex 17
    public void HoverHex17Border1()
    {
        //    Hex17Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex17Border2()
    {
        UnhoverAllBordersDirect();

        Hex17Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex17Border3()
    {
        UnhoverAllBordersDirect();

        Hex17Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex17Border4()
    {
        UnhoverAllBordersDirect();

        Hex17Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex17Border5()
    {
        UnhoverAllBordersDirect();

        Hex17Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex17Border6()
    {
        //   Hex17Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 18
    public void HoverHex18Border1()
    {
        //    Hex18Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex18Border2()
    {
        UnhoverAllBordersDirect();

        Hex18Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex18Border3()
    {
        UnhoverAllBordersDirect();

        Hex18Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex18Border4()
    {
        UnhoverAllBordersDirect();

        Hex18Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex18Border5()
    {
        //    Hex18Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex18Border6()
    {
        //    Hex18Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    // hex 19
    public void HoverHex19Border1()
    {
        //   Hex19Border1.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex19Border2()
    {
        UnhoverAllBordersDirect();

        Hex19Border2.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex19Border3()
    {
        UnhoverAllBordersDirect();

        Hex19Border3.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }

    public void HoverHex19Border4()
    {
        UnhoverAllBordersDirect();

        Hex19Border4.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex19Border5()
    {
        //   Hex19Border5.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    public void HoverHex19Border6()
    {
        //    Hex19Border6.GetComponent<MeshRenderer>().material = borderHoveredMaterial;

    }
    #endregion


}
