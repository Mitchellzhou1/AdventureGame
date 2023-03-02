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
        hasKey = false;

    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 300)){
                print(hit.point);
                _navMeshAgent.destination = hit.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Key") && hasKey == false){
            print("You have picked up the key");
            hasKey = true;
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Sprint Zombie") || other.CompareTag("Jog Zombie") || other.CompareTag("Walk Zombie")){
            _gameManager.healthChanger(-15);
        }
        else if (other.CompareTag("OtherDoor"))
        {
            if (hasKey){
                hasKey = false;
                Destroy(other.gameObject);
            }
            else
            {
                print("You don't have the key! Please collect it and come back");
            }
        }
        else if (other.CompareTag("Door")){
            if (hasKey){
                hasKey = false;
                _gameManager.goToScene(nextLevel);
            }
            else
                print("You don't have the key! Please collect it and come back");
        }
        else if (other.CompareTag("Healthpack")){
            _gameManager.healthChanger(25);
        }
    }
}
