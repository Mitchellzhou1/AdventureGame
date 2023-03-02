using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour
{

    public GameObject redGate;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            redGate.GetComponent<RedGate>().OpenGate();
        }
    }
}
