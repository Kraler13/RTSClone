using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float speed = 0.06f;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float maxHeight = 40f;
    [SerializeField] private float minHeight = 4f;
    [SerializeField] private float raycastDistance = 1f;
    [SerializeField] private GameObject rottacionPoint;
    private LayerMask collisionLayer;

    Vector2 p1;
    Vector2 p2;

    void Start()
    {
        collisionLayer = LayerMask.GetMask("Default");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 0.06f;
            zoomSpeed = 20f;
        }
        else
        {
            speed = 0.035f;
            zoomSpeed = 10f;
        }

        float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
        float vsp = transform.position.y * speed * Input.GetAxis("Vertical");
        float scrollSp = transform.position.y * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if (transform.position.y >= maxHeight && scrollSp > 0)
        {
            scrollSp = 0;
        }
        else if (transform.position.y <= minHeight && scrollSp < 0)
        {
            scrollSp = 0;
        }

        if (transform.position.y + scrollSp > maxHeight)
        {
            scrollSp = maxHeight - transform.position.y;
        }
        else if (transform.position.y + scrollSp < minHeight)
        {
            scrollSp = minHeight - transform.position.y;
        }

        Vector3 verticalMove = new Vector3(0, scrollSp, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        bool upHit = Physics.Raycast(transform.position, transform.up, raycastDistance, collisionLayer);
        bool downHit = Physics.Raycast(transform.position, -transform.up, raycastDistance, collisionLayer);
        bool rightHit = Physics.Raycast(transform.position, transform.right, raycastDistance, collisionLayer);
        bool leftHit = Physics.Raycast(transform.position, -transform.right, raycastDistance, collisionLayer);
        bool forwardHit = Physics.Raycast(transform.position, transform.forward, raycastDistance, collisionLayer);
        bool backwardHit = Physics.Raycast(transform.position, -transform.forward, raycastDistance, collisionLayer);

        Debug.DrawRay(transform.position, transform.up * raycastDistance, upHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, -transform.up * raycastDistance, downHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, transform.right * raycastDistance, rightHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, -transform.right * raycastDistance, leftHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, forwardHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, -transform.forward * raycastDistance, backwardHit ? Color.red : Color.green);

        if (upHit && vsp > 0)
        {
            vsp = 0;
        }
        if (downHit && vsp < 0)
        {
            vsp = 0;
        }
        if (rightHit && hsp > 0)
        {
            hsp = 0;
        }
        if (leftHit && hsp < 0)
        {
            hsp = 0;
        }
        if (forwardHit && vsp > 0)
        {
            vsp = 0;
        }
        if (backwardHit && vsp < 0)
        {
            vsp = 0;
        }

        lateralMove = hsp * transform.right;
        forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        move = verticalMove + lateralMove + forwardMove;

        transform.position += move;

        getCameraRotation();

    }

    void getCameraRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(rottacionPoint.transform.position, rottacionPoint.transform.up, rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(rottacionPoint.transform.position, rottacionPoint.transform.up, -rotateSpeed * Time.deltaTime);
        }
    }
}
