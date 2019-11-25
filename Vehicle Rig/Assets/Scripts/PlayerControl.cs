using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    //private float speed = 20.0f; //legacy speed float
    public float turnSpeed = 100.0f;
    public float speed2 = 100.0f;
    private float neutral = 0.0f;
    public float brake = 30.0f;
    public float pivotPoint = 1000.0f;
    public float horizontalInput;
    public float forwardInput;
    public float pivotAssistForce = 30.0f;
    
    //speed calculator
    Vector3 FramePosition = Vector3.zero;
    public float spdUpdate;


    //audioevents
    public AudioSource moving;
    public AudioSource stopped;
    public AudioSource idle;
    
    //right wheel colliders
    public GameObject w1r;
    public GameObject w2r;
    public GameObject w3r;
    public GameObject w4r;
    public GameObject w5r;
    public GameObject w6r;
    public GameObject w7r;

    
    //left wheel colliders
    public GameObject w1l;
    public GameObject w2l;
    public GameObject w3l;
    public GameObject w4l;
    public GameObject w5l;
    public GameObject w6l;
    public GameObject w7l;

    private Pause pauseBool;
    bool alive = true;
    private PlayerHealth healthPoints;

    
    void Awake()
    {
        pauseBool = GameObject.Find("PauseToggle").GetComponent<Pause>();
        healthPoints = GameObject.Find("MBTHull").GetComponent<PlayerHealth>();
    }



    // Update is called once per frame
    void Update()
    {
        if(healthPoints.pHealth <= 0)
        {
            alive = false;
        }
        
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        //speed calculator
        float movementCheck = Vector3.Distance (FramePosition, transform.position);
        spdUpdate = movementCheck / Time.deltaTime;
        FramePosition = transform.position;
        
        
        //CURRENTLY IN USE
        //PivotAssist
        //Rotates Tank because figuring out the phyics on 
        //wheelcolliders to make a vehicle
        //neutral steer is fucking annoying.
        if(pauseBool.paused == false && alive)
        {
            transform.Rotate(Vector3.up, pivotAssistForce * horizontalInput * Time.deltaTime);
        }
        
        //neutral / full brake
        if(forwardInput == 0 && horizontalInput == 0  && pauseBool.paused == false && alive){
            
            //Audio Event
            moving = GetComponent<AudioSource>();
            moving.pitch = 0.8f;
            //stopped.Play();

            //torque back to 0
            //when input is 0 torque is set to neutral = 0
            w1r.GetComponent<WheelCollider>().motorTorque = neutral;
            w2r.GetComponent<WheelCollider>().motorTorque = neutral;
            w3r.GetComponent<WheelCollider>().motorTorque = neutral;
            w4r.GetComponent<WheelCollider>().motorTorque = neutral;
            w5r.GetComponent<WheelCollider>().motorTorque = neutral;
            w6r.GetComponent<WheelCollider>().motorTorque = neutral;
            w7r.GetComponent<WheelCollider>().motorTorque = neutral;
            w1l.GetComponent<WheelCollider>().motorTorque = neutral;
            w2l.GetComponent<WheelCollider>().motorTorque = neutral;
            w3l.GetComponent<WheelCollider>().motorTorque = neutral;
            w4l.GetComponent<WheelCollider>().motorTorque = neutral;
            w5l.GetComponent<WheelCollider>().motorTorque = neutral;
            w6l.GetComponent<WheelCollider>().motorTorque = neutral;
            w7l.GetComponent<WheelCollider>().motorTorque = neutral;
            
            //brake
            //apply brake while no input
            w1r.GetComponent<WheelCollider>().brakeTorque = brake;
            w2r.GetComponent<WheelCollider>().brakeTorque = brake;
            w3r.GetComponent<WheelCollider>().brakeTorque = brake;
            w4r.GetComponent<WheelCollider>().brakeTorque = brake;
            w5r.GetComponent<WheelCollider>().brakeTorque = brake;
            w6r.GetComponent<WheelCollider>().brakeTorque = brake;
            w7r.GetComponent<WheelCollider>().brakeTorque = brake;
            w1l.GetComponent<WheelCollider>().brakeTorque = brake;
            w2l.GetComponent<WheelCollider>().brakeTorque = brake;
            w3l.GetComponent<WheelCollider>().brakeTorque = brake;
            w4l.GetComponent<WheelCollider>().brakeTorque = brake;
            w5l.GetComponent<WheelCollider>().brakeTorque = brake;
            w6l.GetComponent<WheelCollider>().brakeTorque = brake;
            w7l.GetComponent<WheelCollider>().brakeTorque = brake;
        }
        
        //forward input
        if(forwardInput > 0 && pauseBool.paused == false && alive){
            
            //Audio Event
            moving = GetComponent<AudioSource>();
            moving.pitch = 2f;
            
            //motorTorque forward
            //right
            w1r.GetComponent<WheelCollider>().motorTorque = speed2;
            w2r.GetComponent<WheelCollider>().motorTorque = speed2;
            w3r.GetComponent<WheelCollider>().motorTorque = speed2;
            w4r.GetComponent<WheelCollider>().motorTorque = speed2;
            w5r.GetComponent<WheelCollider>().motorTorque = speed2;
            w6r.GetComponent<WheelCollider>().motorTorque = speed2;
            w7r.GetComponent<WheelCollider>().motorTorque = speed2;
            
            //left
            w1l.GetComponent<WheelCollider>().motorTorque = speed2;
            w2l.GetComponent<WheelCollider>().motorTorque = speed2;
            w3l.GetComponent<WheelCollider>().motorTorque = speed2;
            w4l.GetComponent<WheelCollider>().motorTorque = speed2;
            w5l.GetComponent<WheelCollider>().motorTorque = speed2;
            w6l.GetComponent<WheelCollider>().motorTorque = speed2;
            w7l.GetComponent<WheelCollider>().motorTorque = speed2;

            //release brake
            //right
            w1r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w5r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7r.GetComponent<WheelCollider>().brakeTorque = neutral;
            //left
            w1l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w5l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7l.GetComponent<WheelCollider>().brakeTorque = neutral;
        }

        //reverse input
        if(forwardInput < 0 && pauseBool.paused == false && alive){
            
            //Audio Event
            moving = GetComponent<AudioSource>();
            moving.pitch = 2f;
            
            //motorTorque back
            //right
            w1r.GetComponent<WheelCollider>().motorTorque = -speed2;
            w2r.GetComponent<WheelCollider>().motorTorque = -speed2;
            w3r.GetComponent<WheelCollider>().motorTorque = -speed2;
            w4r.GetComponent<WheelCollider>().motorTorque = -speed2;
            w5r.GetComponent<WheelCollider>().motorTorque = -speed2;
            w6r.GetComponent<WheelCollider>().motorTorque = -speed2;
            w7r.GetComponent<WheelCollider>().motorTorque = -speed2;
            
            //left
            w1l.GetComponent<WheelCollider>().motorTorque = -speed2;
            w2l.GetComponent<WheelCollider>().motorTorque = -speed2;
            w3l.GetComponent<WheelCollider>().motorTorque = -speed2;
            w4l.GetComponent<WheelCollider>().motorTorque = -speed2;
            w5l.GetComponent<WheelCollider>().motorTorque = -speed2;
            w6l.GetComponent<WheelCollider>().motorTorque = -speed2;
            w7l.GetComponent<WheelCollider>().motorTorque = -speed2;

            //release brake
            //right
            w1r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w5r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7r.GetComponent<WheelCollider>().brakeTorque = neutral;
            //left
            w1l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w5l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7l.GetComponent<WheelCollider>().brakeTorque = neutral;
        }

        //turn right input
        if(horizontalInput > 0 && pauseBool.paused == false && alive){
            
            moving = GetComponent<AudioSource>();
            moving.pitch = 2f;
            
            //motorTorque left - tank tracks use inverse operation to turn
            //right turns backward
            w1r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w2r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w3r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w4r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w5r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w6r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w7r.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            
            //left neutral
            w1l.GetComponent<WheelCollider>().motorTorque = neutral;
            w2l.GetComponent<WheelCollider>().motorTorque = neutral;
            w3l.GetComponent<WheelCollider>().motorTorque = neutral;
            w4l.GetComponent<WheelCollider>().motorTorque = neutral;
            w5l.GetComponent<WheelCollider>().motorTorque = neutral;
            w6l.GetComponent<WheelCollider>().motorTorque = neutral;
            w7l.GetComponent<WheelCollider>().motorTorque = neutral;

            //brakes
            //apply right brake
            w1r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4r.GetComponent<WheelCollider>().brakeTorque = pivotPoint;
            w5r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7r.GetComponent<WheelCollider>().brakeTorque = neutral;

            //release left brake
            w1l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w5l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7l.GetComponent<WheelCollider>().brakeTorque = neutral;


        }
        
        //turn left input
        if(horizontalInput < 0 && pauseBool.paused == false && alive){
            
            //Audio Event
            moving = GetComponent<AudioSource>();
            moving.pitch = 2f;

            //motorTorque right - tank tracks use inverse operation to turn
            //right neutral
            w1r.GetComponent<WheelCollider>().motorTorque = neutral;
            w2r.GetComponent<WheelCollider>().motorTorque = neutral;
            w3r.GetComponent<WheelCollider>().motorTorque = neutral;
            w4r.GetComponent<WheelCollider>().motorTorque = neutral;
            w5r.GetComponent<WheelCollider>().motorTorque = neutral;
            w6r.GetComponent<WheelCollider>().motorTorque = neutral;
            w7r.GetComponent<WheelCollider>().motorTorque = neutral;

            
            //left turns backward
            w1l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w2l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w3l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w4l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w5l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w6l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            w7l.GetComponent<WheelCollider>().motorTorque = -turnSpeed;
            
            //brakes
            //release right brake
            w1r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w5r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6r.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7r.GetComponent<WheelCollider>().brakeTorque = neutral;

            //apply left brake
            w1l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w2l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w3l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w4l.GetComponent<WheelCollider>().brakeTorque = pivotPoint;
            w5l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w6l.GetComponent<WheelCollider>().brakeTorque = neutral;
            w7l.GetComponent<WheelCollider>().brakeTorque = neutral;
        }
        
        
        //Legacy
        //Moves tank forward/back 
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
        //Legacy
        //Moves tank left/right
        
        //No Longer Legacy

        
        

    }
}
