using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetection;

public class CubeMovingX : MonoBehaviour, IMoveObject
{
    [SerializeField] Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        OnSwipeEvent += OnSwipeCube;
    }
    private void OnSwipeCube(Vector2 direction)
    {
        //Vector3 dir =
        //direction == Vector2.up ?
        //Vector3.right : direction == Vector2.down ?
        //Vector3.left : Vector3.zero;

        if (direction == Vector2.right || direction == Vector2.left)
            Move(direction == Vector2.right ? Vector2.left : Vector2.right);
    }
    public void Move(Vector3 direction)
    {
        if (rb != null)
            rb.AddRelativeForce(direction * 1200);
    }

    public void FreezeBouncing()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezePositionZ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == this.tag)
        {
            Rigidbody collidedObject = collision.gameObject.GetComponent<Rigidbody>();
            if (collidedObject.velocity == Vector3.zero)
            {
                FreezeBouncing();;
            }
            collidedObject = null;
        }
    }
}
