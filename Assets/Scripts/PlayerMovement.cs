using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float moveSpeed = 17.5f;
    private bool isFacingRight = true;

    [SerializeField] private float jumpForce = 12.5f;
    [SerializeField] private Animator animator; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CharacterController2D controller;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }

        Flip();
        Dead();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void Dead()
    {
        if(controller.isDead)
        {
            animator.SetBool("isDead", true);
        }
    }
}
