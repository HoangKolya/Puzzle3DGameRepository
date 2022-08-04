using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfPoligons : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Poligon") && (other.CompareTag("Cube") || other.CompareTag("CubeTrigger")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
