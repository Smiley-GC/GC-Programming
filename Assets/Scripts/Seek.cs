using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    // Homework task 1: if the AI has detected the player, shoot at it (1%)!
    public GameObject target;
    public GameObject projectile;   // TODO -- instantiate this prefab and fire it at the player
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
        float dt = Time.deltaTime;
        if (seeking)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);
    }
}
