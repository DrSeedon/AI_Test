using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject target;
    public float speed = 20f;
    public bool XAxis = false;
    public bool YAxis = true;
    public bool ZAxis = false;
    void Update()
    {        
        if (XAxis)
        {
            transform.RotateAround(target.transform.position, Vector3.right, speed * Time.deltaTime);
        }
        if (YAxis)
        {
            transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        if (ZAxis)
        {
            transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}
