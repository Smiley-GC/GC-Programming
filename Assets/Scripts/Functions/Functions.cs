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
    // These basic arithmetic functions aren't useful since C# has + - * / built into the language.
    // However, if we need to apply constraints to our functions (ie limiting values to be between 0 & 5) then they are useful!
    float speed = 10.0f;

    float Add(float a, float b)
    {
        a = Mathf.Clamp(a, 0.0f, 5.0f);
        b = Mathf.Clamp(b, 0.0f, 5.0f);
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

    void MovePlayer(float speed)
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    Vector3 MoveObject(Vector3 direction, float speed)
    {
        return direction * speed * Time.deltaTime;
    }

    void Start()
    {
        float x = 10.0f;
        float y = 10.0f;

        Debug.Log(x + y);
        Debug.Log(x - y);
        Debug.Log(x * y);
        Debug.Log(x / y);

        Debug.Log(Add(x, y));
        Debug.Log(Sub(x, y));
        Debug.Log(Mul(x, y));
        Debug.Log(Div(x, y));
    }

    void Update()
    {
        float tt = Time.realtimeSinceStartup;
        transform.position += MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed);
    }
}
