using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D airBullet;
    [SerializeField] int damage = 10;

    void Start()
    {
        airBullet.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.gameObject.name);
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
