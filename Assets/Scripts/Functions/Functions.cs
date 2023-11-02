using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    float speed = 10.0f;

    void Test()
    {
        Debug.Log("Testing... 1, 2, 3!");
    }

    void MovePlayer(float speed, float dt)
    {
        transform.position += Vector3.forward * speed * dt;
    }

    Vector3 MoveObject(Vector3 direction, float speed, float dt)
    {
        return direction * speed * dt;
    }

    void Start()
    {
        Test();
    }

    void Update()
    {
        float tt = Time.realtimeSinceStartup;
        float dt = Time.deltaTime;
        //MovePlayer(10.0f, dt);
        Vector3 positionDelta = MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed, dt);
        transform.position += positionDelta;
    }
}
