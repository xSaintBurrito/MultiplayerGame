using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletMovement : NetworkBehaviour
{
    public float speed = 0.2f; 
    Transform bulletTransform;
    public int ammoPower = 2;
    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = gameObject.transform;
    }
    public override void OnStartAuthority()
    {
        if (hasAuthority)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        bulletTransform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        //gameObject.SetActive(false);
    }
}
