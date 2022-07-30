using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetection;

public class CubeMovingZ : MonoBehaviour
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
        Vector3 dir =
        direction == Vector2.up ?
        Vector3.back : direction == Vector2.down ?
        Vector3.forward : Vector3.zero;

        MoveCube(dir);
    }

    private void MoveCube(Vector3 direction)
    {
        if (rb != null)
            rb.AddRelativeForce(direction * 1000);
    }
}
