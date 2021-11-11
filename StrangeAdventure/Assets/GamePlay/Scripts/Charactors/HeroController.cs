using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class HeroController : MonoBehaviour
{
    public float MoveSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private float direction = 1;
    private bool setVelocity;
    private bool canJump;
    private bool contolHero;
    void Start()
    {
        Application.targetFrameRate = 30;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        setVelocity = false;
        canJump = false;
        contolHero = true;
    }
    void Update()
    {
        if (contolHero)
        {
            if (Input.GetKey(KeyCode.A)&&!setVelocity)
            {
                OnLeftDirectionButtonDown();
            }
            else if(Input.GetKey(KeyCode.D)&&!setVelocity)
            {
                OnRightDirectionButtonDown();
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                OnLeftDirectionButtonUp();
            }
            else if(Input.GetKeyUp(KeyCode.D))
            {
                OnRightDirectionButtonUp();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumpButtonDown();
            }
        
            if (Physics2D.BoxCast(transform.position, new Vector2(0.9f, 0.6f), 0, Vector2.down, 0.3f, 1 << 9).collider && !canJump)
            {
                canJump = true;
                if (Mathf.Abs(rigidbody2D.velocity.x) > 0.02f)
                {
                    RunAnimation();
                }
                else
                {
                    IdleAnimation();
                }
            }
            else
            {
                canJump = false;
            }
        
            if (setVelocity)
            {
                if (direction == 0)
                {
                    rigidbody2D.velocity = new Vector2(MoveSpeed * -1, rigidbody2D.velocity.y);
                }
                else
                {
                    rigidbody2D.velocity = new Vector2(MoveSpeed * 1, rigidbody2D.velocity.y);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        rigidbody2D.AddForce(new Vector2(0,-20));
    }
    public void OnJumpButtonDown()
    {
        if (contolHero)
        {
            if (Physics2D.BoxCast(transform.position, new Vector2(0.9f, 0.6f), 0, Vector2.down, 0.3f, 1 << 9).collider)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
            if (canJump)
            {
                rigidbody2D.gravityScale = 0;
                rigidbody2D.AddForce(new Vector2(0,580f));
                JumpAnimation();
            }
        }
    }
    public void OnRightDirectionButtonDown()
    {
        if (contolHero)
        {
            direction = 1;
            animator.SetFloat("Direction",direction);
            if (canJump)
            {
                RunAnimation();
            }
            setVelocity = true;
        }
    }
    public void OnRightDirectionButtonUp()
    {
        if (contolHero)
        {
            setVelocity = false;
            if (canJump)
            {
                IdleAnimation();
            }
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }
    public void OnLeftDirectionButtonDown()
    {
        if (contolHero)
        {
            direction = 0;
            animator.SetFloat("Direction",direction);
            if (canJump)
            {
                RunAnimation();
            }
            setVelocity = true;
        }
    }
    public void OnLeftDirectionButtonUp()
    {
        if (contolHero)
        {
            setVelocity = false;
            if (canJump)
            {
                IdleAnimation();
            }
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
        
    }
    public void IdleAnimation()
    {
        animator.SetBool("Jump",false);
        animator.SetBool("Run",false);
        animator.SetBool("Idle",true);
    }
    public void RunAnimation()
    {
        animator.SetBool("Jump",false);
        animator.SetBool("Run",true);
        animator.SetBool("Idle",false);
    }
    public void JumpAnimation()
    {
        animator.SetBool("Jump",true);
        animator.SetBool("Run",false);
        animator.SetBool("Idle",false);
    }
    public void DieAnimation()
    {
        animator.SetBool("Die",true);
    }

    public void DisableControl()
    {
        contolHero = false;
        rigidbody2D.velocity = Vector2.zero;
    }
}
