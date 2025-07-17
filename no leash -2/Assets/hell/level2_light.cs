using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_light : MonoBehaviour
{
    public GameObject dog;
    public GameObject ghost;
    public float k;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        ghost = GameObject.FindWithTag("ghost");
        Vector3 pos = transform.position;
        k = pos.y;
    }

    void Update()
    {
        if (dog.transform.position.y > -37.5f)
        {
            Vector3 scale = transform.localScale;
            scale.y = -80f;
            transform.localScale = scale;
            Vector3 pos = transform.position;
            pos.y = 2 * ghost.transform.position.y - k - 20f;
            transform.position = pos;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.y = 120f;
            transform.localScale = scale;
            Vector3 pos = transform.position;
            pos.y = k;
            transform.position = pos;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            dog_hell dogScript = other.GetComponent<dog_hell>();
            dogScript.Die();  
        }
    }
}
