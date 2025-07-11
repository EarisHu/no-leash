using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public GameObject dog;
    private bool following;
    public float patrolLeftX;
    public float patrolRightX;
    public float speed;
    private float scale;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("dog");
        following = false;
        speed = 10f;
        patrolLeftX = 337.2f;
        patrolRightX = 490.9f;
        scale = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (following) ;
        else Patrol();
    }

    void OnCollisionEnter2D(Collision2D collision)
    // IsTrigger = false
    {
        if (collision.gameObject == dog)
        {
            // ���dog��������
            transform.SetParent(dog.transform);
            following = true;
        }
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
