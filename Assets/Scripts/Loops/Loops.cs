using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework task 1: create a border around your screen by spawning game objects via loop.
// See diagram on blackboard for refernece
public class Loops : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject borderCircle;
    public float verticalPosition;
    int grenadeCount = 256;

    void Start()
    {
        //TestWhileLoop();
        //TestForLoop();
        //SpawnGrenades(grenadeCount);
        Homework7();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SpawnGrenades(grenadeCount);
        }
    }

    void TestWhileLoop()
    {
        int counter = 1;
        while (counter <= 5)
        {
            Debug.Log("Looping x" + counter);
            counter += 2;
        }
        Debug.Log("No longer looping");
    }
    
    void TestForLoop()
    {
        for (int counter = 1; counter <= 10; counter +=3)
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

    void Homework7()
    {
        float size = Camera.main.orthographicSize;
        float right = size * 2.0f;
        float left = -size * 2.0f;
        float top =  size;
        float bot = -size;

        // Top
        for (float x = left; x <= right; x += 1.0f)
            Instantiate(borderCircle, new Vector3(x, top, 0.0f), Quaternion.identity);

        // Bottom
        for (float x = left; x <= right; x += 1.0f)
            Instantiate(borderCircle, new Vector3(x, bot, 0.0f), Quaternion.identity);

        // Left
        for (float y = bot; y <= top; y += 1.0f)
            Instantiate(borderCircle, new Vector3(left, y, 0.0f), Quaternion.identity);

        // Right
        for (float y = bot; y <= top; y += 1.0f)
            Instantiate(borderCircle, new Vector3(right, y, 0.0f), Quaternion.identity);
    }
}
