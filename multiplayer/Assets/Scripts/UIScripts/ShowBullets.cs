using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShowBullets : NetworkBehaviour
{

    private PlayerShoot currentGun;
    // Start is called before the first frame update
    void Start()
    {
        currentGun = gameObject.transform.parent.gameObject.GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isLocalPlayer)
            gameObject.GetComponent<Text>().text = currentGun.amoutOfAmmo() + "";
    }
}
