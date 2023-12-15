using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle
{
    public Vector2 position;
    public Vector2 direction;
    public float radius;

    public Vector2 Bottom()
    {
        return position - direction * radius;
    }
}

public class Rectangle
{
    public Vector2 position;
    public Vector2 direction;
    public float halfWidth;
    public float halfHeight;

    public Vector2 Bottom()
    {
        return position - direction * halfHeight;
    }
}

public class Capsule
{
    public Vector2 position;
    public Vector2 direction;
    public float radius;
    public float halfLength;

    public Vector2 Bottom()
    {
        return position - direction * (halfLength + radius);
    }
}

public class Detection : MonoBehaviour
{
    public GameObject rectangleGO;
    public GameObject circleGO;
    public GameObject capsuleGO;

    public GameObject rectangleBottom;
    public GameObject circleBottom;
    public GameObject capsuleBottom;

    Rectangle rectangle = new Rectangle();
    Circle circle = new Circle();
    Capsule capsule = new Capsule();

    Vector2 vel = Vector2.zero;
    void Update()
    {
        float dt = Time.deltaTime;
        Vector2 acc = new Vector2(0.0f, Physics.gravity.y);
        vel = vel + acc * dt;
        Vector2 positionDelta = vel * dt;
        rectangleGO.transform.position += new Vector3(positionDelta.x, positionDelta.y);

        rectangle.position = rectangleGO.transform.position;
        rectangle.direction = rectangleGO.transform.up;
        rectangle.halfWidth = rectangleGO.transform.localScale.x * 0.5f;
        rectangle.halfHeight = rectangleGO.transform.localScale.y * 0.5f;
        rectangleBottom.transform.position = rectangle.Bottom();

        circle.position = circleGO.transform.position;
        circle.direction = circleGO.transform.up;
        circle.radius = circleGO.transform.localScale.x * 0.5f;
        circleBottom.transform.position = circle.Bottom();

        capsule.position = capsuleGO.transform.position;
        capsule.direction = capsuleGO.transform.up;
        capsule.radius = rectangleGO.transform.localScale.x * 0.25f;
        capsule.halfLength = rectangleGO.transform.localScale.y * 0.5f;
        capsuleBottom.transform.position = capsule.Bottom();
    }
}
