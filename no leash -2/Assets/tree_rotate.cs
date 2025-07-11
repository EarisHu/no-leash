using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_rotate : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "dog")
            animator.Play("tree_rotate");
    }

}
