using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    
    NavMeshAgent _navMeshAgent;
    GameObject player;
    public float milliseconds;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate(){

        RaycastHit hit;
        int layerMask = 1 << 6;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, 100.0f,layerMask)){
            print("SPOTTED");
            StartCoroutine(ChasePlayer());
        }
    }

    IEnumerator ChasePlayer(){
        while (true){
            yield return new WaitForSeconds(milliseconds);
            _navMeshAgent.destination = player.transform.position;
        }
    }

}
