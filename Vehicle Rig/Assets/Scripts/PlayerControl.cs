using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Moves tank forward/back 
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       
        //Moves tank left/right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
    }
}
