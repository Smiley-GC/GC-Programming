using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *Programming* homework 10:
// Change the CheckCollisionCircles function to take in two Circle objects.
// Each circle should store a position and a radius.

//public class Circle
//{
///* insert data here*/
//}

public class CircleCircleDetection : MonoBehaviour
{
    public GameObject recGO;
    public GameObject circle1GO;
    public GameObject circle2GO;

    void Update()
    {
        Vector3 rec = recGO.transform.position;
        Vector2 extents = new Vector2(recGO.transform.localScale.x * 0.5f, recGO.transform.localScale.y * 0.5f);
        Vector3 circle1 = circle1GO.transform.position;
        Vector3 circle2 = circle2GO.transform.position;
        float radius1 = circle1GO.transform.localScale.x * 0.5f;
        float radius2 = circle2GO.transform.localScale.x * 0.5f;

        Color color = CheckCollisionCircleRec(circle1, radius1, rec, extents) ?
            Color.green : Color.red;
        circle1GO.GetComponent<SpriteRenderer>().color = color;
        recGO.GetComponent<SpriteRenderer>().color = color;

        //Color color = CheckCollisionCircles(position1, radius1, position2, radius2) ?
        //    Color.green : Color.red;
        //circle1.GetComponent<SpriteRenderer>().color = color;
        //circle2.GetComponent<SpriteRenderer>().color = color;
    }

    // Updated function should look like this:
    // bool CheckCollisionCircles(Circle circle1, Circle circle2) { ... }
    bool CheckCollisionCircles(Vector2 circle1, float radius1, Vector2 circle2, float radius2)
    {
        // 1. Calculate distance between position1 and position2
        float distance = Vector2.Distance(circle1, circle2);

        // 2. Calculate sum of radius1 + radius2
        float radiiSum = radius1 + radius2;

        // 3. Compare whether the distance is less than the radii sum (if so, there's a collision)!
        return distance < radiiSum;
    }

    bool CheckCollisionCircleRec(Vector2 circle, float radius, Vector2 rec, Vector2 extents)
    {
        float xMin = rec.x - extents.x;
        float xMax = rec.x + extents.x;
        float yMin = rec.y - extents.y;
        float yMax = rec.y + extents.y;

        Vector2 nearest = circle;
        if (circle.x < xMin) nearest.x = xMin;
        else if (circle.x > xMax) nearest.x = xMax;
        if (circle.y < yMin) nearest.y = yMin;
        else if (circle.y > yMax) nearest.y = yMax;

        return Vector2.Distance(nearest, circle) <= radius;
    }
}
