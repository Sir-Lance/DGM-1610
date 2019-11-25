using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public AudioSource collisionSFX;
    public AudioSource hitSFX;
    private PlayerHealth health;
    public CameraShake cameraShake;
    public CameraShake cameraShake2;
    float randomDamage;

    void Awake()
    {
        health = GetComponent<PlayerHealth>();
    }
    
    void Update()
    {
        randomDamage = Random.Range(10.0f, 15.0f);
    }
    
    void OnCollisionEnter(Collision collision)
    {

        //if player collides with "Shell" then RNG roll how much damage player will recieve. and play a sound.
        if(collision.gameObject.CompareTag("Shell"))
        {
            hitSFX.Play();
            Debug.Log("TAKING DAMAGE");
            health.pHealth -= randomDamage;
            Debug.Log("Damge Done = " + randomDamage);
            StartCoroutine(cameraShake.Shake(.5f, .7f));
            StartCoroutine(cameraShake2.Shake(.4f, .3f));
        }

        //If player collides with objects, do 1DMG - this will also handle enemy projectiles which possibly ricochet off your armor
        if(collision.gameObject.CompareTag("Untagged"))
        {
            collisionSFX.Play();
            Debug.Log("MINOR DAMAGE");
            health.pHealth -= 1.0f; 
        }

    }
}
