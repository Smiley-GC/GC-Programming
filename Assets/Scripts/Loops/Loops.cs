using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Homework task 2: use loops to spawn grenades in a border pattern (see blackboard task 2 image, 1%)
    public GameObject grenade;
    public GameObject borderCircle;
    public Vector3 spawnPosition;

    void Start()
    {
        //TestWhileLoop();
        //TestForLoop();
        //SpawnGrenades(420);
        DrawBorder();
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

    void DrawBorder()
    {
        float left = -10.0f;
        float right = 10.0f;
        float top = 5.0f;
        float bottom = -5.0f;
        int width = (int)Camera.main.orthographicSize * 4;
        int height = (int)Camera.main.orthographicSize * 2;

        // Top row:
        {
            float x = left;
            for (int i = 0; i <= width; i++)
            {
                Instantiate(borderCircle, new Vector3(x, top, 0.0f), Quaternion.identity);
                x += 1.0f;
            }
        }

        // Bottom row:
        {
            float x = left;
            for (int i = 0; i <= width; i++)
            {
                Instantiate(borderCircle, new Vector3(x, bottom, 0.0f), Quaternion.identity);
                x += 1.0f;
            }
        }

        // Left column:
        {
            float y = bottom;
            for (int i = 0; i <= height; i++)
            {
                Instantiate(borderCircle, new Vector3(left, y, 0.0f), Quaternion.identity);
                y += 1.0f;
            }
        }

        // Right column:
        {
            float y = bottom;
            for (int i = 0; i <= height; i++)
            {
                Instantiate(borderCircle, new Vector3(right, y, 0.0f), Quaternion.identity);
                y += 1.0f;
            }
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
