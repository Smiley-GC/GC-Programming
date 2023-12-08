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

        // 1. Determine all overlapping pairs
        bool circle1Rec = CheckCollisionCircleRec(circle1, rec);
        bool circle2Rec = CheckCollisionCircleRec(circle2, rec);
        bool circle1circle2 = CheckCollisionCircles(circle1.position, circle1.radius, circle2.position, circle2.radius);

        // 2. Colour based on overlap
        Color recColor = Color.red;
        Color circle1Color = Color.red;
        Color circle2Color = Color.red;

        if (circle1Rec)
        {
            recColor = Color.green;
            circle1Color = Color.green;
        }

        if (circle2Rec)
        {
            recColor = Color.green;
            circle2Color = Color.green;
        }

        if (circle1circle2)
        {
            circle1Color = Color.green;
            circle2Color = Color.green;
        }

        // 3. Shader with colors
        recGO.GetComponent<SpriteRenderer>().color = recColor;
        circle1GO.GetComponent<SpriteRenderer>().color = circle1Color;
        circle2GO.GetComponent<SpriteRenderer>().color = circle2Color;
    }

    // Homework 10 CheckCollisionCircles should look like this:
    // bool CheckCollisionCircles(Circle circle1, Circle circle2) { ... }
    // (Follow the same pattern that I did to CheckCollisionCircleRec).

    bool CheckCollisionCircleRec(Circle circle, Rectangle rec)
    {
        Vector2 nearest = circle.position;
        nearest.x = Mathf.Clamp(nearest.x, rec.position.x - rec.extents.x, rec.position.x + rec.extents.x);
        nearest.y = Mathf.Clamp(nearest.y, rec.position.y - rec.extents.y, rec.position.y + rec.extents.y);
        return Vector2.Distance(nearest, circle.position) <= circle.radius;
    }

    bool CheckCollisionCircles(Vector2 circle1, float radius1, Vector2 circle2, float radius2)
    {
        return Vector2.Distance(circle1, circle2) <= radius1 + radius2;
    }
}
