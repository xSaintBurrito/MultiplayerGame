using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRotation : NetworkBehaviour
{

    private Transform playerTransform = null;
    // Start is called before the first frame update
    private Transform gunTransform;
    public override void OnStartAuthority()
    {
        if (this.hasAuthority)
        {
            playerTransform = gameObject.transform;
            gunTransform = gameObject.transform.Find("Gun").gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.hasAuthority && playerTransform !=null)
        {
            float xRotation = Input.GetAxis("Mouse X");
            float yRotation = Input.GetAxis("Mouse Y");

            playerTransform.Rotate(0, xRotation, 0);
            float yGunRotation = Input.GetAxis("Mouse Y");

            float currentXRotation = gunTransform.rotation.eulerAngles.x;
            if (isInRange(0, 40, currentXRotation) || isInRange(320, 360, currentXRotation))
                gunTransform.Rotate(yRotation, 0, 0);
            else
            {
                if (isInRange(40, 45, currentXRotation) && yGunRotation < 0)
                    gunTransform.Rotate(yRotation, 0, 0);
                if (isInRange(315, 320, currentXRotation) && yGunRotation > 0)
                    gunTransform.Rotate(yRotation, 0, 0);
            }
        }


    }
    public bool isInRange(float min, float max, float variable)
    {
        if (variable < max && variable >= min) return true;
        else return false;
    }
}
