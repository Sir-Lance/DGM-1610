using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public float pHealth = 100.0f;
    public ParticleSystem engineSmoke;
    public ParticleSystem ejectFire;
    public ParticleSystem hatchFire1;
    public ParticleSystem hatchFire2;
    void Start()
    {
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(pHealth <= 0.0f)
        {
            Debug.Log("Health = " + pHealth);
            Debug.Log("GAMEOVER");
            Time.timeScale = 0.01f;
        }

        if(pHealth >= 0 && pHealth <= 50)
        {
            engineSmoke.Play();
            Debug.Log("ENGINE FIRE");
        }
        
        if(pHealth >= 0 && pHealth <= 25)
        {
            ejectFire.Play();
            Debug.Log("AMMO FIRE");
        }

        if(pHealth >= 0 && pHealth <= 10)
        {
            hatchFire1.Play();
            hatchFire2.Play();
            Debug.Log("CRITICAL FAILURE");
        }
    }
}