using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{

    public Camera thirdPersonCamera;
    public Camera fcsCamera;
    public Canvas thirdCameraUI;
    public Canvas fcsCameraUI;
    bool toggle;
    bool toggleFOV;

    void Update()
    {
        //Zoom in/out
        if(Input.GetButtonDown("Fire2"))
        {
            toggleFOV = !toggleFOV;
        }
        
        //reset every toggle switch
        if(Input.GetButtonDown("Jump"))
        {
            toggleFOV = false;
        }

        //Default Zoom
        if(toggleFOV == false)
        {
            fcsCamera.fieldOfView = 30.0f;
            thirdPersonCamera.fieldOfView = 80.0f;
        }

        //Zoomed In
        if(toggleFOV == true)
        {
            fcsCamera.fieldOfView = 10.0f;
            thirdPersonCamera.fieldOfView = 40.0f;
        }
        
        //Toggle camera between gunsight and thirdperson
        if(Input.GetButtonDown("Jump"))
        {
            toggle = !toggle;
        }

        if(toggle == false)
        {
            ShowThirdPerson();
        }

        if(toggle == true)
        {
            ShowFCSCamera();
        }
    }

    void ShowThirdPerson()
    {
        thirdPersonCamera.enabled = true;
        fcsCamera.enabled = false;
        thirdCameraUI.enabled = true;
        fcsCameraUI.enabled = false;

    }

    void ShowFCSCamera()
    {
        thirdPersonCamera.enabled = false;
        fcsCamera.enabled = true;
        thirdCameraUI.enabled = false;
        fcsCameraUI.enabled = true;

    }
    
}
