using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WarningText : MonoBehaviour
{
    [Header("Warning Text")]
    public TextMeshProUGUI warningText;
    public GameObject warningBox;

    public void Awake()
    {
        warningBox.SetActive(false);
    }
    // Start is called before the first frame update
    public IEnumerator WarningTextBox(string text)
    {
        warningText.text = text;
        warningBox.SetActive(true);
        yield return new WaitForSeconds(3);
        warningBox.SetActive(false);
    }

    public void SetWarningBoxActive()
    {
        warningBox.SetActive(true);
    }

    public void SetWarningBoxOff()
    {
        warningBox.SetActive(false);
    }
}
