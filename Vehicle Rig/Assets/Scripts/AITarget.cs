using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITarget : MonoBehaviour
{
   public GameObject Turret;
   public GameObject _player;
   private AIHealth health;
   public float throwForce = 1000.0f;
   public float throwTorque = 1000.0f;
   bool dead;
   
   void Awake()
   {
       _player = GameObject.FindWithTag("Player");
       health = transform.parent.GetComponent<AIHealth>();
   }
   
   void Update()
   {
        
        if(!dead)
        {
            Turret.transform.LookAt(_player.transform);
        }

        if(health.AIuHealth <= 0 && !dead)
        {
            dead = true;
            
            transform.parent = null;
            var Rbody = Turret.AddComponent<Rigidbody>();
            Rbody.mass = 80;
            Rbody.AddForce(transform.up * throwForce, ForceMode.Impulse);
            Rbody.AddTorque(transform.right * throwTorque, ForceMode.Impulse);
            Destroy(gameObject, 15f);
        }
   
   }
}
