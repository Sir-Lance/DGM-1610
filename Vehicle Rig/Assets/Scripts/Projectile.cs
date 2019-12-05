using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public GameObject impactEffect;
    public GameObject originPoint;
    public GameObject ricochetEffect;
    public GameObject originPointRC;
    
    //TEST
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
        
        //ricochet chance if less than X detonate
        if(rngBullshit < 7f){
            Detonate();
        }
        
        if(rngBullshit > 7f){
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

        //change shell tag when ricochet
        gameObject.tag = "Untagged";
    }
    
    void Detonate()
    {
        //on roll shell will detonate and cause damage
        GameObject impactFX = Instantiate(impactEffect, originPoint.transform.position, originPoint.transform.rotation);
        
        //TEST
        //GameObject detonationPoint = Instantiate(detPoint, originPoint.transform.position, originPoint.transform.rotation);
        
        Debug.Log("FuseHit");
        Destroy(gameObject);
        Destroy(impactFX, 3.0f);
        
        //Test
        //Destroy(detonationPoint, 0.5f);

        //change tag on shell when detonated
        gameObject.tag = "Shell";

    }
}