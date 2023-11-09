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
        //Vector3 direction = (Vector3.forward + Vector3.right).normalized;
        object1.transform.position += MoveObject(object1.transform.forward, speed);
        object2.transform.position += MoveObject(object2.transform.forward, speed);
        object3.transform.position += MoveObject(object3.transform.forward, speed);
        object4.transform.position += MoveObject(object4.transform.forward, speed);
        object5.transform.position += MoveObject(object5.transform.forward, speed);
    }
}
