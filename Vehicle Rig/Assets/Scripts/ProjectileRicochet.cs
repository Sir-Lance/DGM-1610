// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ProjectileRicochet : MonoBehaviour
// {
//     public GameObject ricochetEffect;
//     public GameObject RCoriginPoint;

//     void OnTriggerEnter(Collider other)
//     {
//          Detonate();
//     }
//     void Detonate()
//     {
//         GameObject impactFX = Instantiate(ricochetEffect, originPoint.transform.position, originPoint.transform.rotation);
//         Debug.Log("Ricochet");
//         Destroy(gameObject, 10f);
//         Destroy(impactFX, 3.0f);
//     }
// }

