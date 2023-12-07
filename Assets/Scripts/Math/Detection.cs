using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Circle
{
    public Vector2 position;
    public float radius;
}

struct Rectangle
{
    public Vector2 position;
    public Vector2 extents;
}

// Extra practice: add the mtv to CheckCollisionCircleRect.
// Calculate the mtv by forming a line FROM the rectangle TO the circle,
// then multiply it by the collision depth which is radius - distance (same as circle-circle mtv).
public class Detection : MonoBehaviour
{
    public GameObject rect1GO;
    public GameObject circle1GO;
    public GameObject circle2GO;

    Rectangle rect1 = new Rectangle();
    Circle circle1 = new Circle();

    void Update()
    {
        //Vector3 rectPosition = rect1GO.transform.position;
        //Vector3 position1 = circle1GO.transform.position;
        //Vector3 position2 = circle2GO.transform.position;
        //float radius1 = circle1GO.transform.localScale.x * 0.5f;
        //float radius2 = circle2GO.transform.localScale.x * 0.5f;
        //Vector2 rectExtents = new Vector2(rect1GO.transform.localScale.x, rect1GO.transform.localScale.y) * 0.5f;

        circle1.position = circle1GO.transform.position;
        circle1.radius = circle1GO.transform.localScale.x * 0.5f;
        rect1.position = rect1GO.transform.position;
        rect1.extents = new Vector2(rect1GO.transform.localScale.x, rect1GO.transform.localScale.y) * 0.5f;

        //Color color = CheckCollisionCircles(position1, radius1, position2, radius2) ? Color.green : Color.red;
        //circle1.GetComponent<SpriteRenderer>().color = color;
        //circle2.GetComponent<SpriteRenderer>().color = color;

        //Color color = CheckCollisionCircleRect(position1, radius1, rectPosition, rectExtents) ? Color.green : Color.red;
        Color color = CheckCollisionCircleRect(circle1, rect1) ? Color.green : Color.red;
        circle1GO.GetComponent<SpriteRenderer>().color = color;
        rect1GO.GetComponent<SpriteRenderer>().color = color;
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

    bool CheckCollisionCircleRect(Circle circle, Rectangle rectangle)
    {
        // If its annoying to type things out in full like rectangle.position and rectangle.extents,
        // you can make a short-hand variable that refers to said attributes!
        // ***IF SHORT-HAND VARIABLES ARE STRUCTS, THEY WILL BE COPIED!!!***
        Vector2 rp = rectangle.position;
        Vector2 re = rectangle.extents;
        float xMin = rp.x - re.x;
        float xMax = rp.x + re.x;
        float yMin = rp.y - re.y;
        float yMax = rp.y + re.y;

        Vector2 test = circle.position;
        if (test.x <= xMin) test.x = xMin;
        else if (test.x >= xMax) test.x = xMax;
        if (test.y <= yMin) test.y = yMin;
        else if (test.y >= yMax) test.y = yMax;

        return Vector2.Distance(test, circle.position) <= circle.radius;
    }
}
