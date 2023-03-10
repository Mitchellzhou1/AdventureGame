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
    int numKey2;
    int health;
    public string nextLevel;
    
    private bool isDead = false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        mainCam = Camera.main;
        hasKey = false;
        numKey2 = 0;

    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead){
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 300)){
                print(hit.point);
                _navMeshAgent.destination = hit.point;
            }
        }
        if(Input.GetKeyDown("space")){
            if(sharedVariable.getHealthPackNum()<=0){
                print("Oh No! No health packs left!!");
            }
            else{
                _gameManager.healthChanger(25);
                sharedVariable.updateHealthPackNum(-1);
                _gameManager.updateHealthPackCount();
            }
        }
    }

    public void handleDeath() {
        isDead = true;

        // disable animator to play rigidbody. Disabling animator somehow send 
        // the player flying into air. As a workaround, lock the player position before disabling animator.
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;


        GetComponent<Animator>().enabled = false;

        GetComponent<NavMeshAgent>().enabled = false;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Key") && hasKey == false){
            print("You have picked up the key");
            hasKey = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Key2")){
            print("You have picked up the key2");
            numKey2+=1;
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
        else if (other.CompareTag("Door2")){
            if (numKey2>0){
                numKey2 -= 1;
                print(numKey2);
                Destroy(other.gameObject);
            }
            else
                print("You don't have the key! Please collect it and come back");
        }
        else if (other.CompareTag("Healthpack")){
            sharedVariable.updateHealthPackNum(1);
            _gameManager.updateHealthPackCount();
        }
    }
}
