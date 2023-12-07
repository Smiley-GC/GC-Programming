using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework 9: Destroy all bullets and remove them from the bullets list if ANY bullets hit the target (Player).
public class Seek : MonoBehaviour
{
    public Transform target;
    private BulletPool bulletPool;

    float movementSpeed = 2.0f;
    float bulletSpeed = 10.0f;

    float elapsed = 0.0f;   // Current time
    float duration = 0.25f; // Total time

    bool detected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Bullet"))
            detected = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Bullet"))
            detected = false;
    }

    void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        // If detected, seek towards player and shoot bullets if cooldown is expired
        if (detected)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * dt);

            if (elapsed >= duration)
            {
                elapsed = 0.0f;
                bulletPool.AddBullet(target.position, transform.position, bulletSpeed);
            }
            elapsed += dt;
        }

        // Manual test to ensure RemoveAllBullets() works!
        if (Input.GetKey(KeyCode.Space))
        {
            bulletPool.RemoveAllBullets();
        }
    }
}
