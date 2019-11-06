using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float pHealth = 100.0f;
    //public AudioSource hitSound;
    


    // Update is called once per frame
    void Update()
    {
        if(pHealth <= 0.0f)
        {
            Debug.Log("Game Over");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayerHitbox"))
        {
            //hitSound.Play();
            Debug.Log("Health: " + pHealth);
        }
        else if(collision.gameObject.CompareTag("Shell"))
        {
            pHealth -= 25.0f;
            Debug.Log("TAKING DAMAGE");
            Debug.Log("Health = " + pHealth);
            //hitSound.Play();
        }
    }
}
