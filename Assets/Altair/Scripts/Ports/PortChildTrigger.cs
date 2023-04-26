using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This controls what type of port this is.
 *
 * @author Altair, Ben
 * @version 26/04/2023
 */
public class PortChildTrigger : MonoBehaviour
{
    public PortType portType;

    public enum PortType
    {
    wool,
    lumbar,
    ore,
    grain,
    brick,
    improved
    }

    // designate the type of city this is.

    // if collider == city point, toggle the city point's port type.
    // This will ONLY WORK if there is ONE port for this edge.
    // If there are TWO ports on an edge, you need to get the child's colliders as there are two colliders.
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CityPoint"))
        {
            // only do port numbers with ONE port

            if (portType == PortType.wool)
            {
                other.GetComponent<ChooseSettlement>().isWoolHarbor = true;
            }
            if (portType == PortType.ore)
            {
                other.GetComponent<ChooseSettlement>().isOreHarbor = true;
            }
            if (portType == PortType.grain)
            {
                other.GetComponent<ChooseSettlement>().isGrainHarbor = true;
            }
            if (portType == PortType.lumbar)
            {
                other.GetComponent<ChooseSettlement>().isLumberHarbor = true;
            }
            if (portType == PortType.improved)
            {
                other.GetComponent<ChooseSettlement>().isImprovedHarbor = true;
            }
            if (portType == PortType.brick)
            {
                other.GetComponent<ChooseSettlement>().isBrickHarbor = true;
            }
        }
    }
}
