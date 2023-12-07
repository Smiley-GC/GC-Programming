using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *Programming* homework 10:
// Change the CheckCollisionCircles function to take in two Circle objects.
// Each circle should store a position and a radius.

public class Detection : MonoBehaviour
{
    public GameObject rect1;
    public GameObject circle1;
    public GameObject circle2;

    void Update()
    {
        Vector3 rectPosition = rect1.transform.position;
        Vector3 position1 = circle1.transform.position;
        Vector3 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;
        Vector2 rectExtents = new Vector2(rect1.transform.localScale.x, rect1.transform.localScale.y) * 0.5f;

        //Color color = CheckCollisionCircles(position1, radius1, position2, radius2) ? Color.green : Color.red;
        //circle1.GetComponent<SpriteRenderer>().color = color;
        //circle2.GetComponent<SpriteRenderer>().color = color;

        Color color = CheckCollisionCircleRect(position1, radius1, rectPosition, rectExtents) ? Color.green : Color.red;
        circle1.GetComponent<SpriteRenderer>().color = color;
        rect1.GetComponent<SpriteRenderer>().color = color;
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

    // "Extents" is the half-width and half-height of our rectangle.
    bool CheckCollisionCircleRect(Vector2 circle, float radius, Vector2 rect, Vector2 extents)
    {
        float xMin = rect.x - extents.x;
        float xMax = rect.x + extents.x;
        float yMin = rect.y - extents.y;
        float yMax = rect.y + extents.y;

        Vector2 test = circle;
        if (test.x <= xMin) test.x = xMin;
        else if (test.x >= xMax) test.x = xMax;
        if (test.y <= yMin) test.y = yMin;
        else if (test.y >= yMax) test.y = yMax;

        return Vector2.Distance(test, circle) <= radius;
    }
}
