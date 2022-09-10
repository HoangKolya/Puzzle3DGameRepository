using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetection;

public class CubeMovingZ : MonoBehaviour, IMoveObject
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
        Vector3 dir =
        direction == Vector2.up ?
        Vector3.back : direction == Vector2.down ?
        Vector3.forward : Vector3.zero;

        Move(dir);
    }
    public void Move(Vector3 direction)
    {
        if (rb != null)
            rb.AddRelativeForce(direction * 1100);
    }

    public void FreezeBouncing()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezePositionX;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == this.tag)
        {
            Rigidbody collidedObject = collision.gameObject.GetComponent<Rigidbody>();
            if (collidedObject.velocity == Vector3.zero)
            {
                FreezeBouncing();
            }
            collidedObject = null;
        }
    }
}
