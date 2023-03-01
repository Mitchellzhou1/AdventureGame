using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Destroy(other.gameObject);
            print("THIS FUNCTIUON");
    
        }
    }
}
