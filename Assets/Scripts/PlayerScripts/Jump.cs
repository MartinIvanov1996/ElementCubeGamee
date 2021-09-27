using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
}
