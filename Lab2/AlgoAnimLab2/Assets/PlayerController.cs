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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWalking = !isWalking;
            animator.SetBool("IsWalking", isWalking);
            pathAI.enabled = isWalking;
        }
    }
}
