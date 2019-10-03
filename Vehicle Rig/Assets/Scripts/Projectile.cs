using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 60;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
