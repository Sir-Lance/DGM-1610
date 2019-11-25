using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    private PlayerHealth healthPoints;
    private EnemyCounter enemiesA;
    public float playerHP;
    public int enemiesAlive;


    void Start()
    {
        healthPoints = GameObject.Find("MBTHull").GetComponent<PlayerHealth>();
        enemiesA = GameObject.Find("Enemy Counter").GetComponent<EnemyCounter>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        playerHP = healthPoints.pHealth;
        enemiesAlive = enemiesA.enemies;
        if(playerHP <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level 1");
            Debug.Log("Reloading Scene");
            Time.timeScale = 1f;
        }

        if(playerHP <= 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenuX"); // Make thank you screen
            Debug.Log("Reloading Scene");
            Time.timeScale = 1f;
        }

        if(enemiesAlive <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //Testing
            SceneManager.LoadScene("MainMenuX"); // Change Sample Scene
            Debug.Log("Loading Next Scene");
        }
    }
}
