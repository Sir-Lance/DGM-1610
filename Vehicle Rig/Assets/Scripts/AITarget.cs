using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITarget : MonoBehaviour
{
   public GameObject Turret;
   public GameObject Player;
   private AIHealth health;
   
   void Update()
   {
        
        if(AIHealth.instance.AIuHealth >= 0)
        {
            Turret.transform.LookAt(Player.transform);
        }

        if(AIHealth.instance.AIuHealth <= 0)
        {
            transform.parent = null;
            
            Turret.AddComponent<Rigidbody>().AddForce(transform.up);
            Destroy(gameObject, 15f);
        }
   
   }
}
