using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleDetection : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    // Homework 8: Upgrade our CheckCollisionCircles function to resolve collision between two circles by applying the mtv.
    // Calculate the mtv's direction by determining the direction from 2 to 1 (subtract 1 from 2 then normalize the result)
    // Calculate the mtv's magnitude by determining penetration depth. Subtract radii sum by distance between centres.
    // Only write to the mtv if there's a collision!
    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2, out Vector2 mtv)
    {
        // Distance between position 1 and position 2
        float distance = Vector2.Distance(position1, position2);

        // Direction from to position 2 to position 1
        Vector2 direction = (position1 - position2).normalized;

        // Sum of radii
        float radiiSum = radius1 + radius2;

        // Collision if distance between circles is less than the sum of their radii!
        bool collision = distance < radiiSum;
        if (collision)
        {
            // Calculate mtv only if there's a collision
            mtv = Vector2.zero; // replace this with actual calculations
        }
        else
        {
            mtv = Vector2.zero;
        }
        return collision;
    }

    void Update()
    {
        Vector2 position1 = circle1.transform.position;
        Vector2 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;

        // MTV resolves 1 from 2
        Vector2 mtv = Vector2.zero;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2, out mtv);
        circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);
        Color color = collision ? Color.green : Color.red;

        // Vector2.Distance automatically calculates the distance between two points
        // Alternatively, if we have a vector then we can access its magnitude (length) directly!
        Vector2 lineSegment = position2 - position1;
        float lineLength1 = lineSegment.magnitude;
        float lineLength2 = Vector2.Distance(position1, position2);
        Debug.Log(lineLength1);
        Debug.Log(lineLength2);
        Debug.DrawLine(position1, position2);

        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;

        // The above color code uses what's called the ternary operator (the question mark).
        // Its equivalent to assigning a value based on an if-else statement like so:
        //Color color = Color.white;
        //if (collision)
        //{
        //    color = Color.green;
        //}
        //else
        //{
        //    color = Color.red;
        //}
    }

    // Homework 7 solution
    /*
    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2)
    {
        // 1. Calculate distance between position1 and position2
        float distance = Vector2.Distance(position1, position2);

        // 2. Calculate sum of radius1 + radius2
        float radiiSum = radius1 + radius2;

        // 3. Compare whether the distance is less than the radii sum (if so, there's a collision)!
        return distance < radiiSum;
    }
    */
}
