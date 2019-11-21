using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITarget : MonoBehaviour
{
   public GameObject Turret;
   public GameObject Player;
   
   void Update()
   {
       Turret.transform.LookAt(Player.transform);
   }
}
