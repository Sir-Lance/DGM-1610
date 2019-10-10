using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    
    public float reloadRate = 1.8f;
    public bool chamber;
    bool trigger;
    //public GameObject projectilePrefab;
    public AudioSource firesfx;
    public GameObject originPoint;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public GameObject muzzlePrefab;
    
    // Update is called once per frame
    void Update()
    {
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
    
    void Fire()
    {
        //Fire function
        firesfx.Play();
        muzzleFlash.Play();
        chamber = false;
        //Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        Instantiate(muzzleFlash);
        //raycast hitscan
        RaycastHit hit;
        if(Physics.Raycast(originPoint.transform.position, originPoint.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        }
        
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
