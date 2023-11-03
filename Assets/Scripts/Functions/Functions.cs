using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    float speed = 10.0f;

    void MovePlayer(float speed)
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    Vector3 MoveObject(Vector3 direction, float speed)
    {
        return direction * speed * Time.deltaTime;
    }

    void Update()
    {
        //MovePlayer(10.0f);
        //transform.position += MoveObject(transform.right, speed);
        //transform.position += transform.right * speed * Time.deltaTime;
    }
}
