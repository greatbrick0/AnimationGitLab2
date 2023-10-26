using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    int hatCount = 3;
    bool stunned = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        agent.SetDestination(target.position);
        agent.speed = stunned ? 0 : 1;
    }

    public void Hit()
    {
        print("hit");
        target.GetComponent<PlayerScript>().Jump(7);

        if(hatCount == 1)
        {
            stunned = true;
        }
        else if(hatCount == 0)
        {
            Destroy(this.gameObject);
        }

        if(hatCount > 0)
        {
            hatCount -= 1;
            UpdateHats();
        }
    }

    void UpdateHats()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        if (hatCount >= 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (hatCount >= 2)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (hatCount >= 3)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
