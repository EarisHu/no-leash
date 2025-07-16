using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_rotate : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D treeCollider;
    private GameObject t;
    private GameObject d;

    void Start()
    {
        treeCollider = GetComponent<BoxCollider2D>();
        t = GameObject.Find("tree");
        animator = t.GetComponent<Animator>();
        d = GameObject.Find("dog");
    }

    void Update()
    {
        if (d.transform.position.x >= 540)
        {
            animator.SetTrigger("Hit");
        }
    }
}
