using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class contains all the logic for our bullets
public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    List<GameObject> bullets = new List<GameObject>();

    public void AddBullet(Vector3 target, Vector3 shooter, float speed)
    {
        Vector3 bulletDirection = (target - shooter).normalized;
        Vector3 bulletPosition = shooter + bulletDirection;
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * speed;
        bullets.Add(bullet);
    }

    public void RemoveBullet(GameObject bullet)
    {
        Destroy(bullet);
        bullets.Remove(bullet);
    }

    public void RemoveAllBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            GameObject bullet = bullets[i];
            RemoveBullet(bullet);
        }
    }

    // Per-frame checks ie remove bullets if they're older than 1 second
    void Update()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            Bullet bullet = bullets[i].GetComponent<Bullet>();
            if (bullet.age > 1.0f)
                RemoveBullet(bullet.gameObject);
        }
    }
}
