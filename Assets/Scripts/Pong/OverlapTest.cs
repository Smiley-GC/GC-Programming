using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapTest : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    void Update()
    {
        if (Collision.Overlap2D(object1, object2))
        {
            object1.GetComponent<SpriteRenderer>().color = Color.red;
            object2.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            object1.GetComponent<SpriteRenderer>().color = Color.green;
            object2.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
