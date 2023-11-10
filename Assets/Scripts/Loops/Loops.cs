using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework task 1: create a border around your screen by spawning game objects via loop.
// See diagram on blackboard for refernece
public class Loops : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float verticalPosition;

    void Start()
    {
        //TestWhileLoop();
        //TestForLoop();
        SpawnGrenades(256);
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

    void SpawnGrenades(int grenadeCount)
    {
        for (int i = 0; i < grenadeCount; i++)
        {
            for (float j = -5.0f; j <= 5.0f; j += 5.0f)
            {
                float min = -100.0f;
                float max = 100.0f;
                Vector3 grenadePosition = new Vector3(Random.Range(min, max), verticalPosition + Random.Range(-10.0f, 10.0f) + j, Random.Range(min, max));
                GameObject grenade = Instantiate(grenadePrefab, grenadePosition, Quaternion.identity);
                Destroy(grenade, 5.0f);
            }
        }
    }
}
