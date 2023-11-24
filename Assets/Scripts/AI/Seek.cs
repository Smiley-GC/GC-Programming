using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework task 2: make the enemy shoot at the player when in proximity
public class Seek : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;

    float currentTime = 0.0f;
    float totalTime = 0.5f;

    float speed = 2.0f;
    bool targetDetected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Projectile"))
        {
            targetDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);

            // If current time is greater than total time, fire a bullet and reset the timer!
            if (currentTime >= totalTime)
            {
                // AB = B - A
                // We want to go FROM the enemy TO the player, so enemy will be A and player will be B
                Vector3 bulletDirection = (target.transform.position - transform.position).normalized;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position + bulletDirection;
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * speed * 5.0f;
                currentTime = 0.0f;
            }
            currentTime += dt;
        }
    }
}
