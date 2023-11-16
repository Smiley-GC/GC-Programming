using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Homework task 2: use loops to spawn grenades in a border pattern (see blackboard task 2 image, 1%)
    public GameObject grenade;
    public Vector3 spawnPosition;
    void Start()
    {
        TestWhileLoop();
        TestForLoop();
        SpawnGrenades(420);
    }

    void TestWhileLoop()
    {
        int counter = 0;
        while (counter <= 10)
        {
            Debug.Log("Looping x" + counter);
            counter += 2;
        }
        Debug.Log("No longer looping");
    }

    void TestForLoop()
    {
        for (int counter = 5; counter > 0; counter--)
        {
            Debug.Log("Looping x" + counter);
        }
        Debug.Log("No longer looping");
    }

    void SpawnGrenades(int grenadeCount)
    {
        // Homework 7 recommendations:
        // 1. Write 4 for-loops -- 1 for each strip of the screen
        // 2. (Alternatively), write one for loop, and test if the grenades are too far inwards
        // perhaps use a collision volume (ie OnTriggerEnter), or just simple if-statements!
        for (int i = 0; i < grenadeCount; i++)
        {
            float xMin, xMax, zMin, zMax;
            xMin = zMin = -100.0f;
            xMax = zMax = 100.0f;

            Vector3 grenadePosition = spawnPosition + new Vector3(Random.Range(xMin, xMax), 0.0f, Random.Range(zMin, zMax));
            GameObject clone = Instantiate(grenade, grenadePosition, Quaternion.identity);
            Destroy(clone, 5.0f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnGrenades(100);
        }
    }
}
