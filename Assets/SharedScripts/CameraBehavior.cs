/*

    CameraBehavior Script
    
    Description:
        Camera follows "target".
        Use Scrollwheel to zoom in or out.

*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public float zoomSpeed = 50f;
    public float xOffset = 0f;
    public float yOffset = 50f;
    public float zOffset = -70f;

    public float zOffsetUpperLimit = -10f;
    public float zOffsetLowerLimit = -150f;
    // public Vector3 locationOffset;
    // public Vector3 rotationOffset;

    void Update()
    {

        // use mouse wheel to zoom in or out.
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (scroll != 0f)
        //{
        //    zOffset = zOffset + scroll * zoomSpeed;
        //    zOffset = Mathf.Min(zOffset, zOffsetUpperLimit);
        //    zOffset = Mathf.Max(zOffset, zOffsetLowerLimit);
        //}

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float newFov = gameObject.GetComponent<Camera>().fieldOfView + scroll * zoomSpeed;
            newFov = Mathf.Min(newFov, 90);
            newFov = Mathf.Max(newFov, 20);
            gameObject.GetComponent<Camera>().fieldOfView = newFov;
        }


        Vector3 locationOffset = new Vector3(xOffset, yOffset, zOffset);
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
        // Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        // Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        // transform.rotation = smoothedrotation;
    }
}

