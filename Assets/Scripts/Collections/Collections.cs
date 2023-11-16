using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    public int[] manualArray = new int[20];
    int[] automaticArray = { 1, 2, 3, 4 };
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Automatic array length: " + automaticArray.Length);
        // Change single value:
        automaticArray[0] = 42;
        Debug.Log(automaticArray[0]);

        // Change multiple values:
        for (int i = 0; i < automaticArray.Length; i++)
        {
            automaticArray[i] = 69420;
            Debug.Log(automaticArray[i]);
        }

        // Change all values to count upwards
        for (int i = 0; i < automaticArray.Length; i++)
        {
            automaticArray[i] = i + 1;
            Debug.Log(automaticArray[i]);
        }

        // Change all values to count downwards
        for (int i = 0; i < automaticArray.Length; i++)
        {
            automaticArray[i] = automaticArray.Length - i;
            Debug.Log(automaticArray[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index < automaticArray.Length)
        {
            Debug.Log("Value at index[" + index + "]: " + automaticArray[index]);
            index++;
        }
    }
}
