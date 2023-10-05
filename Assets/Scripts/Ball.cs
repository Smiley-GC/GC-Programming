using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10.0f;

    public float xMin = -20.0f;
    public float xMax = 20.0f;

    public float yMin = -10.0f;
    public float yMax = 10.0f;

    public float xDir = 1.0f;
    public float yDir = 1.0f;

    void Update()
    {
        float x = transform.position.x;
        if (x < xMin)
        {
            xDir = 1.0f;
        }
        else if (x > xMax)
        {
            xDir = -1.0f;
        }

        float y = transform.position.y;
        if (y < yMin)
        {
            yDir = 1.0f;
        }
        else if (y > yMax)
        {
            yDir = -1.0f;
        }

        float dt = Time.deltaTime;
        float dx = xDir * speed * dt;
        float dy = yDir * speed * dt;
        transform.position = transform.position + new Vector3(dx, dy, 0.0f);
    }
}
