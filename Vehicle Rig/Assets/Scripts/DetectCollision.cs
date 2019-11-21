using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{



    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Shell"))
        {
            Debug.Log("TAKING DAMAGE");
        }

        if(collision.gameObject.CompareTag("Untagged"))
        {
            Debug.Log("MINOR DAMAGE");
        }

    }
}
