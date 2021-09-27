using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float stopDistance = 5f;

    [SerializeField] Rigidbody2D player;

    private Rigidbody2D enemy;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        KeepDistanceFromPlayer();
    }

    void KeepDistanceFromPlayer()
    {
        if(Vector2.Distance(transform.position, player.transform.position) >= stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, -player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
