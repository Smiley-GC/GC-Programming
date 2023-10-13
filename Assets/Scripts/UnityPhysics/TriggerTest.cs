using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change so that we slow down when we hit the circle
public class TriggerTest : MonoBehaviour
{
    float initialSpeed;
    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        initialSpeed = player.speed;
    }

    // Runs once on-enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "SpeedRectangle")
        {
            player.speed *= 2.0f;
        }
        else if (collision.name == "SlowCircle")
        {
            player.speed /= 2.0f;
        }
    }

    // Runs once on-exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.speed = initialSpeed;
    }
}
