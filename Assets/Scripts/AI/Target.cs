using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Must reference enemy since enemy owns all bullets
    public Seek enemy;

    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Seek>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Projectile"))
        {
            enemy.RemoveAllBullets();
        }
    }
}
