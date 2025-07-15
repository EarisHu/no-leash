using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController1 : MonoBehaviour
{
    // public GameObject targetObject;  // 指定的目标物体（在Inspector中拖拽赋值）
    // public float spawnThreshold; // 触发生成的临界距离（可在Inspector调整）
    // public GameObject popPrefab;     // "pop"预制体引用（在Inspector中拖拽赋值）
    // private bool hasTriggered = false;
    private Animator animator;
    private Rigidbody2D rb;
    private Camera camera;
    private float blood;
    public float moveSpeed;
    public float jumpForce;
    private float groundCheckDistance;
    public LayerMask groundLayer;
    public bool isDead;

    void Start()
    {
        isDead = false;
        // spawnThreshold = 150f;
        camera = Camera.main;
        blood = 5f;
        // moveSpeed = 40f;
        // jumpForce = 50f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        groundCheckDistance = box.size.y * 0.5f * Mathf.Abs(transform.localScale.y) + 1f;
    }

    void Update()
    {
        if (transform.position.y < (camera.transform.position.y - camera.orthographicSize + 2 * transform.localScale.y))
        {
            rb.bodyType = RigidbodyType2D.Static;
            Debug.Log("已切换为Static模式");
            Die();
        }
        HandleInput();
        BloodChange();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.name == "Enemy")
        // {
        //     Die();
        // }
        if (other.gameObject.name == "meat")
        {
            jumpForce = 110f;
            moveSpeed = 60f;
        }
        if (other.gameObject.CompareTag("Badmeat"))
        {
            jumpForce = 70f;
            moveSpeed = 20f;
        }
        if (other.gameObject.CompareTag("Chocolate"))
        {
            Die();
        }
        if (other.gameObject.CompareTag("elec"))
        {
            Die();
        }
    }

    void HandleInput()
    {
        float moveDirection = 0f;
        if (!isDead)
        {
            // A: left
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
            if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            // S: pick up bones
            //         if (Input.GetKeyDown(KeyCode.S))
            //         {
            //             // animator.Play("PickUpBone"); // Animation
            //             blood += 0.15f;
            //         }
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
            //appearance
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

    // bool IsGrounded()
    // {
    //     // return Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    //     Vector2 origin = transform.position;
    //     RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

    //     Debug.DrawRay(origin, Vector2.down * groundCheckDistance, hit.collider ? Color.green : Color.red);
    //     return hit.collider != null;
    // }
    bool IsGrounded()
    {
        Vector2 origin = transform.position;
        float width = 5f;

        Vector2 leftOrigin = origin + Vector2.left * width;
        Vector2 rightOrigin = origin + Vector2.right * width;

        RaycastHit2D leftHit = Physics2D.Raycast(leftOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D centerHit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(leftOrigin, Vector2.down * groundCheckDistance, leftHit.collider ? Color.green : Color.red);
        Debug.DrawRay(rightOrigin, Vector2.down * groundCheckDistance, rightHit.collider ? Color.green : Color.red);

        return leftHit.collider != null || rightHit.collider != null || centerHit.collider != null;
    }

    void BloodChange()
    {
        blood -= 0.05f;
        if (blood == 0) Die();
    }

    void Die()
    {
        if (isDead) return; 
        isDead = true;
        animator.Play("die");
        Invoke("Respawn", 2f);
    }


    public void Respawn()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}