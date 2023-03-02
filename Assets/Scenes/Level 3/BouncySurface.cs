using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    // Start is called before the first frame update

    public float ySpeed = 5000f;

    private Rigidbody _rb;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("aass");
        _rb = other.rigidbody;
        _rb.AddForce(new Vector3(0, ySpeed, 0));
    }
}
