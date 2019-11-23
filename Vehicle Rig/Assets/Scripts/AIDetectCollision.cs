using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectCollision : MonoBehaviour
{
    public AudioSource collisionSFX;
    public AudioSource hitSFX;
    private AIHealth health;
    float randomDamage;

    void Awake() 
    {
        health = GetComponent<AIHealth>();
    }
    
    void Update()
    {
        randomDamage = Random.Range(10.0f, 20.0f);
    }
    
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Shell"))
        {
            hitSFX.Play();
            Debug.Log("AI TAKING DAMAGE");
            health.AIuHealth -= randomDamage;
            Debug.Log("Damge Done = " + randomDamage);
        }

        if(collision.gameObject.CompareTag("Untagged"))
        {
            collisionSFX.Play();
            Debug.Log("AI MINOR DAMAGE");
            health.AIuHealth -= 1.0f; 
        }

    }
}
