using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToScene(string scene){
        StartCoroutine(sceneHelper(scene, 1));
    }

    IEnumerator sceneHelper (string scene, int seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }
}
