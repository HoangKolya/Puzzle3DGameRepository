using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartMenu : MonoBehaviour
{
    Action action;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Play()
    {
        action = () => NextLvl();
        animator.SetBool("isPlay", true);
        StartCoroutine(ButtonInStartMenu(action));
    }

    public void QuitInStartMenu()
    {
        action = () => Application.Quit();
        animator.SetBool("isQuit", true);
        StartCoroutine(ButtonInStartMenu(action));
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ButtonInStartMenu(Action action)
    {
        yield return new WaitForSeconds(0.5f);
        action();
        Debug.Log("ok");
    }
}
