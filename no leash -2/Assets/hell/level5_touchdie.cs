using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5_touchdie : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            dog_hell dogScript = other.GetComponent<dog_hell>();
            dogScript.Die();  
        }
    }
}
