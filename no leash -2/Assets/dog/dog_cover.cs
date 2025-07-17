using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_cover : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("static");
    }

    // Update is called once per frame
    // void Update()
    // {
    //     animator.Play("static");
    // }
}
