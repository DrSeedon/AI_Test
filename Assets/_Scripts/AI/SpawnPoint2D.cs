using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint2D : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetRandomSpawnPoint()
    {
        Vector3 tf = new Vector3(
            Random.Range(
                point1.position.x,
                point2.position.x),
            0,
            Random.Range(
                point1.position.z,
                point2.position.z));
        return tf;
    }
}
