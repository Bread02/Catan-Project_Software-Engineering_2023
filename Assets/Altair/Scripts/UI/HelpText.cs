using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * This script is responsbie for controlling the help box.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class HelpText : MonoBehaviour
{
    [Header("Help Text")]
    public TextMeshProUGUI helpText;
    public GameObject helpTextBox;

    // Start is called before the first frame update
    void Start()
    {
        helpTextBox.SetActive(true);
    }


    // starts the coroutine to trigger the help box.
    public IEnumerator HelpTextBox(string text)
    {
        helpText.text = text;
        helpTextBox.SetActive(true);
        yield return new WaitForSeconds(10);
        helpTextBox.SetActive(false);
    }

    // Sets the help box to active.
    public void SetHelpTextBoxActive()
    {
        helpTextBox.SetActive(true);
    }

    // sets the help box to off.
    public void SetHelpTextBoxOff()
    {
        helpTextBox.SetActive(false);
    }
}
