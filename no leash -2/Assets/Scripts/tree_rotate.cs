using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_rotate : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D treeCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        treeCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< Updated upstream
        if (other.gameObject.name == "dog") 
=======
        if (d.transform.position.x >= 530)
>>>>>>> Stashed changes
        {
            animator.SetTrigger("Hit");
            // treeCollider.isTrigger = false;
        }
    }

}
