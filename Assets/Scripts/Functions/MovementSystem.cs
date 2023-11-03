using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;

    float speed = 10.0f;

    Vector3 MoveObject(Vector3 direction, float speed)
    {
        return direction * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Vector3.forward + Vector3.right).normalized;
        object1.transform.position += MoveObject(direction, speed);
        object2.transform.position += MoveObject(direction, speed);
        object3.transform.position += MoveObject(direction, speed);
        object4.transform.position += MoveObject(direction, speed);
        object5.transform.position += MoveObject(direction, speed);
    }
}
