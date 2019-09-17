using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, 3);
    //private Vector3 rotateVal = new Vector3(0, -90, 0);
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = player.transform.rotation + rotateVal;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        
    }
}
