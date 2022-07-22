using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFlightController : MonoBehaviour
{
    public float PitchValue;
    public float RollValue;
    // Update is called once per frame
    void Update()
    {
        PitchValue = Mathf.Clamp(transform.rotation.x * 2, -1, 1);
        RollValue = Mathf.Clamp(transform.rotation.z * 2, -1, 1);
        
        transform.Rotate(-Mathf.MoveTowards(transform.rotation.x, 0, Time.deltaTime), 0,-Mathf.MoveTowards(transform.rotation.z, 0, Time.deltaTime));
            
    }
}
