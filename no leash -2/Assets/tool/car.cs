using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public GameObject dog;
    public float speed = 50f;
    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
    }

    void Update()
    {
        if (dog.transform == null) return;

        Vector3 direction = (dog.transform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        Vector3 scale = transform.localScale;
        scale.x = dog.transform.position.x < transform.position.x ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;


    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            DogController dogScript = other.GetComponent<DogController>();
            if (dogScript != null)
            {
                dogScript.Die();  
            }

            Destroy(this.gameObject);
        }
    }
}
