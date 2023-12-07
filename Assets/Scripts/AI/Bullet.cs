using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float age = 0.0f;

    void Update()
    {
        age += Time.deltaTime;
    }


}
