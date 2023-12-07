using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRectangleProjection : MonoBehaviour
{
    GameObject[] vertices = new GameObject[4];
    GameObject nearest;

    public GameObject pointPrefab;
    public GameObject rectangle;
    public GameObject circle;

    void Start()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = Instantiate(pointPrefab);
            vertices[i].GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        nearest = Instantiate(pointPrefab);
        nearest.GetComponent<SpriteRenderer>().color = Color.cyan;
    }

    void Update()
    {
        rectangle.transform.rotation *= Quaternion.Euler(0.0f, 0.0f, 100.0f * Time.deltaTime);
        circle.transform.position = new Vector3(Mathf.Cos(Time.realtimeSinceStartup) * 1.5f, Mathf.Sin(Time.realtimeSinceStartup) * 1.5f, 0.0f);

        Vector3 circlePosition = circle.transform.position;
        float radius = circle.transform.localScale.x * 0.5f;

        Vector3 rectPosition = rectangle.transform.position;
        Vector2 extents = new Vector2(rectangle.transform.localScale.x, rectangle.transform.localScale.y) * 0.5f;

        Vector2 forward = rectangle.transform.right;
        Vector2 perpendicular = rectangle.transform.up;

        Color color = CheckCollisionCircleRect(circlePosition, radius, rectPosition, extents,
            forward, perpendicular) ? Color.green : Color.red;

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

    // Project circle onto all 4 rectangle axes then do a point-circle check against the nearest projection!
    bool CheckCollisionCircleRect(Vector2 circle, float radius, Vector2 rect, Vector2 extents, Vector2 forward, Vector2 perpendicular)
    {
        float hw = extents.x;   // half-width
        float hh = extents.y;   // half-height
        Vector2 a = forward * hw;
        Vector2 b = perpendicular * hh;

        List<Vector2> points = new List<Vector2>
        {
            rect + a + b,   // top left
            rect + a - b,   // top right
            rect - a - b,   // bottom right
            rect - a + b    // bottom left
        };

        float min = float.MaxValue;
        Vector2 minProj = new Vector2(min, min);
        for (int i = 0; i < points.Count; i++)
        {
            Vector2 proj = ProjectPointLine(circle, points[i], points[(i + 1) % points.Count]);
            float distance = Vector2.Distance(circle, proj);
            if (distance < min)
            {
                min = distance;
                minProj = proj;
            }
            vertices[i].transform.position = points[i];
        }
        nearest.transform.position = minProj;

        return Vector2.Distance(minProj, circle) <= radius;
    }
}
