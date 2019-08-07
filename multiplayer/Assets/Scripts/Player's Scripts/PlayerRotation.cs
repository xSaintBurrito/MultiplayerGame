using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRotation : NetworkBehaviour
{

    private Transform playerTransform = null;
    // Start is called before the first frame update
    public override void OnStartAuthority()
    {
        if (this.hasAuthority)
        {
            playerTransform = gameObject.transform;
            Debug.Log("elo");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.hasAuthority && playerTransform !=null)
        {
            Debug.Log("chuj");
            float xRotation = Input.GetAxis("Mouse X");
            float yRotation = Input.GetAxis("Mouse Y");

            playerTransform.Rotate(0, xRotation, 0);
        }


    }
}
