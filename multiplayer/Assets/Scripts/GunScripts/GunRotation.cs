using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Transform gunTransform;
    // Start is called before the first frame update
    void Start()
    {
        gunTransform = gameObject.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = Input.GetAxis("Mouse Y");
        //Debug.Log(gunTransform.rotation.eulerAngles.x);
        //Debug.Log(gunTransform.localRotation.eulerAngles.x + " local");
        float currentXRotation = gunTransform.rotation.eulerAngles.x;
        if (isInRange(0, 40, currentXRotation) || isInRange(320, 360, currentXRotation))
            gunTransform.Rotate(yRotation, 0, 0);
        else
        {
            if (isInRange(40, 45, currentXRotation) && yRotation < 0)
                gunTransform.Rotate(yRotation, 0, 0);
            if (isInRange(315,320, currentXRotation) && yRotation > 0)
                gunTransform.Rotate(yRotation, 0, 0);
        }

    }
    public bool isInRange(float min,float max, float variable){
        if (variable < max && variable >= min) return true;
        else return false;
    }
}
