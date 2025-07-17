using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4_enemy : MonoBehaviour
{
    public bool ifgo;
    void Start()
    {
        ifgo = false;
    }

    void Update()
    {
        if (ifgo)
        {
            transform.Translate(Vector2.left * 75f * Time.deltaTime);
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
