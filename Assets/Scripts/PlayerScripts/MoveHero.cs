using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveHero : MonoBehaviour
{
    private Rigidbody2D player;

    private bool isNotInAir;

    private RaycastHit hit;

    LayerMask mask;

    [SerializeField] float distToGround = 0.52f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float RotationSpeed = 5f;

    [SerializeField] Joystick floatingJoystick;
    [SerializeField] Button jumpButton;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        mask = LayerMask.GetMask("Ground");
        jumpButton.onClick.AddListener(Jump);
    }

    private void FixedUpdate()
    {
        CheckIfIsInAir();
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        if (isNotInAir)
        {
            player.velocity = new Vector2(floatingJoystick.Horizontal * moveSpeed, player.velocity.y);
        }

        if(!isNotInAir)
        {
            player.transform.Rotate(-floatingJoystick.Horizontal * Vector3.forward * RotationSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (isNotInAir)
        {
            player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void CheckIfIsInAir()
    {
        isNotInAir = Physics2D.Raycast(player.transform.position, Vector2.down, distToGround, mask);
    }
}