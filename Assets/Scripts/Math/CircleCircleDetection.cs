using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleDetection : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    // Homework: create a function to detect if the two circles are overlapping
    // Recommendation: the function should take in two positions, and two radiuses
    // The function should check if the distance between centres is less than or
    // equal to the sum of the radii. If so, colour the circles green, otherwise red.

    void Update()
    {
        bool collision = false;
        if (collision)
        {
            circle1.GetComponent<SpriteRenderer>().color = Color.green;
            circle2.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            circle1.GetComponent<SpriteRenderer>().color = Color.red;
            circle2.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
