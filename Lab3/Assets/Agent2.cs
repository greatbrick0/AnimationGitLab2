using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent2 : MonoBehaviour
{
    [SerializeField]
    private Transform goalTrans;
    private Vector3 goalPos;

    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;

    bool attacking = false;
    bool walking = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        goalPos = goalTrans.position;
        if(Vector3.Distance(goalPos, transform.position) < 1 && !attacking)
        {
            attacking = true;
            animator.SetTrigger("Attack");
            print("attack");
        }
        else
        {
            agent.SetDestination(goalPos);
        }
    }
}
