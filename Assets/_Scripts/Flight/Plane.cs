using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public bool throttle;
    public float powerIncrease;
    public float powerDecrease;
    public float currentPower;
    public float pitchPower, roolPower, yawPower, enginePower;
    public float activeRoll, activePitch, activeYaw;
    public Rigidbody rb;
    public List<TMP_Text> Texts;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentPower += powerIncrease;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            currentPower -= powerDecrease;
        }
        
        
        /*
        currentPower = Mathf.Clamp(currentPower, 20, enginePower);
        transform.position += transform.forward * (currentPower * Time.deltaTime);

            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
            activeRoll= Input.GetAxisRaw("Horizontal") * roolPower * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;
             
            transform.Rotate(activePitch*pitchPower*Time.deltaTime,
                activeYaw*yawPower*Time.deltaTime,
                -activeRoll * roolPower * Time.deltaTime,
                Space.Self);
                */
        
        currentPower = Mathf.Clamp(currentPower, 20, enginePower);
        
        rb.AddForce(transform.forward * (currentPower * Time.deltaTime));
        
        activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
        activeRoll = Input.GetAxisRaw("Horizontal") * roolPower * Time.deltaTime;
        activeYaw = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;
        rb.AddTorque(new Vector3(activePitch * pitchPower * Time.deltaTime,
            activeYaw * yawPower * Time.deltaTime,
            -activeRoll * roolPower * Time.deltaTime));

        Texts[0].text = "rb.velocity "+ rb.velocity;
        Texts[1].text = "transform.eulerAngles "+ transform.eulerAngles;
        Texts[2].text = "rb.velocity.normalized "+ rb.velocity.normalized;
        Texts[3].text = "rb.velocity.magnitude "+ rb.velocity.magnitude;

    }
        
}

