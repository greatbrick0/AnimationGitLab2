using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] public PathManager pathManager;

    List<Waypoint> thePath;
    Waypoint target;

    public float moveSpeed;
    public float rotateSpeed;

    [HideInInspector]
    public int blockingObjectCount = 0;

    [SerializeField] bool instantRotate = false;

    private void Start()
    {
        thePath = pathManager.GetPath();
        if(thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }
    }

    void RotateTowardsTarget()
    {
        if (instantRotate)
        {
            return;
        }
        else
        {
            float stepSize = rotateSpeed * Time.deltaTime;

            Vector3 targetDir = target.pos - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    void MoveForward()
    {
        float stepSize = moveSpeed * Time.deltaTime;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if(distanceToTarget < stepSize)
        {
            return;
        }

        Vector3 moveDir = Vector3.zero;
        if (instantRotate)
        {
            moveDir = (target.pos - transform.position).normalized;
            transform.position += moveDir * stepSize;
            if (Vector3.Distance(transform.position, target.pos) < 0.1f)
            {
                target = pathManager.GetNextPoint();
            }
        }
        else
        {
            moveDir = Vector3.forward;
            transform.Translate(moveDir * stepSize);
        }
    }

    private void Update()
    {
        RotateTowardsTarget();
        MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint") && !instantRotate)
        {
            target = pathManager.GetNextPoint();
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            blockingObjectCount += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            blockingObjectCount -= 1;
        }
    }
}
