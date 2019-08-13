using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    private GameObject gun;
    public GameObject bullet;
    public Transform gunbulletspawn;
    public float timeforshoot = 1f;
    public float timer;
   // PlayerConnection playerConnection;
    // Start is called before the first frame update
    public override void OnStartAuthority()
    {
            timer = Time.time;
     //   playerConnection = gameObject.transform.parent.GetComponent<PlayerConnection>();
    }

    public void Start()
    {

        gun = gameObject.transform.Find("Gun").gameObject;
        gunbulletspawn = gun.transform.Find("BulletSpawn").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority)
        {
            if (Input.GetButton("Fire1") && Time.time - timer > timeforshoot)
            {
                timer = Time.time;
                Debug.Log(Time.time - timer);

                GameObject newBullet = Instantiate(bullet, gunbulletspawn.position, gunbulletspawn.rotation);
       //         playerConnection.spawnBullet(bullet,gunbulletspawn);

            }

        }
    }
}
