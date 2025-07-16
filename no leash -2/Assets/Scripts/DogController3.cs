// Open the trash bin? 
// Animation? 

using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController3 : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Camera camera;
    private float blood;
    public float moveSpeed;
    public float jumpForce;
    private float groundCheckDistance;
    public LayerMask groundLayer;
    public bool isDead;
    public Vector2 way;
    public bool ifwith;

    void Start()
    {
        Debug.Log("!!!!");
        ifwith = false;
        way = Vector2.down;
        isDead = false;
        camera = Camera.main;
        moveSpeed = 50f;
        blood = 5f;
        jumpForce = 90f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        groundCheckDistance = box.size.y * 0.5f * Mathf.Abs(transform.localScale.y) + 0.05f;
    }

    void Update()
    {
        if (!isDead && (transform.position.y < (camera.transform.position.y - camera.orthographicSize + 2 * transform.localScale.y)))
        // || transform.position.y > (camera.transform.position.y + camera.orthographicSize - 2 * transform.localScale.y)
        {
            rb.bodyType = RigidbodyType2D.Static;
            Debug.Log("已切换为Static模式");
            Die();
        }
        if (!isDead && (transform.position.y > (camera.transform.position.y + 2 * camera.orthographicSize)))
        {
            if (isDead) return;
            isDead = true;
            // animator.Play("die"); // Animation
            Invoke("Respawn", 0f);
        }
        pause p = FindObjectOfType<pause>();
        if (!p.isPaused)
        { 
            HandleInput();
        }
        // BloodChange();
        // if (transform.position.x >= 750)
        // {
        //     Debug.Log("oi");
        //     SceneManager.LoadScene("city2");
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "friend")
        {
            ifwith = true;
            // if (!IsGrounded())
            //     animator.Play("jump_with_friend");
            // else
            //     animator.Play("static_with_friend");
        }
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
        if (collision.gameObject.tag == "meat")
        {
            Debug.Log("oi");
            jumpForce = 100f;
            moveSpeed = 60f;
        }
        if (collision.gameObject.tag == "enemy")
            Die();
        // if (collision.gameObject.name == "meat1")
        // {
        //     jumpForce = 140f;
        //     moveSpeed = 65f;
        // }
        if (collision.gameObject.tag == "Badmeat")
            Die();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
        //else if (collision.gameObject.name == "enemy1")
        //    Die();
        //else if (collision.gameObject.name == "meat1")
        //{
        //    jumpForce = 140f;
        //    moveSpeed = 65f;
        //}
        //else if (collision.gameObject.tag == "Badmeat")
        //    Die();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Badmeat")
            Die();
    }

    void HandleInput()
    {
        float moveDirection = 0f;
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1f;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }

            // D: right
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1f;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            // W: jump
            if (IsGrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                // 直接赋予垂直速度（忽略当前质量）
                // float jumpVelocity = jumpForce;
                // rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                Debug.Log("oi");
            }
            // S: pick up bones
            if (Input.GetKeyDown(KeyCode.S))
            {
                // animator.Play("PickUpBone"); // Animation
                blood += 0.15f;
            }
            if (!ifwith)
            {
                //appearance
                if (!IsGrounded())
                {
                    animator.Play("jump");
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    animator.Play("walk");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    animator.Play("walk");
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    animator.Play("static");
                }
                else
                {
                    animator.Play("static");
                }
            }
            else
            {
                if (!IsGrounded())
                {
                    animator.Play("jump_with_friend");
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    animator.Play("walk_with_friend");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    animator.Play("walk_with_friend");
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    animator.Play("static_with_friend");
                }
                else
                {
                    animator.Play("static_with_friend");
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
    }

    bool IsGrounded()
    {
        Vector2 origin = transform.position;
        float width = 7.5f;

        Vector2 leftOrigin = origin + Vector2.left * width;
        Vector2 rightOrigin = origin + Vector2.right * width;

        RaycastHit2D leftHit = Physics2D.Raycast(leftOrigin, way, groundCheckDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightOrigin, way, groundCheckDistance, groundLayer);
        RaycastHit2D centerHit = Physics2D.Raycast(origin, way, groundCheckDistance, groundLayer);

        Debug.DrawRay(leftOrigin, Vector2.down * groundCheckDistance, leftHit.collider ? Color.green : Color.red);
        Debug.DrawRay(rightOrigin, Vector2.down * groundCheckDistance, rightHit.collider ? Color.green : Color.red);

        return leftHit.collider != null || rightHit.collider != null || centerHit.collider != null;
    }

    public void day_switch()
    {
        way = Vector2.up;
        // jumpForce = 0 - jumpForce;
    }

    public void night_switch()
    {
        way = Vector2.down;
        // jumpForce = 0 - jumpForce;
    }

    void BloodChange()
    {
        blood -= 0.05f;
        if (blood == 0) Die();
    }

    public void Die()
    {
        Debug.Log("???");
        if (isDead) return;
        isDead = true;
        animator.Play("die"); // Animation
        Invoke("Respawn", 2f); // Wait for 2 seconds
    }

    public void Win()
    {
        SceneManager.LoadScene("menu");
    }

    void Respawn()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}