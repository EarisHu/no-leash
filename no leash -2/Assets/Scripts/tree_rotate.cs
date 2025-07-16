using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_rotate : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D treeCollider;
    private GameObject t;

    void Start()
    {
        treeCollider = GetComponent<BoxCollider2D>();
        t = GameObject.Find("tree");
        animator = t.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "dog") 
        {
            animator.SetTrigger("Hit");
            // treeCollider.isTrigger = false;
        }
    }

}
