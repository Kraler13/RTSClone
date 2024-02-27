using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float movmentTime;
    [SerializeField] private float rotationAmount;
    [SerializeField] private Vector3 zoom;


    private Vector3 newPosition;
    private Vector3 newZoom;
    private Quaternion newRotation;

    private Vector3 rotateStartPosition;
    private Vector3 rotateCurrentPosition;

    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraObj.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        cameraObj.GetComponent<CameraCollision>().CameraColision();
        HendleMovementInput();
        HendleMouseInput();
    }
    void HendleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoom;
        }
        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;
            Vector3 diff = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = rotateCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-diff.x / 5f));
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movmentTime);
        cameraObj.transform.localPosition = Vector3.Lerp(cameraObj.transform.localPosition, newZoom, Time.deltaTime * movmentTime);
    }
    void HendleMovementInput()
    {
        var cObj = cameraObj.GetComponent<CameraCollision>();
        if (Input.GetKey(KeyCode.W) && !cObj.forwardHitToSee)
        {
            newPosition += (transform.forward * movmentSpeed);
        }
        if (Input.GetKey(KeyCode.S) && !cObj.backwardHitToSee)
        {
            newPosition += (transform.forward * -movmentSpeed);
        }
        if (Input.GetKey(KeyCode.D) && !cObj.rightHitToSee)
        {
            newPosition += (transform.right * movmentSpeed);
        }
        if (Input.GetKey(KeyCode.A) && !cObj.leftHitToSee)
        {
            newPosition += (transform.right * -movmentSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if (Input.GetKey(KeyCode.R) && cObj.upHitToSee)
        {
            newZoom += zoom;
        }
        if (Input.GetKey(KeyCode.F) && cObj.downHitToSee)
        {
            newZoom -= zoom;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movmentTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movmentTime);
        cameraObj.transform.localPosition = Vector3.Lerp(cameraObj.transform.localPosition, newZoom, Time.deltaTime * movmentTime);
    }
}
