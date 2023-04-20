using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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


    public IEnumerator HelpTextBox(string text)
    {
        helpText.text = text;
        helpTextBox.SetActive(true);
        yield return new WaitForSeconds(10);
        //   helpTextBox.SetActive(false);
    }

    public void SetHelpTextBoxActive()
    {
        helpTextBox.SetActive(true);
    }

    public void SetHelpTextBoxOff()
    {
        helpTextBox.SetActive(false);
    }
}
