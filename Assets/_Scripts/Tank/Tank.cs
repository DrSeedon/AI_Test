using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform Target;
    public Transform Trunk;
    public Transform TrunkAim;
    public GameObject bullet;
    
    public List<TMP_Text> Texts;

    public float Speed = 1f;
    public float SpeedTrunk = 1f;
    public bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shooting());
    }

    private Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        Texts[0].text = Trunk.rotation.ToString();
        Texts[1].text = Trunk.eulerAngles.ToString();
        Texts[2].text = Target.rotation.ToString();
        Texts[3].text = Target.eulerAngles.ToString();
        
        direction = (Target.position - transform.position);
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Speed);

        Trunk.LookAt(Target.position);
        Trunk.localEulerAngles = new Vector3(Trunk.localEulerAngles.x, 0, 0);
        
        //Trunk.rotation = Quaternion.RotateTowards(Trunk.rotation, Quaternion.LookRotation(direction), SpeedTrunk);
        /*
        transform.LookAt(Target);
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        */

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(direction, .2f);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            if(isShooting)
            {
                var gm = Instantiate(bullet, TrunkAim.position, TrunkAim.rotation);
                gm.GetComponent<Rigidbody>().AddForce(TrunkAim.forward * 20f, ForceMode.Impulse);
                Destroy(gm, 10f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

}
