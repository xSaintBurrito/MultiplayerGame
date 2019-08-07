using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class FastGun : MonoBehaviour ,iShootable
{
    private string ammoType = "FastGunAmmo";
    public int ammoAmout = 100;
    public AudioClip shootSound;
    public AudioClip outOfAmmoSound;
    private AudioSource audioSource;
    private Transform BulletSpawn;

    /* shoot */
    public GameObject bulletPrefab;
    public float shootTime = 0.05f;
    private float timer;
    /*       */



    public bool addAmmo(int amout,string type)
    {
        if (type == ammoType)
        {
            ammoAmout += amout;
            return true;
        }
        else
            return false;
    }

    public int ammo()
    {
        return ammoAmout;
    }
    public void shoot()
    {
        if (true)
        {
            GameObject bullet;
            if (ammoAmout > 0 && Time.time - timer > shootTime)
            {
                ammoAmout--;
                audioSource.PlayOneShot(shootSound);
                timer = Time.time;
                bullet = Instantiate(bulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
                bullet.transform.parent = null;
                timer = Time.time;
            }
            else
            {
                if (Time.time - timer > shootTime)
                {
                    audioSource.PlayOneShot(outOfAmmoSound);
                    timer = Time.time;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        BulletSpawn = gameObject.transform.Find("BulletSpawn");
        audioSource = gameObject.GetComponent<AudioSource>();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
