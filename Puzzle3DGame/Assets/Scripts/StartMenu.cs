using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Play()
    {
        animator.SetBool("isPlay", true);

        Invoke("NextLvl", 0.5f);
    }

    public void Quit()
    {
        animator.SetBool("isQuit", true);
        Invoke("Application.Quit", 0.5f);
        
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
