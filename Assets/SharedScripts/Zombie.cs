using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    
    NavMeshAgent _navMeshAgent;
    GameObject player;
    public float milliseconds;
    public float LOSDistance = 100.0f;

    public AudioSource zombiegroan;

    float randomTiming;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Groan());
    }

    IEnumerator Groan()
    {
        while(true)
        {
            zombiegroan.Play();
            randomTiming = Random.Range(4.0f, 15.0f);
            yield return new WaitForSeconds(randomTiming);
        }
    }

    void Update()
    {

    }

    void FixedUpdate(){

        RaycastHit hit;
        int layerMask = 1 << 6;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, LOSDistance,layerMask)){
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
