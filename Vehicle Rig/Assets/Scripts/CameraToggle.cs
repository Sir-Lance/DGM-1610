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

    void Update()
    {
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

    // Update is called once per frame
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
