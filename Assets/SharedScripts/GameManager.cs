using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int health = 75;
    string levelName;

    public TMPro.TextMeshProUGUI healthUI;
    public TMPro.TextMeshProUGUI healthPackUI;
    public TMPro.TextMeshProUGUI levelUI;

    public AudioSource playerPainAudio;
    public AudioSource playerDeathAudio;

    public GameObject GotHitScreen;

    // private void Awake()
    // {
    //     Scene scene = SceneManager.GetActiveScene();
    //     levelName = scene.name;
    // }

    private GameObject _player;
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (healthUI != null) healthUI.text = health.ToString();
        if (levelUI != null) levelUI.text = scene.name.ToString();
        if (healthPackUI != null) healthPackUI.text = sharedVariable.getHealthPackNum().ToString();

        try
        {
            _player = GameObject.FindGameObjectsWithTag("Player")[0];

        }
        catch { }

    }

    void Update()
    {
#if !UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }

    void FixedUpdate() {


        // got hit screen
        if (GotHitScreen == null) return;
        if (GotHitScreen.GetComponent<Image>().color.a > 0.0f)
        {
            var color = GotHitScreen.GetComponent<Image>().color;
            color.a -= 0.01f;
            GotHitScreen.GetComponent<Image>().color = color;
        }

    }

    void gotHitScreen(float intensity=0.5f)
    {
        var color = GotHitScreen.GetComponent<Image>().color;
        color.a = intensity;
        GotHitScreen.GetComponent<Image>().color = color;
    }

    public void updateHealthPackCount(){
        healthPackUI.text = sharedVariable.getHealthPackNum().ToString();
    }

    private bool deathScreamAlreadyPlayed = false;
    public void healthChanger(int number)
    {

        int temp = health;
        health += number;

        if (health < temp && health >= 1)
        {
            playerPainAudio.Play();
            gotHitScreen();
        }

        if (health >= 100) health = 100;
        if (health < 1)
        {
            health = 0;

            _player.GetComponent<Player>().handleDeath();
            if (!deathScreamAlreadyPlayed) {
                playerDeathAudio.Play();
                gotHitScreen(0.9f);
                deathScreamAlreadyPlayed = true;
            }
            goToScene("Death Screen", 5);
        }
        healthUI.text = health.ToString();
    }

    public int getHealth()
    {
        return health;
    }


    public void goToScene(string scene, int waitFor=1)
    {
        StartCoroutine(sceneHelper(scene, waitFor));
    }

    IEnumerator sceneHelper(string scene, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }
}