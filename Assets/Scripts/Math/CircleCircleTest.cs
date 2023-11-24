using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleTest : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    private void Start()
    {
        //VectorReview();
    }

    // Homework 8: Upgrade the previous function so that it calculates the MTV ("minimum translation vector").
    // If the two circles are overlapping, apply the mtv to circle 1 to resolve the collision!
    // Remember, mtv resolves 1 FROM 2
    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2, out Vector2 mtv)
    {
        // Distance between position1 and position2
        float distance = Vector2.Distance(position1, position2);

        // Unit vector pointing FROM 2 TO 1
        // (AB = B - A. Its up to you which is A and which is B)
        Vector2 direction = (position1 - position2).normalized;

        float radiiSum = radius1 + radius2;
        bool collision = distance < radiiSum;
        if (collision)
        {
            // mtv = direction * depth
            // depth = radiiSum - distance
            // We already have direction
            mtv = Vector2.zero; // (replace with actual mtv formula)
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

        // MTV resolves 1 from 2 (because it points from 2 to 1)
        Vector2 mtv = Vector2.zero;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2, out mtv);
        circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);

        Color color = collision ? Color.green : Color.red;
        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;

        // "ternary" operator (the question mark) assigned based on a true/false value.
        // It assigns to the left of the : if true, otherwise it assigns to the right of the : if false.
        // Its equivalent to the following code:
        //if (collision)
        //{
        //    color = Color.green;
        //}
        //else
        //{
        //    color = Color.red;
        //}
    }

    void VectorReview()
    {
        Vector2 A = new Vector2(2.0f, 3.0f);
        Vector2 B = new Vector2(5.0f, 4.0f);
        Vector2 direction = (B - A).normalized;
        float distance1 = Vector2.Distance(A, B);
        float distance2 = (B - A).magnitude;

        // Two ways to get distance of a line segment:
        // 1. Use Vector2.Distance on the start & end of line.
        // 2. Turn the line into a vector by subtracting the two points, then calculate its magnitude.
        Debug.Log(distance1);
        Debug.Log(distance2);
        Debug.Log(direction);
    }
}
