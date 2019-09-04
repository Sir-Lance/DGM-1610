using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // string firstName;
    // string lastName;
    // int age;

    int num1;
    int num2;
    int total;



    // Start is called before the first frame update
    void Start()
    {
        // firstName = "Bob";

        // lastName = "Ross";

        // age = 90;

        // Customer(firstName, lastName, age);

        CalcAdd(11, 23);


    }

    int CalcAdd(int n1, int n2)
    {
        Debug.Log("NUmber 1 = " + n1 + "Number 2 = " + n2);
        total = n1 + n2;

        Debug.Log(total);
        return total;

    }
    // void Customer(string fName, string lName, int a)
    // {
    //     Debug.Log(fName + " " + lName + " " + a);

    // }
}

