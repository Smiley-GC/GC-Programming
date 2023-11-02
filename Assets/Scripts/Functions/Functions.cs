using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework:
// Part 1 -- create 4 functions (1/2 marks).
// Make a function called Add that adds two floats
// Make a function called Sub that subtracts two floats
// Make a function called Mul that multiplies two floats
// Make a function called Div that divides two floats

// Part 2 -- create a function of your choice. Marks will be allocated based on how awesome it is.
// For example, a function that logs to the console is really lame and ultimately worth 0 marks.
// A function that spawns and/or moves objects is considered "awesome" and will give full marks.
public class Functions : MonoBehaviour
{
    public GameObject prefab;
    Rigidbody rb;
    float speed = 10.0f;

    void MovePlayer(float speed, float dt)
    {
        transform.position += Vector3.forward * speed * dt;
    }

    Vector3 MoveObject(Vector3 direction, float speed, float dt)
    {
        return direction * speed * dt;
    }

    void ThrowGrenade(Vector3 position, Vector3 velocity)
    {
        GameObject grenade = Instantiate(prefab, position, Quaternion.identity);
        grenade.GetComponent<Rigidbody>().velocity = velocity;
        Destroy(grenade, 10.0f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Uncomment for custom circle physics!
        //float tt = Time.realtimeSinceStartup;
        //float dt = Time.deltaTime;
        //MovePlayer(10.0f, dt);
        //Vector3 positionDelta = MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed, dt);
        //transform.position += positionDelta;
        rb.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * -speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -speed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f) * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 forward = transform.forward;
            Vector3 up = transform.up;
            Vector3 direction = (up + forward).normalized;
            // TODO -- add collision matrix to prevent us from colliding with our own grenades!
            ThrowGrenade(transform.position + direction * 5.0f, direction * 10.0f);
        }
    }
}
