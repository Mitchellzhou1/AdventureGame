using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    GameManager _gameManager;
    Camera mainCam;
    bool hasKey;
    int health;
    public string nextLevel;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        mainCam = Camera.main;
        health = 100;
        hasKey = false;

    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                _navMeshAgent.destination = hit.point;
            }
        }

    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Key")){
            hasKey = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sprint Zombie") || other.CompareTag("Jog Zombie") || other.CompareTag("Walk Zombie")){
            health -= 15;
        }
        if (other.CompareTag("Door") && hasKey){
            _gameManager.goToScene(nextLevel);
        }
    }
}
