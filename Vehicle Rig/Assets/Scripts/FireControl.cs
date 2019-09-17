using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public AudioSource mouseclick;
    public float recoil = 0.0f;
    public float delay = 0.0f;
    public float reset = 3.0f;
    public float spent = 0.0f;
    public float fire = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
         if(delay >= 1.0f){
                TurretForwardRecoil();
                delay-= 1.0f;
            }
            
        recoil = Time.deltaTime * 0.0f;
        
        
        if(Input.GetButtonDown("Fire1")){
            fire = 1.0f;
        }
        
        if((fire = 1.0f) & (spent = 0.0f))
        {

            Fire();
        }
        if(recoil > 0.0f){
             
            TurretBackRecoil();
            delay+= 1.0f;
        }
 
    }
        void TurretBackRecoil() {       
            transform.Translate(new Vector3(0,0,-50) * Time.deltaTime );         
        }

        void TurretForwardRecoil() {
            transform.Translate(new Vector3(0,0,50) * Time.deltaTime);
        }

        void Fire(){
            spent = 1.0f;
            if(spent = 1.0f){
                reset-= 1.0f;
            }
            recoil+= 0.2f;
            mouseclick.Play();
            reset = 3.0f;
            if(reset >= 3.0f){
                fire = 0.0f;
                spent = 0.0f;
            }

        }
    }
