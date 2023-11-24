using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework:
// Make a function called Add that adds two floats
// Make a function called Sub that subtracts two floats
// Make a function called Mul that multiplies two floats
// Make a function called Div that divides two floats

public class Functions : MonoBehaviour
{
    float movementSpeed = 10.0f;

    float Add(float a, float b)
    {
        return a + b;
    }

    float Sub(float a, float b)
    {
        return a - b;
    }

    float Mul(float a, float b)
    {
        return a * b;
    }

    float Div(float a, float b)
    {
        return a / b;
    }

    void Start()
    {
        float x = 2.0f;
        float y = 3.0f;

        Debug.Log(x + y);
        Debug.Log(x - y);
        Debug.Log(x * y);
        Debug.Log(x / y);

        Debug.Log(Add(x, y));
        Debug.Log(Sub(x, y));
        Debug.Log(Mul(x, y));
        Debug.Log(Div(x, y));
    }

    void MovePlayer(float speed)
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    Vector3 MoveObject(Vector3 direction, float speed)
    {
        return direction * speed * Time.deltaTime;
    }

    void Update()
    {
        transform.position += MoveObject(transform.forward, movementSpeed);
        //float tt = Time.realtimeSinceStartup;
        //transform.position += MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed);
    }
}
