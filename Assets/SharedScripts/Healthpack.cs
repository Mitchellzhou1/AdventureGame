using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    public int healthAmount = 25;
    public GameObject explosion;

    public int getHealthAmount() 
    {
        return healthAmount;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
