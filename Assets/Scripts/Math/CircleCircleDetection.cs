using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *Programming* homework 10:
// Change the CheckCollisionCircles function to take in two Circle objects.
// Each circle should store a position and a radius.

public class CircleCircleDetection : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    void Update()
    {
        Vector3 position1 = circle1.transform.position;
        Vector3 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;

        Color color = CheckCollisionCircles(position1, radius1, position2, radius2) ?
            Color.green : Color.red;

        // The above is a shortcut for the following:
        //if (CheckCollisionCircles(position1, radius1, position2, radius2))
        //    color = Color.green;
        //else
        //    color = Color.red;

        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;
    }

    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2)
    {
        // 1. Calculate distance between position1 and position2
        float distance = Vector2.Distance(position1, position2);

        // 2. Calculate sum of radius1 + radius2
        float radiiSum = radius1 + radius2;

        // 3. Compare whether the distance is less than the radii sum (if so, there's a collision)!
        return distance < radiiSum;
    }
}
