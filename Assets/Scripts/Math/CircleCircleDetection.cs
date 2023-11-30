using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleDetection : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;
    public GameObject cursor;
    public GameObject projection;
    public GameObject capsule;
    public GameObject capsuleTop;
    public GameObject capsuleBot;

    // Homework 10: complete the CheckCollisionCirleCapsule function.
    bool CheckCollisionCircleCapsule(
        Vector3 circlePosition, float circleRadius,
        Vector3 capsulePosition, float capsuleRadius, Vector3 direction, float halfHeight, out Vector3 mtv)
    {
        // 1. Determine capsule top and bottom points.
        // 2. Project the circle onto the line between capsule top and bottom.
        // 3. Do circle-circle detection between the circle point & circle radius vs projected circle point & capsule radius.

        // 1:
        // Make top & bot vectors, call CapsulePoints to assign them.

        // 2:
        // Store projection of circle position onto capsule top & bot using ProjectPointLine.

        // 3:
        // Use CheckCollisionCircles to compare the circle's position & radius vs the projection & capsule's radius.

        mtv = Vector3.zero;
        return false;
    }

    void CapsulePoints(Vector3 position, Vector3 direction, float halfHeight, out Vector3 top, out Vector3 bot)
    {
        top = position + direction * halfHeight;
        bot = position - direction * halfHeight;
    }

    // Projects point P onto line AB
    Vector3 ProjectPointLine(Vector3 P, Vector3 A, Vector3 B)
    {
        Vector3 AB = B - A;
        Vector3 AP = P - A;
        float t = Vector3.Dot(AB, AP) / Vector3.Dot(AB, AB);
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        return A + AB * t;
    }

    bool CheckCollisionCircles(Vector3 position1, float radius1, Vector3 position2, float radius2, out Vector3 mtv)
    {
        // Distance between position 1 and position 2
        float distance = (position1 - position2).magnitude;

        // Direction from to position 2 to position 1
        Vector3 direction = (position1 - position2).normalized;

        // Sum of radii
        float radiiSum = radius1 + radius2;

        // Collision if distance between circles is less than the sum of their radii!
        bool collision = distance < radiiSum;
        if (collision)
        {
            // Calculate mtv only if there's a collision
            float depth = radiiSum - distance;
            mtv = direction * depth;
        }
        else
        {
            mtv = Vector3.zero;
        }
        return collision;
    }

    void Update()
    {
        // Get mouse position in screen-space, then convert it to world-space
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0.0f;
        cursor.transform.position = mouse;

        Vector2 position1 = circle1.transform.position;
        Vector2 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;

        // MTV resolves 1 from 2
        Vector3 mtv = Vector3.zero;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2, out mtv);
        circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);
        Color color = collision ? Color.green : Color.red;

        //Vector3 A = mouse;
        //Vector3 B = position1 - Vector2.zero;
        //Vector3 proj = Vector3.Project(A, B);
        Debug.DrawLine(Vector3.zero, mouse, Color.blue);
        Debug.DrawLine(Vector3.zero, position1, Color.red);
        Vector3 proj = ProjectPointLine(mouse, position1, Vector3.zero);
        projection.transform.position = proj;

        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;

        Vector3 capsulePosition = capsule.transform.position;
        Vector3 capsuleDirection = capsule.transform.up;
        float capsuleHalfHeight = capsule.transform.localScale.y * 0.5f;
        float capsuleRadius = capsule.transform.localScale.x * 0.5f;
        Vector3 top, bot;
        CapsulePoints(capsulePosition, capsuleDirection, capsuleHalfHeight, out top, out bot);
        capsuleTop.transform.position = top;
        capsuleBot.transform.position = bot;

        bool capsuleCollision = CheckCollisionCircleCapsule(position1, radius1,
            capsulePosition, capsuleRadius, capsuleDirection.normalized, capsuleHalfHeight, out mtv);
        circle1.transform.position += mtv;
        if (capsuleCollision)
        {
            capsule.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            capsule.GetComponent<SpriteRenderer>().color = Color.red;
        }
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
