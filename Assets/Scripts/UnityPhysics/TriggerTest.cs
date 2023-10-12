using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework:
// When the player overlaps with either SpeedCircle or SpeedSquare, their speed doubles.
// When the player stops overlapping with either SpeedCircle or SpeedSquare, their speed resets.
// (See https://docs.unity3d.com/Manual/CollidersOverview.html for more info on collisions).
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
            Debug.Log("Speeding up!");
        }
        else if (collision.name == "SlowCircle")
        {
            player.speed /= 2.0f;
            Debug.Log("Slowing down...");
        }
    }

    // Runs once on-exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.speed = initialSpeed;
    }
}
