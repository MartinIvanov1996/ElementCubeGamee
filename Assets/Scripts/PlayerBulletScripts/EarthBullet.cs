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
        Destroy(gameObject);
        EnemyHealth health = other.GetComponent<EnemyHealth>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
