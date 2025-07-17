using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat2 : MonoBehaviour
{
    public bool isTouch;
    public Rigidbody2D rb;
    private GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        p = GameObject.Find("plat1");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.GetComponent<plat1>().over)
        {
            rb.isKinematic = false;
            rb.gravityScale = 8f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "dog")
        {
            isTouch = true;
        }
    }
}
