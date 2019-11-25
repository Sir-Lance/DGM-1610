using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public float AIuHealth = 100.0f;
    public ParticleSystem AIengineSmoke;
    public ParticleSystem AIejectFire;
    public ParticleSystem AIhatchFire1;
    public ParticleSystem AIhatchFire2;
    
    bool play1;
    bool play2;
    bool play3;
    bool dead;

    // Update is called once per frame
    void Update()
    {
        //dead
        if(AIuHealth <= 0.0f && !dead)
        {
            dead = true;
            Debug.Log("Health = " + AIuHealth);
            Debug.Log("AI GAMEOVER");
            Destroy(gameObject, 15f);
            gameObject.tag = "Untagged";
        }

        
        //engine fire effect
        if(AIuHealth >= 0 && AIuHealth <= 50 && !play1)
        {
            play1 = true;
            AIengineSmoke.Play();
            Debug.Log("AI ENGINE FIRE");
        }
        
        //ejection port fire effect
        if(AIuHealth >= 0 && AIuHealth <= 35 && !play2)
        {
            play2 = true;
            AIejectFire.Play();
            Debug.Log("AI AMMO FIRE");
        }

        
        //hatch fire effect(critical damage)
        if(AIuHealth >= 0 && AIuHealth <= 20 && !play3)
        {
            play3 = true;
            AIhatchFire1.Play();
            AIhatchFire2.Play();
            Debug.Log("AI CRITICAL FAILURE");
        }
    }
}