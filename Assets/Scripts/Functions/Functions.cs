using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    void Test()
    {
        Debug.Log("Testing... 1, 2, 3!");
    }

    void MovePlayer(float speed)
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    void Start()
    {
        Test();
    }

    void Update()
    {
        MovePlayer(10.0f);
    }
}
