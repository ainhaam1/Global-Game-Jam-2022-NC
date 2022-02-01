using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToggle : MonoBehaviour
{
    private bool isLight = false;
    public Animator animator;

    void Update()
    {
        ToggleSword();
    }

    public void ToggleSword()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isLight)
            {
                animator.SetBool("White", false);
                isLight = false;
            } else if (!isLight)
            {
                animator.SetBool("White", true);
                isLight = true;
            }
        }
    }

    public string returnSwordType()
    {
        if (isLight)
        {
            return "Light";
        } else
        {
            return "Dark";
        }
    }
}
