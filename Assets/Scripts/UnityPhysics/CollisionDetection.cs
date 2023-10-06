using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // "Paint the town red" (runs once on-enter)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Change current object to red
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        // Change object colliding with current object to red
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Runs on repeat every frame the gameObject is moving within the collision area
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    
    //}

    // "Unpaint the town red" (runs once on-exit)
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Change current object to red
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        // Change object colliding with current object to red
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
