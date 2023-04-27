using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * This script is responsbie for controlling the warning box.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class WarningText : MonoBehaviour
{
    [Header("Warning Text")]
    public TextMeshProUGUI warningText;
    public GameObject warningBox;

    public void Awake()
    {
        warningBox.SetActive(false);
    }

    // Starts a coroutine to display the warning text box using the text inserted to the parameter.
    public IEnumerator WarningTextBox(string text)
    {
        warningText.text = text;
        warningBox.SetActive(true);
        yield return new WaitForSeconds(3);
        warningBox.SetActive(false);
    }

    // sets warning box to enabled.
    public void SetWarningBoxActive()
    {
        warningBox.SetActive(true);
    }

    // sets warning box to disabled.
    public void SetWarningBoxOff()
    {
        warningBox.SetActive(false);
    }
}
