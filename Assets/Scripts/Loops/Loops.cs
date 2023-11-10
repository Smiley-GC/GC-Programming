using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    void Start()
    {
        int counter = 1;
        while (counter <= 5)
        {
            Debug.Log("Looping x" + counter);
            counter++;
        }
        Debug.Log("No longer looping");
    }
}
