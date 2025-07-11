using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public GameObject dog;
    private bool following;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("dog");
        following = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (following) ;
        else
        {

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == dog)
        {
            // 变成dog的子物体
            transform.SetParent(dog.transform);
            following = true;
        }
    }
}
