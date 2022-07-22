using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 3.0f;
    public Camera cam;
    public Transform destination;
    public Vector3 lastSpeed = new Vector3();
    public Transform enemyAim;
    public Vector3 veloc;
    public Vector3 old_position;

    private void Start()
    {
        old_position = transform.position;
    }

    void FixedUpdate()
    {
        veloc = (transform.position - old_position) / Time.fixedDeltaTime; //запоминаем скорость;
        old_position = transform.position; //берем новую "старую" позицию
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldMousePoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            bool rez = Physics.Raycast(ray, out hit, Mathf.Infinity);

            if (rez)
            {
                destination.position = hit.point;
            }
        }

        Vector3 aim = destination.position - transform.position;
        if (aim.magnitude > 0.5f)
        {
            lastSpeed = aim.normalized * speed;
            transform.position += lastSpeed * Time.deltaTime;
            transform.forward = lastSpeed;
        }
        else
        {
            lastSpeed = new Vector3(0, 0, 0);
        }        
    }

    public Vector3 enemyAimPos
    {
        get{ return enemyAim.position; }
    }


}
