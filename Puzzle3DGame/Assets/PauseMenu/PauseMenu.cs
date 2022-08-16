using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject effectBlur;
    GameObject clone;
    public void PauseMenuOpen()
    {
        anim.SetBool("isOpenPauseMenu", true);
        clone = Instantiate(effectBlur);
    }

    public void PauseMenuClose()
    {
        anim.SetBool("isOpenPauseMenu", false);
        DestroyImmediate(clone,true);
    }
}
