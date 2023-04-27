using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * This script is responsbie for controlling the how to play menu in the mainscene2.
 *
 * @author Altair
 * @version 27/04/2023
 */
public class HowToPlayMainGameControl : MonoBehaviour
{

    [SerializeField] private GameObject howToPlayMenu;

    private bool menuEnabled;

    // Start is called before the first frame update
    void Start()
    {
        howToPlayMenu.SetActive(false);
        menuEnabled = false;
    }


    // method triggereed by clicking the how to play button in mainscene2.
    public void ClickHowToPlayButton()
    {
        // this prevents clicking a game object by accident
            if (menuEnabled)
            {
                howToPlayMenu.SetActive(false);
                menuEnabled = false;
                return;
            }
            else
            {
                howToPlayMenu.SetActive(true);
                menuEnabled = true;
                return;
            }
        }

   

}
