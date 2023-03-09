using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StupidZombie : MonoBehaviour
{
    
    NavMeshAgent _navMeshAgent;
    GameObject player;
    public float milliseconds;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("temp");
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer(){
        while (true){
            yield return new WaitForSeconds(milliseconds);
            _navMeshAgent.destination = player.transform.position;
        }
    }

}
