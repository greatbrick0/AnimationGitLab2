using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public void ClearHats()
    {
        foreach(Hat ii in transform.GetComponentsInChildren<Hat>())
        {
            Destroy(ii.gameObject);
        }
    }
}
