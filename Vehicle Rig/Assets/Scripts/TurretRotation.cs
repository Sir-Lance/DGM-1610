using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public GameObject turret;
    public float rotSpeed = 50.0f;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        //Takes mouse input to rotate turret on X axis
        horizontalInput = Input.GetAxisRaw("Mouse X");
        transform.Rotate(Vector3.up, rotSpeed * horizontalInput * Time.deltaTime);
        
        //Locks cursor to the center of the screen
        
        if (Input.GetKey(KeyCode.Escape))
        Screen.lockCursor = false;
        else
        Screen.lockCursor = true;    
    }
}
