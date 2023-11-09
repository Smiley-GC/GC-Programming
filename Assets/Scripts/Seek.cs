using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    // Homework: if the AI has detected the player, shoot at it!
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

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (seeking)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);
    }
}
