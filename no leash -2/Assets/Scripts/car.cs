using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public GameObject dog;
    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            DogController3 dogScript = other.GetComponent<DogController3>();
            if (dogScript != null)
            {
                dogScript.Die();  
            }

            Destroy(this.gameObject);
        }
    }
}
