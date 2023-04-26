using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script randomizes the port locations each time a game is started.
 *
 * @author Altair, Ben
 * @version 26/04/2023
 */
public class PortRandomization : MonoBehaviour
{
    [Header("Port Prefabs")]
    [SerializeField] private GameObject portPrefab1;
    [SerializeField] private GameObject portPrefab2;
    [SerializeField] private GameObject portPrefab3;
    [SerializeField] private GameObject portPrefab4;
    [SerializeField] private GameObject portPrefab5;
    [SerializeField] private GameObject portPrefab6;

    [Header("Port Locations")]
    [SerializeField] private Transform port1Location;
    [SerializeField] private Transform port2Location;
    [SerializeField] private Transform port3Location;
    [SerializeField] private Transform port4Location;
    [SerializeField] private Transform port5Location;
    [SerializeField] private Transform port6Location;

    [Header("Lists")]
    [SerializeField] private List<GameObject> portPrefabList = new List<GameObject>();
    [SerializeField] private List<Transform> portLocationsList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        AddAllItemsToList();
        InstantiatePorts();
    }

    // Adds all the port locations and all the port prefabs onto the two lists.
    void AddAllItemsToList()
    {
        portLocationsList.Add(port1Location);
        portLocationsList.Add(port2Location);
        portLocationsList.Add(port3Location);
        portLocationsList.Add(port4Location);
        portLocationsList.Add(port5Location);
        portLocationsList.Add(port6Location);

        portPrefabList.Add(portPrefab1);
        portPrefabList.Add(portPrefab2);
        portPrefabList.Add(portPrefab3);
        portPrefabList.Add(portPrefab4);
        portPrefabList.Add(portPrefab5);
        portPrefabList.Add(portPrefab6);


    }

    // randomize port locations each time
    void InstantiatePorts()
    {
        // shuffle the list
        ShuffleLists();

        for(int i = 0; i < portLocationsList.Count; i++)
        {
            Instantiate(portPrefabList[i], portLocationsList[i]);
        }
    }

    // List shuffle found here.
    // https://answers.unity.com/questions/486626/how-can-i-shuffle-alist.html
    void ShuffleLists()
    {
        for (int i = 0; i < portPrefabList.Count; i++)
        {
            GameObject temp = portPrefabList[i];
            int randomIndex = Random.Range(i, portPrefabList.Count);
            portPrefabList[i] = portPrefabList[randomIndex];
            portPrefabList[randomIndex] = temp;
        }
    }

}
