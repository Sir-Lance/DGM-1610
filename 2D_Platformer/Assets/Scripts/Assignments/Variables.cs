using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    string firstName = "Lance";
    int age = 21;
    float height = 6.1f;
    bool married = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("First Name: " + firstName);
        Debug.Log("Age: " + age);
        Debug.Log("Height: " + height);
        Debug.Log("Married? " + married);

    }
}
//HOMEWORK
//Variables for Superhero, Villain, Cartoon Character, Free