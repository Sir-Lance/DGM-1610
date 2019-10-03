using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public AudioSource firesfx;
    public float reloadRate = 1.8f;
    public bool chamber;
    bool trigger;
    public GameObject projectilePrefab;
    
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
        chamber = false;
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        
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
