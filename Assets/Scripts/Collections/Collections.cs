using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    public int[] manualArray = new int[20];
    public int[] automaticArray = { 1, 2, 3, 4, 5 };

    // Start is called before the first frame update
    void Start()
    {
        // "Out of bounds" -- be sure you only access elements that exist!
        //Debug.Log("Value at index 5: " + automaticArray[5]);

        // Manual access
        Debug.Log("Value at index 0: " + automaticArray[0]);
        Debug.Log("Value at index 1: " + automaticArray[1]);
        Debug.Log("Value at index 2: " + automaticArray[2]);
        Debug.Log("Value at index 3: " + automaticArray[3]);
        Debug.Log("Value at index 4: " + automaticArray[4]);

        // Automatic access
        for (int i = 0;  i < automaticArray.Length; i++)
            Debug.Log(automaticArray[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
