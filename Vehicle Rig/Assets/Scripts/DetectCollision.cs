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

    void Update()
    {
        randomDamage = Random.Range(15.0f, 25.0f);
    }
    
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Shell"))
        {
            hitSFX.Play();
            Debug.Log("TAKING DAMAGE");
            PlayerHealth.instance.pHealth -= randomDamage;
            Debug.Log("Damge Done = " + randomDamage);
            StartCoroutine(cameraShake.Shake(.5f, .7f));
            StartCoroutine(cameraShake2.Shake(.4f, .3f));
        }

        if(collision.gameObject.CompareTag("Untagged"))
        {
            collisionSFX.Play();
            Debug.Log("MINOR DAMAGE");
            PlayerHealth.instance.pHealth -= 1.0f; 
        }

    }
}
