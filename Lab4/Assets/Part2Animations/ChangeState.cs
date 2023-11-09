using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    public void Change(int newState)
    {
        if(newState == 0)
        {
            anim.SetTrigger("Run");
        }
        else if(newState == 1)
        {
            anim.SetTrigger("Climb");
        }
        else if (newState == 2)
        {
            anim.SetTrigger("Jump");
        }
    }
}
