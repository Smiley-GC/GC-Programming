using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCircleTest : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    public GameObject capsule;
    public GameObject topCircle;
    public GameObject botCircle;

    public GameObject cursor;
    public GameObject projection;

    private void Start()
    {
        Homework9();
    }

    void CapsulePoints(Vector2 position, Vector2 direction, float halfLength, out Vector2 top, out Vector2 bot)
    {
        top = position + direction * halfLength;
        bot = position - direction * halfLength;
    }

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
            float depth = radiiSum - distance;
            mtv = direction * depth;
        }
        else
        {
            mtv = Vector2.zero;
        }
        return collision;
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0.0f;
        cursor.transform.position = mouse;

        Vector2 position1 = circle1.transform.position;
        Vector2 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;

        Debug.DrawLine(Vector2.zero, position1, Color.red);
        Debug.DrawLine(Vector2.zero, mouse, Color.green);
        projection.transform.position = Vector3.Project(mouse, position1);

        // MTV resolves 1 from 2 (because it points from 2 to 1)
        Vector2 mtv = Vector2.zero;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2, out mtv);
        circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);

        Color color = collision ? Color.green : Color.red;
        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;

        Vector2 top, bot;
        Vector2 capsulePosition = capsule.transform.position;
        Vector2 capsuleDirection = capsule.transform.up;
        float halfLength = capsule.transform.localScale.y * 0.5f;
        CapsulePoints(capsulePosition, capsuleDirection, halfLength, out top, out bot);
        topCircle.transform.position = top;
        botCircle.transform.position = bot;

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

    void Homework9()
    {
        float answer1 = Vector2.Dot(new Vector2(4.0f, 4.0f), new Vector2(-4.0f, 4.0f));
        Vector3 answer2 = Vector3.Project(new Vector3(5.0f, 6.0f), new Vector3(-3.0f, 7.0f));
        Debug.Log(answer1);
        Debug.Log(answer2);
    }
}
