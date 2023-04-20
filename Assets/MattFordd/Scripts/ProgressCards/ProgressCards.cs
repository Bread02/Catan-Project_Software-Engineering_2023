using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCards : MonoBehaviour
{
    int amount;
    public virtual void Use() {
        Debug.Log("This should not show up");
    }
}
