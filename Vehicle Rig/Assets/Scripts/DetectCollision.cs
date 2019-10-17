using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{



    void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject, 3f);
        
        //too destructive
        //Destroy(collision.gameObject, 10f);

    }
}
