using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework 9: Destroy ALL bullets if ANY bullets collide with the player using the bullets list.
public class Seek : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;
    public List<GameObject> bullets = new List<GameObject>();

    float currentTime = 0.0f;
    float totalTime = 0.05f;

    float speed = 2.0f;
    bool targetDetected = false;

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
                bullets.Add(bullet);
                currentTime = 0.0f;
            }
            currentTime += dt;
        }

        // Destroy bullet and remove from list if bullet is older than 1 second.
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i].GetComponent<Bullet>().age > 1.0f)
            {
                RemoveBullet(i);
                i--;
            }
        }
    }

    public void RemoveAllBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            RemoveBullet(i);
            i--;
        }
    }

    public void RemoveBullet(int index)
    {
        Destroy(bullets[index]);
        bullets.Remove(bullets[index]);
    }
}
