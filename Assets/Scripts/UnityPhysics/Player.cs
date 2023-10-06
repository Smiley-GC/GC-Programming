using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

        }

        else if (Input.GetKey(KeyCode.S))
        {

        }

        else if (Input.GetKey(KeyCode.A))
        {

        }

        else if (Input.GetKey(KeyCode.D))
        {

        }

        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
