using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    void MovePlayer(float speed)
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    void Update()
    {
        MovePlayer(10.0f);
    }
}
