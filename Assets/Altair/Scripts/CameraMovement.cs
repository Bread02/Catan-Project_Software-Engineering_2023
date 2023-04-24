using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Camera")]
    private Transform cameraTransform;
    private GameObject mainCamera;
    private TurnManager turnManager;

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

    private float storedZoomSpeed;
    private float storedScrollSpeed;
    private float storedDragSpeed;

    [Header("Bools")]
    private bool gamePauseLock;
    public bool cameraDragging = true;
    public bool middleMouseButtonDragging = true;

    [Header("Dragging")]
    public Vector3 oldPos;
    private Vector3 panOrigin;
    public Vector3 newCameraPosition2;
    public float dragSpeed;
    public Vector3 pos10;

    [Header("Disable Scrolling IF this camera is not in use")]
    public bool disableScroll;

    [Header("Player")]
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.gameObject;
        cameraTransform = mainCamera.transform;
        CameraLockConstraints();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Zooming();
        EdgeScrolling();
        MousePanScroll();

        // if camera not in use, disable scroll.
        if(turnManager.ReturnCurrentPlayer().playerNumber == playerNumber)
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

    void CameraLockConstraints()
    {
        lockXNegative = -10;
        lockXPositive = 10;
        lockZNegative = -10;
        lockZPositive = 10;
        lockYZoomIn = 3;
        lockYZoomOut = 10;
    }

    // remove if pause functionality not needed
    public void GamePausedLock()
    {
        storedScrollSpeed = screenScrollSpeed;
        storedZoomSpeed = zoomSpeed;
        storedDragSpeed = dragSpeed;
        zoomSpeed = 0;
        screenScrollSpeed = 0;
        gamePauseLock = true;
    }

    public void GamePausedUnlock()
    {
        zoomSpeed = storedZoomSpeed;
        screenScrollSpeed = storedScrollSpeed;
        dragSpeed = storedDragSpeed;
        gamePauseLock = false;
    }

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
                    if (mousePosition.x < 40 && cameraTransform.position.x > lockXNegative)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 2:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 40 && cameraTransform.position.x < lockXPositive)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 3:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 40 && cameraTransform.position.z < lockZPositive)
                    {
                        Debug.Log("Scrolling 1");

                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 4:
                    // if mouse position < 20x scroll left
                    if (mousePosition.x < 40 && cameraTransform.position.z > lockZNegative)
                    {
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
            }

            switch (playerNumber)
            {
                case 1:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 40) && cameraTransform.position.x < lockXPositive)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 2:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 40) && cameraTransform.position.x > lockXNegative)
                    {
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 3:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 40) && cameraTransform.position.z > lockZNegative)
                    {
                        Debug.Log("Scrolling 2");
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.Self);
                    }
                    break;
                case 4:
                    // if mouse position is > screen resolution - 20, scroll right.
                    if (mousePosition.x > (Screen.width - 40) && cameraTransform.position.z < lockZPositive)
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
                    if (mousePosition.y < 40 && cameraTransform.position.z > lockZNegative)
                    {
                        mainCamera.transform.Translate(0, 0, -screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;
                case 2:
                    if (mousePosition.y < 40 && cameraTransform.position.z < lockZPositive - 5)
                    {
                        Debug.Log("Scrolling up");
                        mainCamera.transform.Translate(0, 0, screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;

                case 3:
                    if (mousePosition.y < 40 && cameraTransform.position.x > lockXNegative)
                    {
                        Debug.Log("Scrolling down");
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
                case 4:
                    // this is 3 but flipped.
                    if (mousePosition.y < 40 && cameraTransform.position.x < lockXPositive)
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
                    if (mousePosition.y > (Screen.height - 40) && cameraTransform.position.z < lockZPositive)
                    {
                        mainCamera.transform.Translate(0, 0, screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;
                case 2:
                    if (mousePosition.y > (Screen.height - 40) && cameraTransform.position.z > lockZNegative + 5)
                    {
                        Debug.Log("Scrolling down");
                        mainCamera.transform.Translate(0, 0, -screenScrollSpeed * Time.unscaledDeltaTime, Space.World);
                    }
                    break;
                case 3:
                    // needs to go between Z and X
                    //
                    if (mousePosition.y > (Screen.height - 40)  && cameraTransform.position.x < lockXPositive)
                    {
                        Debug.Log("Scrolling up");
                        mainCamera.transform.Translate(screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
                case 4:
                    if (mousePosition.y > (Screen.height - 40) && cameraTransform.position.x > lockXNegative)
                    {
                        // this is 3 but flipped.
                        mainCamera.transform.Translate(-screenScrollSpeed * Time.unscaledDeltaTime, 0, 0, Space.World);
                    }
                    break;
            }
        }
    }


    /*
    private void MouseDragScroll()
    {
        if (!gamePauseLock)
        {
            if (Input.GetMouseButtonDown(0) && !disableScroll)
            {
                cameraDragging = true;
                oldPos = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.position.y, mainCamera.transform.localPosition.z);
                panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0) && !disableScroll && cameraTransform.position.x >= lockXNegative && cameraTransform.position.x <= lockXPositive
                && cameraTransform.position.z >= lockZNegative && cameraTransform.position.z <= lockZPositive)
            {
                pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
                //      Vector3 newCameraPosition = oldPos + -pos10 * dragSpeed;
                newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);

                mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
            }


            // scroll if pos10/x is positive.
            if (Input.GetMouseButton(0) && !disableScroll && cameraTransform.position.x <= lockXNegative)
            {
                pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
                if (Mathf.Sign(pos10.x) == 1)
                {
                    newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                    mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
                }
            }

            // scroll if pos10.y is positive
            if (Input.GetMouseButton(0) && !disableScroll && cameraTransform.position.z <= lockZNegative)
            {
                pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
                if (Mathf.Sign(pos10.y) == 1)
                {
                    newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                    mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
                }
            }

            // scroll if pos10.x is negative or zero
            if (Input.GetMouseButton(0) && !disableScroll && cameraTransform.position.x >= lockXPositive)
            {
                pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
                if (pos10.x <= 0)
                {
                    newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                    mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
                }
            }

            // scroll if pos10.z is negative or zero
            if (Input.GetMouseButton(0) && !disableScroll && cameraTransform.position.z >= lockZPositive)
            {
                pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
                if (pos10.y <= 0)
                {
                    newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                    mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                cameraDragging = false;
            }
        }
    }
    */

    private void MousePanScroll()
    {
        if (Input.GetMouseButtonDown(2) && !middleMouseButtonDragging)
        {
            cameraDragging = true;
            oldPos = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.position.y, mainCamera.transform.localPosition.z);
            panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2) && !middleMouseButtonDragging && cameraTransform.position.x >= lockXNegative && cameraTransform.position.x <= lockXPositive
            && cameraTransform.position.z >= lockZNegative && cameraTransform.position.z <= lockZPositive)
        {
            pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
            //      Vector3 newCameraPosition = oldPos + -pos10 * dragSpeed;
            newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);

            mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
        }


        // scroll if pos10/x is positive.
        if (Input.GetMouseButton(2) && !middleMouseButtonDragging && cameraTransform.position.x <= lockXNegative)
        {
            pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
            if (Mathf.Sign(pos10.x) == 1)
            {
                newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
            }
        }

        // scroll if pos10.y is positive
        if (Input.GetMouseButton(2) && !middleMouseButtonDragging && cameraTransform.position.z <= lockZNegative)
        {
            pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
            if (Mathf.Sign(pos10.y) == 1)
            {
                newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
            }
        }

        // scroll if pos10.x is negative or zero
        if (Input.GetMouseButton(2) && !middleMouseButtonDragging && cameraTransform.position.x >= lockXPositive)
        {
            pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
            if (pos10.x <= 0)
            {
                newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
            }
        }

        // scroll if pos10.z is negative or zero
        if (Input.GetMouseButton(2) && !middleMouseButtonDragging && cameraTransform.position.z >= lockZPositive)
        {
            pos10 = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
            if (pos10.y <= 0)
            {
                newCameraPosition2 = new Vector3(oldPos.x + pos10.x * dragSpeed, 0, oldPos.z + pos10.y * dragSpeed);
                mainCamera.transform.localPosition = new Vector3(newCameraPosition2.x, oldPos.y, newCameraPosition2.z);
            }
        }

        if (Input.GetMouseButtonUp(2))
        {
            middleMouseButtonDragging = false;
        }
    }

    // edgescrolling
}
