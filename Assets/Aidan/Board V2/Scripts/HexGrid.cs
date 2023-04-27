using System.Collections;
using UnityEngine;

/**
 * This script is used to make an automated hex grid with the 
 * use of user inputs.
 * 
 * This was done by following a YouTube tutorial found here:
 * https://www.youtube.com/watch?v=BE54igXh5-Q&ab_channel=AeonicSoftworks
 *
 * @author (Aidan Jacktes)
 * @version (Version 1)
 */


public class HexGrid : MonoBehaviour
{
    public GameObject hexTile;
    public Transform holder;

    [SerializeField] int maxWidth = 11;
    [SerializeField] int maxHeight = 11;

    float tileXOffset = 1.1f;
    float tileZOffset = 0.8f;

    //method called on the start of the scene to create the grid

    private void Start()
    {
        CreateGrid();
    }


    /**
     * Method called from the start method to create the grid when the scene is run
     * Makes use of the size of the grid the user would like and creates it using the
     * below method
     */
    void CreateGrid()
    {
        float mapXMin = -maxWidth / 2;
        float mapXMax = maxWidth / 2;

        float mapZMin = -maxHeight / 2;
        float mapZMax = maxHeight / 2;

        for (float x = mapXMin; x<mapXMax; x++)
        {
            for (float z = mapZMin; z < mapZMax; z++)
            {
                GameObject TempHex = Instantiate(hexTile);
                Vector3 pos;
                
                if (z%2 == 0)
                {
                    pos = new Vector3(x * tileXOffset, 0, z * tileZOffset);
                }
                else
                {
                    pos = new Vector3(x * tileXOffset + tileXOffset/2, 0, z * tileZOffset);
                }

                StartCoroutine(SetHexInfo(TempHex, x, z, pos));
            }
        }
    }

    /**
     * Sets the information of the hex tile gameobject
     *
     * @param  hexObject  the hex object used within the scene
     * @param  x          Used for the x-axis position for the object
     * @param  z          Used for the z-axis position for the object
     */
    IEnumerator SetHexInfo(GameObject hexObject, float x, float z, Vector3 pos)
    {
        yield return new WaitForSeconds(0.0000000000001f);
        hexObject.transform.parent = holder;
        hexObject.name = x.ToString() + ", " + z.ToString();
        hexObject.transform.position = pos;
    }

    /**
     * This method was meant to get rid of/destroy tiles that left 
     * the collider when the hex objects are generated,
     * with testing this did not work as intended unfortunately
     *
     * @param  other  the collider object used within the scene
     * 
     */
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
