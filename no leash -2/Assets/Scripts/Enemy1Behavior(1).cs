// Patrol position? In Start()

using UnityEngine;

public class EnemyBehavior1 : MonoBehaviour
{
    public float patrolLeftX;             
    public float patrolRightX;            
    public float speed;                     
    public float detectionRange;
    private GameObject dogObject;
    private Transform dogTransform;
    private float scale;
    private Rigidbody2D rb;
    // public float detectionRange; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        detectionRange = 45f; 
        speed = 10f;
        patrolLeftX = 337.2f;
        patrolRightX = 490.9f;
        scale = 5f;
        dogObject = GameObject.FindWithTag("Dog");
        if (dogObject != null)
            dogTransform = dogObject.transform;
    }

    void Update()
    {
        // float distanceToDog = Vector2.Distance(transform.position, dogTransform.position);
        // if (distanceToDog <= detectionRange)
        //     Destroy(gameObject);
        Patrol();
    }

    void Patrol()
    {
        // Target(left<->right)
        float targetX = Mathf.PingPong(Time.time * speed, patrolRightX - patrolLeftX) + patrolLeftX;
        float direction = targetX - transform.position.x;
        float moveDirection = Mathf.Sign(direction); // -1, 0, 1
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
        // Change facing
        if (moveDirection > 0) transform.localScale = new Vector3(1, 1, 1) * scale;
        else if (moveDirection < 0)
            transform.localScale = new Vector3(-1, 1, 1) * scale;
    }
}