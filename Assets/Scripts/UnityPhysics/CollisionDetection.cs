using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note the difference between collision vs trigger:
// Collision does a physics-based collision resulting in Unity preventing the two objects from overlapping.
// Trigger simply tests for overlap so you can respond to an event (ie doubling speed if in overlapping area)
public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " is colliding with " + collision.gameObject.name);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " is no longer colliding with " + collision.gameObject.name);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
