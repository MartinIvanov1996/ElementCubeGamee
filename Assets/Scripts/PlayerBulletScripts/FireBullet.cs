using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D fireBullet;
    [SerializeField] float timeToDestroy = 0.5f;
    [SerializeField] int damage = 10;

    const float speed = 0f;

    void Start()
    {
        fireBullet.velocity = transform.up * speed;  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth health = other.GetComponent<EnemyHealth>();
        if (health != null && other.gameObject.tag == "Air" || other.gameObject.tag == "Earth")
        {
            health.TakeDamage(damage);
        }

        HeroHealth heroHealth = other.GetComponent<HeroHealth>();
        if (heroHealth != null && other.gameObject.tag == "Player")
        {
            heroHealth.TakeDamage(damage);
        }

        Destroy(gameObject, timeToDestroy);
    }
}
