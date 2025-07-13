using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_day : MonoBehaviour
{
    public GameObject dog;
    private Rigidbody2D dogRb;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        dogRb = dog.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            ToggleGravity();
        }
    }

    void ToggleGravity()
    {
        dogRb.gravityScale = -Mathf.Abs(dogRb.gravityScale);
    
        Vector3 scale = dog.transform.localScale;
        scale.y = -Mathf.Abs(scale.y);
        dog.transform.localScale = scale;
    }
}
