using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0f;
    float rotation = 0.0f;
    float rotationSpeed = 250.0f;
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

        // 1. Update direction based on rotation
        if (Input.GetKey(KeyCode.E))
        {
            rotation -= rotationSpeed * dt;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotation += rotationSpeed * dt;
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        Vector3 forward = transform.right;
        Vector3 right = transform.up;

        // 2. Move along direction
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += forward * speed * dt;
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= forward * speed * dt;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += right * speed * dt;
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position -= right * speed * dt;
        }

        float lineLength = 10.0f;
        Debug.DrawLine(transform.position, transform.position + transform.right * lineLength);
    }
}
