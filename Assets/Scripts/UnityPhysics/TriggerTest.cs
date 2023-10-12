using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework:
// When the player overlaps with either SpeedCircle or SpeedSquare, their speed doubles.
// When the player stops overlapping with either SpeedCircle or SpeedSquare, their speed resets.
// (See https://docs.unity3d.com/Manual/CollidersOverview.html for more info on collisions).
public class TriggerTest : MonoBehaviour
{
    // Runs once on-enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // *= is the same as assigning a variable to itself times a number
        //float a = 1.0f;
        //a = a * 2.0f;
        //a *= 2.0f;
        gameObject.GetComponent<Player>().speed *= 2.0f;
        Debug.Log("Speeding up!");
    }

    // Runs on repeat every frame the gameObject is moving within the collision area
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(name + " is continuing to be triggered by " + collision.name);
    //}

    // Runs once on-exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Player>().speed /= 2.0f;
        Debug.Log("Slowing down...");
    }
}
