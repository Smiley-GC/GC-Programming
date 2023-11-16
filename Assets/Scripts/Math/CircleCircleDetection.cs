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

    // Homework 7 hint:
    //bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2)
    //{
    //    bool collision = false;
    //    // 1. Calculate distance between position1 and position2
    //    // 2. Calculate sum of radius1 + radius2
    //    // 3. Compare whether the distance is less than the radii sum (if so, there's a collision)!
    //    return collision;
    //}

    // Homework 8: Upgrade our CheckCollisionCircles function to resolve collision between two circles by applying the mtv.
    // Calculate the mtv's direction by determining the direction from 2 to 1 (subtract 1 from 2 then normalize the result)
    // Calculate the mtv's magnitude by determining penetration depth. Subtract radii sum by distance between centres.
    // Only write to the mtv if there's a collision!
    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2, out Vector2 mtv)
    {
        // Shortcut for distance (between positions 1 & 2):
        float distance = Vector2.Distance(position1, position2);

        // Shortcut for direction from 1 to 2 (normalization):
        Vector2 direction = (position1 - position2).normalized;

        bool collision = false;
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
        float radius2 = circle1.transform.localScale.y * 0.5f;
        Vector2 mtv = Vector2.zero;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2, out mtv);
        if (collision)
        {
            circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);
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
