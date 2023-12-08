using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *Programming* homework 10:
// Change the CheckCollisionCircles function to take in two Circle objects.
// Each circle should store a position and a radius.

public class Circle
{
    public Vector2 position;
    public float radius;
}

public class Rectangle
{
    public Vector2 position;
    public Vector2 extents;
}

public class Detection : MonoBehaviour
{
    public GameObject recGO;
    public GameObject circle1GO;
    public GameObject circle2GO;

    Rectangle rec = new Rectangle();
    Circle circle1 = new Circle();
    Circle circle2 = new Circle();

    void Update()
    {
        rec.position = recGO.transform.position;
        rec.extents = new Vector2(recGO.transform.localScale.x * 0.5f, recGO.transform.localScale.y * 0.5f);
        circle1.position = circle1GO.transform.position;
        circle2.position = circle2GO.transform.position;
        circle1.radius = circle1GO.transform.localScale.x * 0.5f;
        circle2.radius = circle2GO.transform.localScale.x * 0.5f;

        Color color = CheckCollisionCircleRec(circle1, rec) ?
            Color.green : Color.red;
        circle1GO.GetComponent<SpriteRenderer>().color = color;
        recGO.GetComponent<SpriteRenderer>().color = color;

        //Color color = CheckCollisionCircles(circle1, circle2) ?
        //    Color.green : Color.red;
        //circle1GO.GetComponent<SpriteRenderer>().color = color;
        //circle2GO.GetComponent<SpriteRenderer>().color = color;
    }

    // Homework 10 pdated function should look like this:
    // bool CheckCollisionCircles(Circle circle1, Circle circle2) { ... }
    // (Follow the same pattern that I did to CheckCollisionCircleRec).

    bool CheckCollisionCircleRec(Circle circle, Rectangle rec)
    {
        Vector2 nearest = circle.position;
        nearest.x = Mathf.Clamp(nearest.x, rec.position.x - rec.extents.x, rec.position.x + rec.extents.x);
        nearest.y = Mathf.Clamp(nearest.y, rec.position.y - rec.extents.y, rec.position.y + rec.extents.y);
        return Vector2.Distance(nearest, circle.position) <= circle.radius;
    }

    //bool CheckCollisionCircles(Vector2 circle1, float radius1, Vector2 circle2, float radius2)
    //{
    //    // 1. Calculate distance between position1 and position2
    //    float distance = Vector2.Distance(circle1, circle2);
    //
    //    // 2. Calculate sum of radius1 + radius2
    //    float radiiSum = radius1 + radius2;
    //
    //    // 3. Compare whether the distance is less than the radii sum (if so, there's a collision)!
    //    return distance < radiiSum;
    //}

    //bool CheckCollisionCircleRec(Vector2 circle, float radius, Vector2 rec, Vector2 extents)
    //{
    //    // 1. Determine rectangle minimums and maximums
    //    float xMin = rec.x - extents.x;
    //    float xMax = rec.x + extents.x;
    //    float yMin = rec.y - extents.y;
    //    float yMax = rec.y + extents.y;
    //
    //    // 2. Determine edge of rectangle nearest to circle
    //    Vector2 nearest = circle;
    //    if (circle.x < xMin) nearest.x = xMin;
    //    else if (circle.x > xMax) nearest.x = xMax;
    //    if (circle.y < yMin) nearest.y = yMin;
    //    else if (circle.y > yMax) nearest.y = yMax;
    //
    //    // 3. Test if distance from circle to nearest edge is less than the circle's radius (collision if so)!
    //    return Vector2.Distance(nearest, circle) <= radius;
    //}

    // Condensed version of above equivalent
    //bool CheckCollisionCircles(Vector2 circle1, float radius1, Vector2 circle2, float radius2)
    //{
    //    return Vector2.Distance(circle1, circle2) <= radius1 + radius2;
    //}

    // Condensed version of above equivalent
    //bool CheckCollisionCircleRec(Vector2 circle, float radius, Vector2 rec, Vector2 extents)
    //{
    //    Vector2 nearest = circle;
    //    nearest.x = Mathf.Clamp(nearest.x, rec.x - extents.x, rec.x + extents.x);
    //    nearest.y = Mathf.Clamp(nearest.y, rec.y - extents.y, rec.y + extents.y);
    //    return Vector2.Distance(nearest, circle) <= radius;
    //}
}
