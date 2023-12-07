using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRectangleProjection : MonoBehaviour
{
    public GameObject rectangle;
    public GameObject circle;

    void Update()
    {
        Vector3 circlePosition = circle.transform.position;
        Vector3 rectPosition = rectangle.transform.position;
        Vector3 rectDirection = rectangle.transform.right;
        float radius = circle.transform.localScale.x * 0.5f;
        Vector2 extents = new Vector2(rectangle.transform.localScale.x, rectangle.transform.localScale.y) * 0.5f;
        Vector2 right = rectangle.transform.right;
        Vector2 up = rectangle.transform.up;

        Color color = CheckCollisionCircleRect(circlePosition, radius, rectPosition, extents,
            right, up) ? Color.green : Color.red;
        circle.GetComponent<SpriteRenderer>().color = color;
        rectangle.GetComponent<SpriteRenderer>().color = color;
    }

    // Project point P onto line AB
    Vector2 ProjectPointLine(Vector2 P, Vector2 A, Vector2 B)
    {
        Vector2 AB = B - A;
        Vector2 AP = P - A;
        float t = Vector2.Dot(AB, AP) / Vector2.Dot(AB, AB);
        t = Mathf.Clamp01(t);
        return A + AB * t;
    }

    bool CheckCollisionCircleRect(Vector2 circle, float radius, Vector2 rect, Vector2 extents, Vector2 forward, Vector2 up)
    {
        //List<Vector2> axes = new List<Vector2>();
        float hw = extents.x;   // half-width
        float hh = extents.y;   // half-height

        Vector2 a = rect + up * hh;
        Vector2 b = rect - up * hh;
        Vector2 c = rect + forward * hw;
        Vector2 d = rect - forward * hw;

        Vector2 topLeft = a + c;
        Vector2 topRight = b + c;
        Vector2 botRight = b + d;
        Vector2 botLeft = a + d;
        List<Vector2> axes = new List<Vector2>
        {
            topLeft,
            topRight,
            botRight,
            botLeft
        };

        //axes.Add(topRight - topLeft);
        //axes.Add(botRight - topRight);
        //axes.Add(botLeft - botRight);
        //axes.Add(topLeft - botLeft);

        float min = 999999999.0f;
        Vector2 minProj = new Vector2(min, min);
        for (int i = 0; i < axes.Count; i++)
        {
            Vector2 proj = ProjectPointLine(circle, axes[i], axes[(i + 1) % axes.Count]);
            float distance = Vector2.Distance(circle, proj);
            if (distance < min)
            {
                min = distance;
                minProj = proj;
            }
        }

        return Vector2.Distance(minProj, circle) <= radius;
    }
}
