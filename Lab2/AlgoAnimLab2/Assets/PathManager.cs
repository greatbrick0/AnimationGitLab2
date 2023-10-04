using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public List<Waypoint> path;
    public GameObject prefab;
    int currentPointIndex = 0;

    public List<GameObject> prefabPoints;

    public List<Waypoint> GetPath()
    {
        if(path == null)
        {
            path = new List<Waypoint>();
        }

        return path;
    }

    public void CreateAddPoint()
    {
        Waypoint go = new Waypoint();
        path.Add(go);
    }

    public Waypoint GetNextPoint()
    {
        int nextPointIndex = (currentPointIndex + 1) % (path.Count);
        currentPointIndex = nextPointIndex;
        return path[currentPointIndex];
    }

    private void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach(Waypoint p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go);
        }
    }

    private void Update()
    {
        //print("start");
        for(int ii = 0; ii < path.Count; ii++)
        {
            //print(ii + " " + path.Count + " " + prefabPoints.Count);
            Waypoint p = path[ii];
            GameObject g = prefabPoints[ii];
            g.transform.position = p.pos;
        }
    }
}
