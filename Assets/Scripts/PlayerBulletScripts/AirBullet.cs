using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D airBullet;

    void Start()
    {
        airBullet.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
