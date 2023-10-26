using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
{
    NavMeshAgent agent;

    Transform target;

    [SerializeField]
    GameObject hatObj;
    [SerializeField]
    GameObject hatGroupObj;
    GameObject instRef;

    int hatCount = 3;
    bool stunned = false;
    public bool weak = false;
    float age = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerScript>().transform;
    }


    void Update()
    {
        agent.SetDestination(target.position);
        agent.speed = stunned ? 0 : 1;
        age += 1.0f * Time.deltaTime;
    }

    public void Hit()
    {
        if (age < 2.0f) return;
        
        target.GetComponent<PlayerScript>().Jump(7);

        if(hatCount == 1)
        {
            stunned = true;
        }
        else if(hatCount == 0)
        {
            transform.parent.GetComponent<Holder>().ClearHats();
            if (!weak) SpawnHatGroup();
            Destroy(this.gameObject);
        }

        if(hatCount > 0)
        {
            hatCount -= 1;
            SpawnHat();
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

    void SpawnHat()
    {
        instRef = Instantiate(hatObj, transform.parent);
        instRef.transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
        instRef.GetComponent<Hat>().RandomizeDirection();
    }

    void SpawnHatGroup()
    {
        instRef = Instantiate(hatGroupObj, transform.parent);
        instRef.transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
    }
}
