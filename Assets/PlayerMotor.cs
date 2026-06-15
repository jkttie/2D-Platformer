using System;
using System.Collections;
using System.Data.SqlTypes;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
  
    Vector2 direction;
    private new Rigidbody2D rigidbody2D;

    public float maxSpeed = 10;
    public float stoppingForce = 5;
    public float speed = 10;
    //public float stoppingPoint = 0.1f;

    private bool canJump = true;
    public float jumpForce = 10;
    private int jumpCount;
    public int maxJumpCount = 2;

    public float dashForce = 30;
    public float dashTime = 0.5f;
    private bool isDash = false;
    

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));

            if (isDash)
            {
                return;
            }
            if (rigidbody2D.linearVelocityX >= maxSpeed)
            {
                rigidbody2D.linearVelocityX = maxSpeed;
            }

            else if (rigidbody2D.linearVelocityX <= -maxSpeed)
            {
                rigidbody2D.linearVelocityX = -maxSpeed;
            }

            if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
            {
                rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
            }
        }
    }
    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            if (jumpCount >= maxJumpCount)
                canJump = false;
        }

    }
    private void OnDash()
    {
        if (isDash)
        {
            return;
        }
        isDash = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(dashTime));
    }

    IEnumerator ResetDash(float timeToRest)
    { 
        yield return new WaitForSeconds(timeToRest);
        isDash = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        jumpCount = 0;
    }
}
