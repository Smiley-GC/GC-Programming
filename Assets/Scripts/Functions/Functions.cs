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
    float speed = 10.0f;

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
        float tt = Time.realtimeSinceStartup;
        transform.position += MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed);
    }
}
