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
