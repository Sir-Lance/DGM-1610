using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 90.0f;
    public float horizontalInput;
    public float forwardInput;
    
    //right wheel colliders
    public GameObject w1r;
    public GameObject w2r;
    public GameObject w3r;
    public GameObject w4r;
    public GameObject w5r;
    //left wheel colliders
    public GameObject w1l;
    public GameObject w2l;
    public GameObject w3l;
    public GameObject w4l;
    public GameObject w5l;

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        // if(forwardInput == 1){
        //     w1rC = GetComponent<WheelCollider>();
        //     w1rC.motorTorque = 10000;
        // }
        
        
        //Legacy
        //Moves tank forward/back 
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
        //Legacy
        //Moves tank left/right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
    }
}
