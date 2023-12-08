using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    List<GameObject> bullets = new List<GameObject>();

    public void AddBullet(Vector3 target, Vector3 shooter, float speed)
    {
        // AB = B - A
        // We want to go FROM the enemy TO the player, so enemy will be A and player will be B
        GameObject bullet = Instantiate(bulletPrefab);
        Vector3 bulletDirection = (target - shooter).normalized;
        bullet.transform.position = shooter + bulletDirection;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * speed;
        bullets.Add(bullet);
    }

    public void RemoveAllBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            RemoveBullet(i);
            i--;
        }
    }

    void RemoveBullet(int index)
    {
        Destroy(bullets[index]);
        bullets.Remove(bullets[index]);
    }

    void Update()
    {
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
}
