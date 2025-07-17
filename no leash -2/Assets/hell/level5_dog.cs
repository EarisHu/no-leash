using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5_dog : MonoBehaviour
{
    private float groundCheckDistance;
    public LayerMask groundLayer;
    private Animator animator;
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    private bool isdead;

    void Start()
    {
        isdead = false;
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        groundCheckDistance = box.size.y * 0.5f * Mathf.Abs(transform.localScale.y) + 0.05f;
        animator = GetComponent<Animator>();
        moveSpeed = 50f;
        jumpForce = 90f;
    }


    void Update()
    {
        if (IsGrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !isdead)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (!isdead)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (!IsGrounded())
            {
                animator.Play("jump");
            }
            else
            {
                animator.Play("walk");
            }
        }
    }

    bool IsGrounded()
    {
        Vector2 origin = transform.position;
        float width = 7.5f;

        Vector2 leftOrigin = origin + Vector2.left * width;
        Vector2 rightOrigin = origin + Vector2.right * width;

        RaycastHit2D leftHit = Physics2D.Raycast(leftOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D centerHit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(leftOrigin, Vector2.down * groundCheckDistance, leftHit.collider ? Color.green : Color.red);
        Debug.DrawRay(rightOrigin, Vector2.down * groundCheckDistance, rightHit.collider ? Color.green : Color.red);

        return leftHit.collider != null || rightHit.collider != null || centerHit.collider != null;
    }
    
    public void Die()
    {
        if (isdead) return;
        isdead = true;
        animator.Play("die"); // Animation
        Invoke("Respawn", 2f); // Wait for 2 seconds
    }
}
