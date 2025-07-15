using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep_dog : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("sleep");
    }
}
