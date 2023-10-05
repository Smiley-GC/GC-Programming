using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework 4: Double the player's speed when they are on top of a speed-up area.
// Hint: compare gameObject.name with collision.gameObject.name to determine which two objects are overlapping.
public class SpeedDetection : MonoBehaviour
{
    // Double speed on-enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + " is triggered by " +  collision.gameObject.name);
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Reset to original speed on-exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + " is no longer triggered by " +  collision.gameObject.name);
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}
