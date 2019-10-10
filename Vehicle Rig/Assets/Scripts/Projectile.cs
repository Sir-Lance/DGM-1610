using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
     public GameObject projectile;
    
    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonDown("Fire1"))
         {
             GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
             bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
         }
    }
}
