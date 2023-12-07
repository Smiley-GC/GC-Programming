using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Player" script for AI scene
public class Target : MonoBehaviour
{
    private BulletPool bulletPool;

    void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
            bulletPool.RemoveAllBullets();
    }
}
