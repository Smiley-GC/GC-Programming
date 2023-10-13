using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0f;
    public float rotationSpeed = 0.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Normalization proof:
        //Vector2 test = new Vector2(7, 8);
        //float magnitude = test.magnitude;
        //float x = test.x / magnitude;
        //float y = test.y / magnitude;
        //Vector2 nTest = new Vector2(x, y);
        //Debug.Log(test);
        //Debug.Log(nTest);           // manual normalization
        //Debug.Log(test.normalized); // automatic normalization
        //Debug.Log(magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float translationDelta = speed * dt;
        float rotationDelta = rotationSpeed * dt;

        Quaternion rotation = Quaternion.identity;
        if (Input.GetKey(KeyCode.Q))
        {
            rotation = Quaternion.Euler(0.0f, 0.0f, rotationDelta);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            rotation = Quaternion.Euler(0.0f, 0.0f, -rotationDelta);
        }
        transform.rotation *= rotation;

        Vector3 forward = transform.right;
        Vector3 left = transform.up;
        float lineLength = 10.0f;

        Debug.DrawLine(transform.position, transform.position + forward * lineLength);
        Debug.DrawLine(transform.position, transform.position + left * lineLength);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += forward * translationDelta;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= forward * translationDelta;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += left * translationDelta;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.position -= left * translationDelta;
        }
    }
}
