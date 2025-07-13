using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_day : MonoBehaviour
{
    public GameObject dog;
    private Rigidbody2D dogRb;
    private DogController3 dogScript;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        dogScript = dog.GetComponent<DogController3>();
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
        dogScript.day_switch();
        dogRb.gravityScale = -Mathf.Abs(dogRb.gravityScale);
        Vector3 scale = dog.transform.localScale;
        scale.y = -Mathf.Abs(scale.y);
        dog.transform.localScale = scale;
    }
}
