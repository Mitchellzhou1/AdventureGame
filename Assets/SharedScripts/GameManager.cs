using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    int health = 100;
    string levelName;

    public TMPro.TextMeshProUGUI healthUI;
    public TMPro.TextMeshProUGUI levelUI;

    // private void Awake()
    // {
    //     Scene scene = SceneManager.GetActiveScene();
    //     levelName = scene.name;
    // }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        healthUI.text = health.ToString();
        levelUI.text = scene.name.ToString();
    }

    void Update(){
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }

    public void healthChanger(int number)
    {
        health += number;
        if (health >= 100){
            health = 100;
        }
        if (health < 1){
            health = 0;
            //goToScene("Game Over")
        }
        healthUI.text = health.ToString();
    }

    public int getHealth(){
        return health;
    }


    public void goToScene(string scene){
        StartCoroutine(sceneHelper(scene, 1));
    }

    IEnumerator sceneHelper (string scene, int seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }
}
