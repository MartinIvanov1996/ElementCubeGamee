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

    //those are the animation prefabs
    [SerializeField] GameObject fireAttack;
    //and I made this because the fire object stayed fixed when played even if the cube is moving.
    //i use it in the update
    GameObject fireAttackTemp = null;
    [SerializeField] GameObject waterAttack;
    [SerializeField] GameObject windAttack;

    private void Start()
    {
        fireButton.onClick.AddListener(AttackFire);
        airButton.onClick.AddListener(AttackWind);
        waterButton.onClick.AddListener(AttackWater);
        earthButton.onClick.AddListener(ShootEarth);
    }

    private void Update()
    {
        if (fireAttackTemp)
        {
            fireAttackTemp.transform.position = firePoint.position;
            fireAttackTemp.transform.rotation = firePoint.rotation;
        }
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

    //io marto, here are the AttackElement methods I've created. 
    //some of them are kinda glitched - see the air. 
    //it has to somehow have fixed position Z,
    //I think it can be done with rigidbody, but I put the tornado with the rigidbody component inside an empty parent... why? i don't remember.
    //I had to do this parent thing when implementing the fire, because it was glitchy. 
    //the earth thing is a defence skill actually, its a wall that can protect you, but idk about the top and bottom sides.
    //maybe i should just make another kind of earth attack for top and bottom.
    //same goes for the tornado.
    //you can fix the tornado positions for now.
    //and destroy the prefabs when they disappear.

    //click this to see the code
    #region
    private void AttackFire()
    {
        fireAttackTemp = Instantiate(fireAttack, firePoint.position, firePoint.rotation);
        
    }

    private void AttackWater()
    {
        Instantiate(waterAttack, waterPoint.position, waterPoint.rotation);
    }
    private void AttackWind()
    {
        Instantiate(windAttack, airPoint.position, airPoint.rotation);
    }
    #endregion
}
