using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    void Start()
    {
        //TestWhileLoop();
        TestForLoop();
    }

    void TestWhileLoop()
    {
        int counter = 1;
        while (counter <= 5)
        {
            Debug.Log("Looping x" + counter);
            counter++;
        }
        Debug.Log("No longer looping");
    }
    
    void TestForLoop()
    {
        for (int counter = 1; counter <= 5; counter++)
        {
            Debug.Log("Looping x" + counter);
        }
        Debug.Log("No longer looping");
    }
}
