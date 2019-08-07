using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float reloadTime = 0.5f;
    public float shootTime = 0.05f;
    private float timer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject bullet = null;
        if (Input.GetButton("Fire1") && Time.time - timer > shootTime)
        {
            bullet = Instantiate(bulletPrefab, gameObject.GetComponentInParent<Transform>().position,gameObject.GetComponent<Transform>().rotation);
            audioSource = bullet.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            timer = Time.time;
        }
        if (bullet == null)
            return;

        bullet.transform.parent = null;

    }

}
