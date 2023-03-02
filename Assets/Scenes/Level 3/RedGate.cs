using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGate : MonoBehaviour
{

    public Transform edgePivotPoint;
    public void OpenGate()
    {
        transform.RotateAround(edgePivotPoint.position, Vector3.down, 80);
        gameObject.GetComponent<UnityEngine.AI.OffMeshLink>().activated = true;
    }
}
