using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform cameraTransform;
    public Transform playertransform;
    public float unitsAbove = 2f;
    public float xAngle = 15f;
    public float unitsDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = gameObject.transform;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;
        Vector3 cameraVector = zeroY(playertransform.position - hit.point);
        cameraVector = cameraVector.normalized;
        //Debug.Log(playertransform.position - cameraVector * unitsDistance + new Vector3(0, unitsAbove, 0));

    }
    private Vector3 zeroY(Vector3 vectorWithY){
        vectorWithY.y = 0;
        return vectorWithY;
        }
}
