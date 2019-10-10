using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    
    public float reloadRate = 7.2f;
    public bool chamber;
    bool trigger;
    //public GameObject projectilePrefab;
    public AudioSource firesfx;
    public GameObject originPoint;
    public float range = 1200f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject boreSight;
    
    // Update is called once per frame
    void Update()
    {
        //BoreSight
        RaycastHit hit;
        if(Physics.Raycast(originPoint.transform.position, originPoint.transform.forward, out hit, range))
        {
            GameObject boreTrace = Instantiate(boreSight, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(boreTrace, 0.01f);
        }
        
        
        //Takes mouse1 input to activate trigger
        if(Input.GetButtonDown("Fire1"))
        {
            Trigger();
            
            //checks if trigger was pulled and chamber was loaded
            if((trigger == true) & (chamber == true))
            {
                //fires the gun
                Fire();
                
            }
        }
    }

    void Trigger()
    {
        //Trigger Boolean activating
        trigger = true;
    }
    
    public void Fire()
    {
        //Fire function
        firesfx.Play();
        muzzleFlash.Play();
        chamber = false;      
        
        //raycast hitscan
        RaycastHit hit;
        if(Physics.Raycast(originPoint.transform.position, originPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

        //impact effect
        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 3f);

        //This starts the Reload
        if(chamber == false)
        {
            StartCoroutine("Reload", reloadRate);
        }
    }
    
    IEnumerator Reload(float reloadRate)
    {
        yield return new WaitForSeconds (reloadRate);
        chamber = true;
        trigger = false;
    }
     
}
