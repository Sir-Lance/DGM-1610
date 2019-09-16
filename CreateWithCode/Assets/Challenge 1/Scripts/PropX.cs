using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropX : MonoBehaviour
{
    public GameObject Propeller;
    private float propSpin = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * propSpin);
    }
}
