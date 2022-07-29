using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SwipeDetection;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        OnSwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        Vector3 dir =
        direction == Vector2.up ?
        Vector3.back : direction == Vector2.down ?
        Vector3.forward: (Vector3)direction;

        Move(dir);
    }

    public void FixedUpdate()
    {
        
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Move(Vector3 direction)
    {
        if(rb != null)
            rb.AddRelativeForce(direction * 1200);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
