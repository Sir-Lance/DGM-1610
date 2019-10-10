using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    
    public float reloadRate = 7.2f;
    public bool chamber;
    bool trigger;
    public float range = 1200f;
    public float ejectForce = 400.0f;
    public AudioSource firesfx;
    public GameObject originPoint;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject boreSight;
    public GameObject ejectionOrigin;
    public GameObject spentShell;

    
    // Update is called once per frame
    void Update()
    {
        //draws BoreSight with raycast from the muzzle gameobject
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
                //Ejects round out of ejection port.
                Ejection();
                
            }
        }
    }

    void Trigger()
    {
        //Trigger Boolean activating
        trigger = true;
    }

    void Ejection()
    {
        GameObject casing = Instantiate(spentShell, ejectionOrigin.transform.position, ejectionOrigin.transform.rotation);
        casing.AddComponent<Rigidbody>().AddForce(transform.forward * -ejectForce);
        Destroy(casing, 30.0f);
        
    }
    
    void Fire()
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

        //impact effect when hit is registered on mesh/rigidbody
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
