using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject grenade;  // prefab
    Rigidbody rb;
    float speed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += -transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right;
        }
        rb.velocity = direction.normalized * speed;

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 grenadeDirection = (transform.forward + transform.up).normalized;
            Vector3 grenadePosition = transform.position + grenadeDirection * 1.5f;
            GameObject clone = Instantiate(grenade, grenadePosition, Quaternion.identity);
            clone.GetComponent<Rigidbody>().velocity = grenadeDirection * speed;
            Destroy(clone, 5.0f);
        }
    }
}
