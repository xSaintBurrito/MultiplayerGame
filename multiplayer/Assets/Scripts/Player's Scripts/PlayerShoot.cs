using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField]
    private iShootable gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = gameObject.GetComponentInChildren<iShootable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            if (Input.GetButton("Fire1"))
                gun.shoot();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "AmmoBox")
        {
            AmmoBoxTemplate scriptableObject = collision.collider.gameObject.GetComponent<AmmoBoxTemplate>();
            gun.addAmmo(scriptableObject.amoutOfAmmo,scriptableObject.typeOfAmmo);
            Destroy(collision.collider.gameObject);
        }
    }

    public int amoutOfAmmo() { return gun.ammo(); }
}
