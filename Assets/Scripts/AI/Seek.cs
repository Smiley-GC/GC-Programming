using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework 9: Destroy ALL bullets if ANY bullets collide with the player using the bullets list.
public class Seek : MonoBehaviour
{
    public Transform target;
    BulletPool bulletPool;

    float currentTime = 0.0f;
    float totalTime = 0.05f;

    float speed = 2.0f;
    bool targetDetected = false;

    void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Projectile"))
        {
            targetDetected = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Projectile"))
        {
            targetDetected = false;
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (targetDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * dt);

            // If current time is greater than total time, fire a bullet and reset the timer!
            if (currentTime >= totalTime)
            {
                currentTime = 0.0f;
                bulletPool.AddBullet(target.position, transform.position, speed * 5.0f);
            }
            currentTime += dt;
        }
    }
}
