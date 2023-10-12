using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0f;
    float rotation = 0.0f;
    float rotationSpeed = 100.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Normalization test (matches math diagram)
        Vector2 test = new Vector2(3, 5);
        Vector2 nTest = test.normalized;
        Debug.Log(nTest);
        Debug.Log(nTest.magnitude);
    }

    // Challenge: Rotate the player with E and Q, then move the player in that direction!
    void Update()
    {
        float dt = Time.deltaTime;
        float xDir = 0.0f;
        float yDir = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            yDir = 1.0f;
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            yDir = -1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            xDir = 1.0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotation -= rotationSpeed * dt;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotation += rotationSpeed * dt;
        }

        Vector2 direction = new Vector2(xDir, yDir).normalized;
        rb.velocity = direction * speed;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
    }
}
