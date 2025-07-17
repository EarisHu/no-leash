using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_ghost : MonoBehaviour
{
    public GameObject dog;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
    }

    void Update()
    {
        if (dog.transform.position.y > -37.5)
        {
            Vector3 scale = transform.localScale;
            scale.y = -1f;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.y = 1f;
            transform.localScale = scale;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            DogController3 dogScript = other.GetComponent<DogController3>();
            dogScript.Die();  
        }
    }
}
