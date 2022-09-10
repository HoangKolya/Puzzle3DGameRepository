using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject effectBlur;
    GameObject clone;
    private bool IsPauseMenuOpen = false;
    public void PauseMenuOpen()
    {
        if(IsPauseMenuOpen == false)
        {
            IsPauseMenuOpen = true;
            anim.SetBool("isOpenPauseMenu", true);
            clone = Instantiate(effectBlur);
        }
    }
    public void QuitInPauseMenu()
    {
        Application.Quit();
        Debug.Log("o");
    }
    public void PauseMenuClose()
    {
        anim.SetBool("isOpenPauseMenu", false);
        DestroyImmediate(clone,true);
        IsPauseMenuOpen = false;
    }
}
