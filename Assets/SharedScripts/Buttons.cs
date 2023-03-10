using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void StartGame(){
         SceneManager.LoadScene("Level 1");
    }

    public void Quit() {
#if !UNITY_WEBGL
        Application.Quit();
#endif

#if UNITY_WEBGL
        SceneManager.LoadScene("Main Menu");
#endif



    }
}
