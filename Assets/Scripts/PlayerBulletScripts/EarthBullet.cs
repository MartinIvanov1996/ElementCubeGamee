using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D fireBullet;
    [SerializeField] int damage = 10;

    void Start()
    {
        fireBullet.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if(enemyHealth != null && other.gameObject.tag == "Water")
        {
            enemyHealth.TakeDamage(damage);
        }

        HeroHealth heroHealth = other.GetComponent<HeroHealth>();
        if (heroHealth != null && other.gameObject.tag =="Player")
        {
            heroHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
