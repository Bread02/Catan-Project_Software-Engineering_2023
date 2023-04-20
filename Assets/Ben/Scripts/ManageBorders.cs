using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageBorders : MonoBehaviour
{
    private Dictionary<string, GameObject> bordersDict = new Dictionary<string, GameObject>();

    public void AddToBordersDict(GameObject borderObj)
    {
        bordersDict.Add(borderObj.name, borderObj);
    }
}
