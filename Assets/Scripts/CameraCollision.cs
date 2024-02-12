using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 1f;
    private RaycastHit hitInfo;
    private LayerMask collisionLayer;

    void Start()
    {
        // Define the layer mask for collision detection (adjust as needed)
        collisionLayer = LayerMask.GetMask("Default");
    }

    void Update()
    {
        // Perform raycasts in all directions
        bool upHit = Physics.Raycast(transform.position, transform.up, raycastDistance, collisionLayer);
        bool downHit = Physics.Raycast(transform.position, -transform.up, raycastDistance, collisionLayer);
        bool rightHit = Physics.Raycast(transform.position, transform.right, raycastDistance, collisionLayer);
        bool leftHit = Physics.Raycast(transform.position, -transform.right, raycastDistance, collisionLayer);
        bool forwardHit = Physics.Raycast(transform.position, transform.forward, raycastDistance, collisionLayer);
        bool backwardHit = Physics.Raycast(transform.position, -transform.forward, raycastDistance, collisionLayer);

        // Define the raycast directions based on the camera's fixed orientation
        Vector3 upDirection = transform.TransformDirection(Vector3.up);
        Vector3 downDirection = transform.TransformDirection(Vector3.down);
        Vector3 rightDirection = transform.TransformDirection(Vector3.right);
        Vector3 leftDirection = transform.TransformDirection(Vector3.left);
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        Vector3 backwardDirection = transform.TransformDirection(Vector3.back);

        // Log debug information to the console
        Debug.Log("Up Hit: " + upHit);
        Debug.Log("Down Hit: " + downHit);
        Debug.Log("Right Hit: " + rightHit);
        Debug.Log("Left Hit: " + leftHit);
        Debug.Log("Forward Hit: " + forwardHit);
        Debug.Log("Backward Hit: " + backwardHit);

        // Handle collision detection results (for demonstration purposes)
        Debug.DrawRay(transform.position, upDirection * raycastDistance, upHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, downDirection * raycastDistance, downHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, rightDirection * raycastDistance, rightHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, leftDirection * raycastDistance, leftHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, forwardDirection * raycastDistance, forwardHit ? Color.red : Color.green);
        Debug.DrawRay(transform.position, backwardDirection * raycastDistance, backwardHit ? Color.red : Color.green);
    }
}
