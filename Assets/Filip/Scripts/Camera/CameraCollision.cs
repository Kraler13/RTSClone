using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    private LayerMask collisionLayer;
    [SerializeField] private float raycastDistance = 1f;

    public bool upHitToSee;
    public bool downHitToSee;
    public bool rightHitToSee;
    public bool leftHitToSee;
    public bool forwardHitToSee;
    public bool backwardHitToSee;
    void Start()
    {
        collisionLayer = LayerMask.GetMask("Default");
    }


    public void CameraColision()
    {
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

        upHitToSee = upHit;
        downHitToSee = downHit;
        rightHitToSee = rightHit;
        leftHitToSee = leftHit;
        forwardHitToSee = forwardHit;
        backwardHitToSee = backwardHit;
    }
}
