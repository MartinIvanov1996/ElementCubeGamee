using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Does not shoot earth at the moment

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Transform airPoint;
    [SerializeField] Transform waterPoint;
    [SerializeField] Transform earthPoint;

    [SerializeField] Button fireButton;
    [SerializeField] Button airButton;
    [SerializeField] Button waterButton;
    [SerializeField] Button earthButton;

    //those are the animation prefabs
    [SerializeField] GameObject fireAttack;
    //and I made this because the fire object stayed fixed when played even if the cube is moving.
    //i use it in the update
    GameObject fireAttackTemp = null;
    GameObject waterAttackTemp = null;
    GameObject windAttackTemp = null;
    [SerializeField] GameObject waterAttack;
    [SerializeField] GameObject windAttack;

    private float timeUntilDestroy = 2f;

    private void Start()
    {
        fireButton.onClick.AddListener(AttackFire);
        airButton.onClick.AddListener(AttackWind);
        waterButton.onClick.AddListener(AttackWater);
    }

    private void Update()
    {
        if (fireAttackTemp)
        {
            fireAttackTemp.transform.position = firePoint.position;
            fireAttackTemp.transform.rotation = firePoint.rotation;
        }
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
    private void AttackFire()
    {
        fireAttackTemp = Instantiate(fireAttack, firePoint.position, firePoint.rotation);
        Destroy(fireAttackTemp, timeUntilDestroy);
    }

    private void AttackWater()
    {
        waterAttackTemp = Instantiate(waterAttack, waterPoint.position, waterPoint.rotation);
        Destroy(waterAttackTemp, timeUntilDestroy);
    }
    private void AttackWind()
    {
        windAttackTemp = Instantiate(windAttack, airPoint.position, airPoint.rotation);
        Destroy(windAttackTemp, timeUntilDestroy);
    }
}
