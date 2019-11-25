using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectCollision : MonoBehaviour
{
    public AudioSource collisionSFX;
    public AudioSource hitSFX;
    private AIHealth health;
    float randomDamage;
    bool alive = true;
    public float killSwitchHP;

    void Awake() 
    {
        health = GetComponent<AIHealth>();
    }
    
    void Update()
    {
        killSwitchHP = health.AIuHealth;
        randomDamage = Random.Range(15.0f, 25.0f);
        if(health.AIuHealth <= 0f)
        {
            alive = false;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Shell"))
        {
            if(alive)
            {
                hitSFX.Play();
            }
            
            Debug.Log("AI TAKING DAMAGE");
            health.AIuHealth -= randomDamage;
            Debug.Log("Damge Done = " + randomDamage);
        }

        if(collision.gameObject.CompareTag("Untagged"))
        {
            if(alive)
            {
                collisionSFX.Play();
            }
            
            Debug.Log("AI MINOR DAMAGE");
            health.AIuHealth -= 1.0f; 
        }

    }
}
