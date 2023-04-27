using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is used for the camera movement in the Main menus
 * It allows for the camera to rotate around a fixed point in the scene
 * This was made with the use of a YouTube Tutorial found here: 
 * https://www.youtube.com/watch?v=iuygipAigew
 * 
 * @author (Aidan Jackets)
 * @version (Version No: 1)
 */



public class CameraRotator : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
