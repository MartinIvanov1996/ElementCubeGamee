using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] float fireRate = 1;
    [SerializeField] float fireSpeed = 20f;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;

    private void Start()
    {
        InvokeRepeating("Shoot", 0.1f, fireRate);
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
