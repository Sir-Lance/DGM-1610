using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelElevation : MonoBehaviour
{
    public GameObject rotPoint;
    public float rotSpeed = 30.0f;
    public float verticalInput;
    public float maxElevation = -8.0f;
    public float maxDepression = 6.0f;

    // Update is called once per frame
       void Update()
    {
        //Takes mouse input to rotate barrel on Y axis
        verticalInput = Input.GetAxisRaw("Mouse Y");
        transform.Rotate(Vector3.left, rotSpeed * verticalInput * Time.deltaTime);
        
        //If statements prevent the gun from going past a certain depression or elevation
        
         

        //Locks cursor to the center of the screen
        
        if (Input.GetKey(KeyCode.Escape))
        Screen.lockCursor = false;
        else
        Screen.lockCursor = true;    
    }
}