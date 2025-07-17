using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scary_dog : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("scary");
    }
}
