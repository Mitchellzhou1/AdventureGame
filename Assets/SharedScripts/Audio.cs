using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("AUDIO");
        if (musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
