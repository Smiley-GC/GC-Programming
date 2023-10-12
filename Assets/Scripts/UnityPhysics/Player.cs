using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework - modify the code so that:
// Rotation speed doubles when it enters the SpeedRectangle.
// Rotation speed should halve when you enter the SlowCircle.
// Rotation speed should reset to its initial value after exiting either shape.
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

        // Must convert to vec2 if you'd like to apply these to Rigidbody2D
        //Vector2 forward = transform.right;
        //Vector2 right = transform.up;

        // 2. Move along direction
        //rb.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            //rb.velocity += forward * speed;
            transform.position += forward * speed * dt;
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            //rb.velocity -= forward * speed;
            transform.position -= forward * speed * dt;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            //rb.velocity += right * speed;
            transform.position += right * speed * dt;
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            //rb.velocity -= right * speed;
            transform.position -= right * speed * dt;
        }

        float lineLength = 10.0f;
        Debug.DrawLine(transform.position, transform.position + transform.right * lineLength);
    }
}
