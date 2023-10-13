using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0f;
    public float rotationSpeed = 0.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        //transform.rotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, rotationSpeed * dt);
        // Challenge: Rotate left when Q is down, rotate right when E is down.

        //float xDir = 0.0f;
        //float yDir = 0.0f;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    yDir = 1.0f;
        //}
        //
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    yDir = -1.0f;
        //}
        //
        //if (Input.GetKey(KeyCode.A))
        //{
        //    xDir = -1.0f;
        //}
        //
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    xDir = 1.0f;
        //}
        //
        //rb.velocity = new Vector2(xDir, yDir).normalized * speed;
    }
}
