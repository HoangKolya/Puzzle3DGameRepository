using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetection;

public class CubeMovingX : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        OnSwipeEvent += OnSwipe;
    }
    private void OnSwipe(Vector2 direction)
    {
        //Vector3 dir =
        //direction == Vector2.up ?
        //Vector3.right : direction == Vector2.down ?
        //Vector3.left : Vector3.zero;

        if (direction == Vector2.right || direction == Vector2.left)
            MoveCube(direction == Vector2.right ? Vector2.left : Vector2.right);
    }

    private void MoveCube(Vector3 direction)
    {
        if (rb != null)
            rb.AddRelativeForce(direction * 1000);
    }
}
