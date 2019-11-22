using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFireControl : MonoBehaviour
{
    
    public float reloadRate = 7.2f;
    public bool chamber;
    bool trigger;
    public float range = 3000f;
    public float ejectForce = 3000.0f;
    public AudioSource firesfx;
    public GameObject originPoint;
    public GameObject boreOrigin;
    public GameObject projOrigin;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject boreSight;
    public GameObject ejectionOrigin;
    public GameObject spentShell;
    public GameObject projectileAP;
    public float muzzleVelocity = 20000.0f;
    public float randomFire;

    //killswitch
    private AIHealth health;


    
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

        randomFire = Random.Range(0.0f, 10000.0f);
        AIRaycast();

        
    //     //Takes mouse1 input to activate trigger
    //     if(Input.GetButtonDown("Fire1"))
    //     {
    //         Trigger();
            
    //         //checks if trigger was pulled and chamber was loaded
    //         if((trigger == true) & (chamber == true))
    //         {
    //             //fires the gun
    //             Fire();
    //             //Ejects round out of ejection port.
    //             Ejection();
                
    //         }
    //     }
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
        //fireAnim.Play();      
        
        //create rigid body projectile and yeet it at muzzleVelocity
        GameObject projectile = Instantiate(projectileAP, projOrigin.transform.position, projOrigin.transform.rotation);
        projectile.AddComponent<Rigidbody>().AddForce(transform.forward * muzzleVelocity);
        Destroy(projectile, 3f);

        //This starts the Reload
        if(chamber == false)
        {
            StartCoroutine("Reload", reloadRate);
        }
    }
    
    void AIRaycast(){
        RaycastHit hit;
        
        if(Physics.Raycast(originPoint.transform.position, originPoint.transform.forward, out hit, range))
        {
           Debug.Log(hit.transform.name);
           
           if(hit.transform.name == "MBTHull" && randomFire > 9000.0f && AIHealth.instance.AIuHealth > 0)
           {
                Trigger();
                
                if((trigger == true) & (chamber == true))
                {
                    //fires the gun
                    Fire();
                    //Ejects round out of ejection port.
                    Ejection();
                    Debug.Log("AI SHOOT");
                }    
            }
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
