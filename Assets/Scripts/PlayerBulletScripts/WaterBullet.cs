using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D fireBullet;
    [SerializeField] int damage = 10;

    void Start()
    {
        fireBullet.velocity = -transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth health = other.GetComponent<EnemyHealth>();
        if (health != null && other.gameObject.tag == "Fire")
        {
            health.TakeDamage(damage);
        }

        HeroHealth heroHealth = other.GetComponent<HeroHealth>();
        if (heroHealth != null && other.gameObject.tag == "Player")
        {
            heroHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
