using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public GameObject impactEffect;
    public GameObject originPoint;
    public GameObject ricochetEffect;
    public GameObject originPointRC;
    public float rngBullshit;


    void OnCollisionEnter(Collision collision)
    {
        
        rngBullshit = Random.Range(0.0f, 10.0f);
        Debug.Log("RNG Bullshit = " + rngBullshit);
        if(rngBullshit < 5f){
            Detonate();
        }
        
        if(rngBullshit > 5f){
            Ricochet();
        }

    }
    
    void Ricochet()
    {
        GameObject impactFX = Instantiate(ricochetEffect, originPointRC.transform.position, originPointRC.transform.rotation);
        Debug.Log("Ricochet");
        Destroy(gameObject, 10f);
        Destroy(impactFX, 3.0f);
    }
    
    void Detonate()
    {
        GameObject impactFX = Instantiate(impactEffect, originPoint.transform.position, originPoint.transform.rotation);
        Debug.Log("FuseHit");
        Destroy(gameObject);
        Destroy(impactFX, 3.0f);

    }
}