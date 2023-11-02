using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public GameObject prefab;
    float speed = 10.0f;

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
        Instantiate(prefab, new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity);
    }

    void Update()
    {
        float tt = Time.realtimeSinceStartup;
        Debug.Log(tt);
        float dt = Time.deltaTime;
        //MovePlayer(10.0f, dt);
        Vector3 positionDelta = MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed, dt);
        transform.position += positionDelta;
    }
}
