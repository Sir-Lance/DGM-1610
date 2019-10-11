using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelElevation : MonoBehaviour
{
    public GameObject rotPoint;
    public float rotSpeed = 30.0f;
    public float verticalInput;
    public float maxElevation = -15.0f;
    public float maxDepression = 6.0f;

    // Update is called once per frame
    void Update()
    {
        //data types store data of vector3 for game object
        float rotX = transform.localRotation.eulerAngles.x;
        float rotY = transform.localRotation.eulerAngles.y;
        float rotZ = transform.localRotation.eulerAngles.z;
        
        //Takes mouse input to rotate barrel on Y axis
        verticalInput = Input.GetAxisRaw("Mouse Y");
        transform.Rotate(Vector3.left, rotSpeed * verticalInput * Time.deltaTime);
        
        //If statements prevent the gun from going past a certain depression or elevation
        
        //variable rotX spits out 360 degrees instead of 0
        //this changes the variable value to 0
        if(rotX > 180f)
        {
            rotX -= 360f;
        }

        if(rotX < -180f)
        {
            rotX += 360f;
        }
        
        
        //this scans if GameObject has reached the angle specified above
        if(rotX < maxElevation)
        {
            Vector3 newRot = new Vector3(maxElevation, rotY, rotZ);
            var angle = Quaternion.Euler(newRot);
            transform.localRotation = angle;
            Debug.Log("High");
        }
        
        //this scans if GameObject has reached the angle specified above
        if(rotX > maxDepression)
        {
            Vector3 newRot = new Vector3(maxDepression, rotY, rotZ);
            var angle = Quaternion.Euler(newRot);
            transform.localRotation = angle;
            Debug.Log("Low");
        }
        
        //Debug.Log(rotX);

        //Locks cursor to the center of the screen
        
        if (Input.GetKey(KeyCode.Escape))
        Screen.lockCursor = false;
        else
        Screen.lockCursor = true;    
    }
}