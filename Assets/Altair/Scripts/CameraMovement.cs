using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script controls camera movement using the mouse buttons and moving the mouse to the edges of the screen.
 *
 * @author Altair Robinson
 * @version 26/04/2023
 */
public class CameraMovement : MonoBehaviour
{
    [Header("Other Scripts")]
    private TurnManager turnManager;

    [Header("Camera")]
    private Transform cameraTransform;
    private GameObject mainCamera;

    [Header("Control scroll and zoom speed")]
    public float zoomSpeed;
    public float screenScrollSpeed;

    [Header("Lock screen scroll constraints")]
    private float lockXNegative;
    private float lockXPositive;
    private float lockZNegative;
    private float lockZPositive;

    [Header("Lock zoom constraints")]
    private float lockYZoomIn;
    private float lockYZoomOut;

    [Header("Disable Scrolling IF this camera is not in use")]
    public bool disableScroll;

    [Header("Player")]
    public int playerNumber;
    private Vector3 cameraCenterPoint;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.gameObject;
        cameraTransform = mainCamera.transform;
        CameraLockConstraints();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        GetCameraCentrePoint();
    }

    // Grabs the camera's starting point. Needed for middle mouse click to centre mouse back to screen.
    private void GetCameraCentrePoint()
    {
        cameraCenterPoint = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Zooming();
        EdgeScrolling();
        ClickToCenter();

        // if camera not in use, disable scroll.
        if (turnManager.ReturnCurrentPlayer().playerNumber == playerNumber)
        {
            disableScroll = false;
            return;
        }
        else
        {
            disableScroll = true;
            return;
        }
    }

    // This locks the camera's X, Y and Z axis so it cannot go outside of these ranges.
    void CameraLockConstraints()
    {
        lockXNegative = -10;
        lockXPositive = 10;
        lockZNegative = -10;
        lockZPositive = 10;
        lockYZoomIn = 3;
        lockYZoomOut = 10;
    }

    // Zooming functionality using the mouse scrollwheel.
    private void Zooming()
    {
        // zoom in
        if ((Input.GetAxis("Mouse ScrollWheel") < 0f && cameraTransform.position.y < lockYZoomOut))
        {
            mainCamera.transform.Translate(0, -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.unscaledDeltaTime, 0, Space.World);
        }

        // zoom out
        if ((Input.GetAxis("Mouse ScrollWheel") > 0f && cameraTransform.position.y > lockYZoomIn))
        {
            mainCamera.transform.Translate(0, -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.unscaledDeltaTime, 0, Space.World);
        }
    }

    // move camera based on local rotation
    private void EdgeScrolling()
    {
        if (!disableScroll)
        {
            Vector3 mousePosition = Input.mousePosition;

            switch (playerNumber)
            {
                case 1:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 20 && cameraTransform.position.x > lockXNegative)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 2:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 20 && cameraTransform.position.x < lockXPositive)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 3:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 20 && cameraTransform.position.z < lockZPositive)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 4:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 20 && cameraTransform.position.z > lockZNegative)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
            }

            switch (playerNumber)
            {
                case 1:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 20) && cameraTransform.position.x < lockXPositive)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 2:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 20) && cameraTransform.position.x > lockXNegative)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 3:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 20) && cameraTransform.position.z > lockZNegative)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 4:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 20) && cameraTransform.position.z < lockZPositive)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
            }


            // if camera 2, flip.
            // scroll up
            switch (playerNumber)
            {

                case 1:
                    if (mousePosition.y < 20 && cameraTransform.position.z > lockZNegative)
                    {
                        mainCamera.transform.Translate(0, 0, -screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;
                case 2:
                    if (mousePosition.y < 20 && cameraTransform.position.z < lockZPositive - 5)
                    {
                        mainCamera.transform.Translate(0, 0, screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;

                case 3:
                    if (mousePosition.y < 20 && cameraTransform.position.x > lockXNegative)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
                case 4:
                    // this is 3 but flipped.
                    if (mousePosition.y < 20 && cameraTransform.position.x < lockXPositive)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
            }



            // if camera 2, flip.
            switch (playerNumber)
            {

                case 1:
                    // scroll down
                    if (mousePosition.y > (Screen.height - 20) && cameraTransform.position.z < lockZPositive)
                    {
                        mainCamera.transform.Translate(0, 0, screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;
                case 2:
                    if (mousePosition.y > (Screen.height - 20) && cameraTransform.position.z > lockZNegative + 5)
                    {
                        mainCamera.transform.Translate(0, 0, -screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;
                case 3:
                    // needs to go between Z and X
                    //
                    if (mousePosition.y > (Screen.height - 20)  && cameraTransform.position.x < lockXPositive)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
                case 4:
                    if (mousePosition.y > (Screen.height - 20) && cameraTransform.position.x > lockXNegative)
                    {
                        // this is 3 but flipped.
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
            }
        }
    }

    // Click the mouse wheel button then the camera will go back to its centre point.
    private void ClickToCenter()
    {
        if(Input.GetMouseButtonDown(2))
        {
            mainCamera.transform.position = cameraCenterPoint;
        }
    }
}
