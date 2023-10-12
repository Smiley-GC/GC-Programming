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
        ColliderTag tag = collision.GetComponent<ColliderTag>();
        if (tag != null)
        {
            if (tag.type == ColliderTag.Type.SPEED_UP)
            {
                player.speed *= 2.0f;
            }

            else if (tag.type == ColliderTag.Type.SPEED_DOWN)
            {
                player.speed /= 2.0f;
            }
        }
    }

    // Runs once on-exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.speed = initialSpeed;
    }
}
