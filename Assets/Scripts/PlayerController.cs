using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody2D rigidbody;
    private bool isDirectionToRight = true;
    private bool isPlayerOnGround = true;
    private float collisionRadius = 0.1f;
    public Transform groundTester;
    public LayerMask collisionGroundLayers;
    public float heroSpeed;
    public float jumpForce;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        this.animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        this.rigidbody.velocity = new Vector2(horizontalMove * this.heroSpeed, this.rigidbody.velocity.y);

        this.isPlayerOnGround = Physics2D.OverlapCircle(this.groundTester.position,
                                                         this.collisionRadius,
                                                         this.collisionGroundLayers);

        if (Input.GetKeyDown(KeyCode.Space) && this.isPlayerOnGround)
        {
            this.Jump();
        }

        if (horizontalMove < 0 && this.isDirectionToRight)
        {
            this.FlipDirection();
        }
        else if (horizontalMove > 0 && !this.isDirectionToRight)
        {
            this.FlipDirection();
        }
    }

    private void FlipDirection()
    {
        this.isDirectionToRight = !this.isDirectionToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    private void Jump()
    {
        this.rigidbody.AddForce(new Vector2(0, this.jumpForce));
        this.animator.SetTrigger("jump");
    }
}
