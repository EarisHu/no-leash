using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat3 : MonoBehaviour
{
    private GameObject p;
    public bool over;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("plat4");
        over = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "dog")
        {
            if (!p.GetComponent<plat4>().isTouch)
            {
                over = true;
            }
        }
    }
}
