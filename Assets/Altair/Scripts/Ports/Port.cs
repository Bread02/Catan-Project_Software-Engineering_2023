using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script checks what type of port this is.
 *
 * @author Altair, Ben
 * @version 26/04/2023
 */
public class Port : MonoBehaviour
{
    public PortNumber portNumber;

    public enum PortNumber
    { 
        OneSix,
        TwoOne,
        ThreeTwo,
        FourThree,
        FiveFour,
        SixFive,
    }

    // designate the type of city this is.

    // if collider == city point, toggle the city point's port type.
    // This will ONLY WORK if there is ONE port for this edge.
    // If there are TWO ports on an edge, you need to get the child's colliders as there are two colliders.
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CityPoint"))
        {
            // only do port numbers with ONE port

            //TwoOne == random 3:1
            if(portNumber == PortNumber.TwoOne)
            {
                other.GetComponent<ChooseSettlement>().isImprovedHarbor = true;
            }
            //FourThree == Lumbar 2:1
            if (portNumber == PortNumber.FourThree)
            {
                other.GetComponent<ChooseSettlement>().isLumberHarbor = true;
            }
            if (portNumber == PortNumber.SixFive)
            {
                other.GetComponent<ChooseSettlement>().isOreHarbor = true;
            }
        }
    }
}
