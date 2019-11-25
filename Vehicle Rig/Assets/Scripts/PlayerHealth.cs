using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float pHealth = 100.0f;
    public ParticleSystem engineSmoke;
    public ParticleSystem ejectFire;
    public ParticleSystem hatchFire1;
    public ParticleSystem hatchFire2;
    public AudioSource deathSFX;
    public AudioSource deathSFX2;
    
    bool play1;
    bool play2;
    bool play3;
    bool dead;

    //instance the player ebcause there is only one player
    
    // Update is called once per frame
    void Update()
    {
        //player dies
        if(pHealth <= 0.0f && !dead)
        {
            dead = true;
            Debug.Log("Health = " + pHealth);
            Debug.Log("GAMEOVER");
            deathSFX.Play();
            deathSFX2.Play();
            //slow down time on player death
            Time.timeScale = 0f;
        }

        //show damage state visually
        if(pHealth >= 0 && pHealth <= 50 && !play1)
        {
            play1 = true;
            engineSmoke.Play();
            Debug.Log("ENGINE FIRE");
        }
        
        //show damage state visually
        if(pHealth >= 0 && pHealth <= 35 && !play2)
        {
            play2 = true;
            ejectFire.Play();
            Debug.Log("AMMO FIRE");
        }

        //show damage state visually
        if(pHealth >= 0 && pHealth <= 20 && !play3)
        {
            play3 = true;
            hatchFire1.Play();
            hatchFire2.Play();
            Debug.Log("CRITICAL FAILURE");
        }
    }
}