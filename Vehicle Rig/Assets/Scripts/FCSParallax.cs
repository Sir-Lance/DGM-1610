// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FCSParallax : MonoBehaviour
// {
//     public Transform fcscam;
    
//     void Update()
//     {
//         RaycastHit hit;
//         if(Physics.Raycast(originPoint.transform.position, originPoint.transform.forward, out hit, range))
//         {
//             GameObject boreTrace = Instantiate(boreSight, hit.point, Quaternion.LookRotation(hit.normal));
//             Vector3 hitPosition = hit.point;
//             Destroy(boreTrace, 0.01f);
//         }
//     }
// }
