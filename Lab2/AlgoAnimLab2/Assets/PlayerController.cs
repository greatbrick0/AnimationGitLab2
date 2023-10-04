using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PathController pathAI;
    [SerializeField]
    Animator animator;

    bool isWalking = true;

    [SerializeField]
    bool canBeBlocked = false;

    void Update()
    {
        if (canBeBlocked)
        {
            if (isWalking && pathAI.blockingObjectCount > 0) ChangeState();
            if (!isWalking && pathAI.blockingObjectCount == 0) ChangeState();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState();
        }
    }

    public void ChangeState()
    {
        isWalking = !isWalking;
        animator.SetBool("IsWalking", isWalking);
        pathAI.enabled = isWalking;
    }
}
