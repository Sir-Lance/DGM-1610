using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{

    public Camera thirdPersonCamera;
    public Camera fcsCamera;
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
    }

    void ShowFCSCamera()
    {
        thirdPersonCamera.enabled = false;
        fcsCamera.enabled = true;
    }


}
