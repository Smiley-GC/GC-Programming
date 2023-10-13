using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework: modify the code such that the rotation speed doubles when the player is overlapping with a SPEED_UP object,
// and halves when the player is overlapping with a SPEED_DOWN object.
// the rotation speed should reset when the player is no longer overlapping with a SPEED_UP or SPEED_DOWN object.
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
