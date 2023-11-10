using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleTest : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    // Homework: write a function to determine if two circles are overlapping
    // Recommendation: keep your functions pure math -- take in 2 positions and 2 radii as arguments
    // return the result of the collision as a boolean
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
