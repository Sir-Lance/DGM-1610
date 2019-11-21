using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public GameObject impactEffect;
    public GameObject originPoint;
    public GameObject ricochetEffect;
    public GameObject originPointRC;
    //public GameObject detPoint;
    public float rngBullshit;
    Rigidbody m_Proj;


    void Start()
    {
        //Change the collision detection of the projectile immediately after Instantiate
        m_Proj = GetComponent<Rigidbody>();
        m_Proj.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        m_Proj.mass = 5;

        gameObject.tag = "Untagged";
    }
    
    void OnCollisionEnter(Collision collision)
    {
        
        //self explanatory
        rngBullshit = Random.Range(0.0f, 10.0f);
        Debug.Log("RNG Bullshit = " + rngBullshit);
        if(rngBullshit < 8f){
            Detonate();
        }
        
        if(rngBullshit > 2f){
            Ricochet();
        }

    }
    
    void Ricochet()
    {
        //on roll shell will ricochet
        GameObject impactFX = Instantiate(ricochetEffect, originPointRC.transform.position, originPointRC.transform.rotation);
        Debug.Log("Ricochet");
        Destroy(gameObject, 10f);
        Destroy(impactFX, 3.0f);

        gameObject.tag = "Untagged";
    }
    
    void Detonate()
    {
        //on roll shell will detonate and cause damage
        GameObject impactFX = Instantiate(impactEffect, originPoint.transform.position, originPoint.transform.rotation);
        //GameObject detonationPoint = Instantiate(detPoint, originPoint.transform.position, originPoint.transform.rotation);
        Debug.Log("FuseHit");
        Destroy(gameObject, 0.1f);
        Destroy(impactFX, 3.0f);
        //Destroy(detonationPoint, 0.5f);

        gameObject.tag = "Shell";

    }
}