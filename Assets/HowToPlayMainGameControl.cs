using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
