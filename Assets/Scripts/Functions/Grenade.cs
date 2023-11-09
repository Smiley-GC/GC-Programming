using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // TODO -- make an actual explosion!
    // https://learn.unity.com/tutorial/introduction-to-particle-systems
    // https://docs.unity3d.com/ScriptReference/ParticleSystem.html
    private void OnDestroy()
    {
        Debug.Log("BOOM!");
    }
}
