using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Transform airPoint;
    [SerializeField] Transform waterPoint;
    [SerializeField] Transform earthPoint;

    [SerializeField] GameObject fireBullet;
    [SerializeField] GameObject airBullet;
    [SerializeField] GameObject waterBullet;
    [SerializeField] GameObject earthBullet;

    [SerializeField] Button fireButton;
    [SerializeField] Button airButton;
    [SerializeField] Button waterButton;
    [SerializeField] Button earthButton;

    private void Start()
    {
        fireButton.onClick.AddListener(ShootFire);
        airButton.onClick.AddListener(ShootAir);
        waterButton.onClick.AddListener(ShootWater);
        earthButton.onClick.AddListener(ShootEarth);
    }

    private void ShootFire()
    {
        Instantiate(fireBullet, firePoint.position, firePoint.rotation);
    }

    private void ShootAir()
    {
        Instantiate(airBullet, airPoint.position, airPoint.rotation);
    }

    private void ShootWater()
    {
        Instantiate(waterBullet, waterPoint.position, waterPoint.rotation);
    }

    private void ShootEarth()
    {
        Instantiate(earthBullet, earthPoint.position, earthPoint.rotation);
    }
}
