using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCollision : MonoBehaviour
{
    // gameObject is the object which this script is attached to
    // collision.gameObject is the object this object is colliding with
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        // TODO -- spawn an epic explosion!
        // Overview: https://learn.unity.com/tutorial/introduction-to-particle-systems
        // Documentation: https://docs.unity3d.com/ScriptReference/ParticleSystem.html
        Destroy(gameObject);
    }
}
