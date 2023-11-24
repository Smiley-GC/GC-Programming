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

    // Homework 7: write a function to determine if two circles are overlapping
    // Recommendation: keep your functions pure math -- take in 2 positions and 2 radii as arguments
    // return the result of the collision as a boolean
    // Homework 7 hint:
    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2)
    {
        return Vector2.Distance(position1, position2) < radius1 + radius2;
    }

    // Homework 8: Upgrade the previous function so that it calculates the MTV ("minimum translation vector").
    // If the two circles are overlapping, apply the mtv to circle 1 to resolve the collision!
    // Remember, mtv resolves 1 FROM 2
    //bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2,
    //    out Vector2 mtv)
    //{
    //    // Distance between position1 and position2
    //    float distance = Vector2.Distance(position1, position2);
    //
    //    // Unit vector pointing FROM 2 TO 1
    //    Vector2 direction = (position1 - position2).normalized;
    //
    //    bool collision = false; // fix this to be a comparison between distance and radii sum
    //    if (collision)
    //    {
    //        // Change this to be direction * depth
    //        mtv = Vector2.zero;
    //    }
    //    else
    //    {
    //        mtv = Vector2.zero;
    //    }
    //    return collision;
    //}

    void Update()
    {
        //Vector2 mtv = Vector2.zero;
        Vector2 position1 = circle1.transform.position;
        Vector2 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2);
        if (collision)
        {
            circle1.GetComponent<SpriteRenderer>().color = Color.green;
            circle2.GetComponent<SpriteRenderer>().color = Color.green;
            //circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);
        }
        else
        {
            circle1.GetComponent<SpriteRenderer>().color = Color.red;
            circle2.GetComponent<SpriteRenderer>().color = Color.red;
        }
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
