using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    void Start()
    {
        while (true)
        {
            Debug.Log("Looping");
            break;
        }
        Debug.Log("No longer looping");
    }
}
