using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    
    public float reloadRate = 7.2f;
    public bool chamber;
    bool trigger;
    public float range = 3000f;
    public float ejectForce = 3000.0f;
    public AudioSource firesfx;
    public GameObject originPoint;
    public GameObject boreOrigin;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject boreSight;
    public GameObject ejectionOrigin;
    public GameObject spentShell;
    public GameObject projectileAP;
    public float muzzleVelocity = 57000.0f;
    public CameraShake cameraShake;
    public CameraShake cameraShake2;
    public int ammo = 70;

    
    // Update is called once per frame
    void Update()
    {
        //draws BoreSight with raycast from the muzzle gameobject
        RaycastHit hit;
        if(Physics.Raycast(boreOrigin.transform.position, boreOrigin.transform.forward, out hit, range))
        {
            GameObject boreTrace = Instantiate(boreSight, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(boreTrace, 0.01f);
        }

        
        //Takes mouse1 input to activate trigger
        if(Input.GetButtonDown("Fire1"))
        {
            Trigger();
            
            //checks if trigger was pulled and chamber was loaded
            if((trigger == true) & (chamber == true) & (ammo > 0))
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
        //ejects casing out of the rear for style
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
        ammo -= 1;
        
        //LEGACY
        //fireAnim.Play();      
        
        //create rigid body projectile and yeet it at muzzleVelocity
        GameObject projectile = Instantiate(projectileAP, originPoint.transform.position, originPoint.transform.rotation);
        projectile.AddComponent<Rigidbody>().AddForce(transform.forward * muzzleVelocity);
        Destroy(projectile, 15f);
        
        //starts camerashake script for FCS Camera
        StartCoroutine(cameraShake.Shake(.5f, .7f));
        //starts camerashake script for Main Camera
        StartCoroutine(cameraShake2.Shake(.4f, .3f));
        
        //-----LEGACY-----
        //raycast hitscan
        //RaycastHit hit;
        //if(Physics.Raycast(originPoint.transform.position, originPoint.transform.forward, out hit, range))
        //{
        //    Debug.Log(hit.transform.name);
        //}

        //impact effect when hit is registered on mesh/rigidbody
        // GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroy(impactGO, 3f);
        //-----LEGACY-----

        //This starts the Reload
        if(chamber == false)
        {
            StartCoroutine("Reload", reloadRate);
        }
    }
    
    IEnumerator Reload(float reloadRate)
    {
        yield return new WaitForSeconds (reloadRate);
        
        //loads next round in chamber - bool state true
        chamber = true;
        
        //resets trigger bool
        trigger = false;
    }
     
}
