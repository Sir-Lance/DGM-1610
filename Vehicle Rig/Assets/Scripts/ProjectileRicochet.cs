using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRicochet : MonoBehaviour
{
    public GameObject ricochetEffect;

    void OnTriggerEnter(Collider other)
    {
         float posX = transform.position.x;
         float posY = transform.position.y;
         float posZ = transform.position.z;

         Vector3 newPos = new Vector3(posX, posY, posZ);
         GameObject impactFX = Instantiate(ricochetEffect, newPos, Quaternion.LookRotation(newPos));
         Destroy(gameObject, 10f);
         

    }
}
