using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public AudioSource firesfx;
    public float reloadRate = 3.0f;
    public float reload;
    //public float fire = 0.0f;
    public float timer1 = 1.00f;
    public float timer2 = 1.00f;
    public bool chamber;
    public bool trigger;
    
    // Update is called once per frame
    void Update()
    {
        //Takes mouse1 input to activate trigger
        if(Input.GetButtonDown("Fire1"))
        {
            Trigger();
            
            //checks if triggger was pulled and chamber was loaded
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
        if(chamber == false){
            StartCoroutine("Reload", reloadRate);
        }
    }
    
    IEnumerator Reload(float ReloadTime)
    {
        yield return new WaitForSeconds (ReloadTime);
            chamber = true;
    }

    void Reset()
    {

    }

        
        // void TurretBackRecoil() {       
        //     transform.Translate(new Vector3(0,0,-50) * Time.deltaTime );         
        // }

        // void TurretForwardRecoil() {
        //     transform.Translate(new Vector3(0,0,50) * Time.deltaTime);
        // }

      
}
