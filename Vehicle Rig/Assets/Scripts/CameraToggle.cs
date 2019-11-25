using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraToggle : MonoBehaviour
{

    public Camera thirdPersonCamera;
    public Camera fcsCamera;
    public Canvas thirdCameraUI;
    public Canvas fcsCameraUI;
    private Pause pauseBool;
    bool toggle;
    bool toggleFOV;
    bool alive = true;
    private PlayerHealth healthPoints;


    void Awake()
    {
        pauseBool = GameObject.Find("PauseToggle").GetComponent<Pause>();
        healthPoints = GameObject.Find("MBTHull").GetComponent<PlayerHealth>();
    }

    //THIS SCRIPT ALSO HANDLES UI
    void Update()
    {
        if(healthPoints.pHealth <= 0)
        {
            alive = false;
        }
        
        //Zoom in/out
        if(Input.GetButtonDown("Fire2") && pauseBool.paused == false && alive)
        {
            toggleFOV = !toggleFOV;
        }
        
        //reset every toggle switch
        if(Input.GetButtonDown("Jump") && pauseBool.paused == false && alive)
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
        if(Input.GetButtonDown("Jump") && pauseBool.paused == false && alive)
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
