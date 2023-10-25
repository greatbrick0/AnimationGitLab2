using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimantionChanger : MonoBehaviour
{
    public Animator animator;

    private float tracker = 0.0f;
    private int direction = 1;

    void Start()
    {
        
    }

    void Update()
    {
        animator.SetFloat("Blend", tracker);
        tracker += direction * Time.deltaTime;
        if(tracker > 1 && direction == 1)
        {
            direction = -1;
        }
        if (tracker < 1 && direction == -1)
        {
            direction = 1;
        }
    }
}
