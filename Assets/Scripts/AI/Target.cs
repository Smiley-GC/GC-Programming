using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    BulletPool bulletPool;

    void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Projectile"))
        {
            bulletPool.RemoveAllBullets();
        }
    }
}
