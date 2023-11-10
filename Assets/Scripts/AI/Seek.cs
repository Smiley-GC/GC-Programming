using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework task 2: make the enemy shoot at the player when in proximity
public class Seek : MonoBehaviour
{
    public GameObject target;
    float speed = 2.0f;
    bool seeking = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        seeking = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        seeking = false;
    }

    void Update()
    {
        if (seeking)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
