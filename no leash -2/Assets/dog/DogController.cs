// Open the trash bin? 
// Animation? 

using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Camera camera;
    private float blood;
    public float moveSpeed;
    public float jumpForce;
    private float groundCheckDistance;
    public LayerMask groundLayer;
    private bool isDead;

    void Start()
    {
        camera = Camera.main;
        moveSpeed = 20f;
        blood = 5f;
<<<<<<< Updated upstream
        jumpForce = 50f;
=======
        jumpForce = 80f;
>>>>>>> Stashed changes
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        groundCheckDistance = box.size.y * 0.5f * Mathf.Abs(transform.localScale.y) + 0.05f;
        isDead = false;
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (transform.position.y <= -camera.orthographicSize)
            Die();
        HandleInput();
        BloodChange();
=======
        if (!isDead && transform.position.y <= -150)
        {
            Debug.Log("out");
            Die();
        }
        HandleInput();
        // BloodChange();
        // if (transform.position.x >= 750)
        // {
        //     Debug.Log("oi");
        //     SceneManager.LoadScene("city2");
        // }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
>>>>>>> Stashed changes
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Enemy")
            Die();
    }

    void HandleInput()
    {
        float moveDirection = 0f;
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            // animator.Play("PickUpBone"); // Animation
            blood += 0.15f;
        }

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

    bool IsGrounded()
    {
        // return Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(origin, Vector2.down * groundCheckDistance, hit.collider ? Color.green : Color.red);
        return hit.collider != null;
    }

    void BloodChange()
    {
        blood -= 0.05f;
        if (blood == 0) Die();
    }

    void Die()
    {
<<<<<<< Updated upstream
        animator.Play("Die"); // Animation
        Invoke("Respawn", 2.0f); // Wait for 2 seconds
=======
        if (isDead) return; 
        isDead = true;
        // animator.Play("Die"); // Animation
        animator.Play("die");
        Invoke("Respawn", 0f); // Wait for 2 seconds
        Debug.Log("die???");
    }

    public void Win()
    {
        SceneManager.LoadScene("menu");
>>>>>>> Stashed changes
    }

    void Respawn()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}