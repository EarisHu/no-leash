using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bone : MonoBehaviour
{
    public GameObject count;
    void Start()
    {
        count = GameObject.FindWithTag("count");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            Countdown countScript = count.GetComponent<Countdown>();

            //if (gameObject.tag == "bone1")
            //{
            //    countScript.currentTime += 7;
            //    Destroy(gameObject);
            //}
            //else if (gameObject.tag == "bone2")
            //{
            //    countScript.currentTime += 7;
            //    Destroy(gameObject);
            //}
            //else if (gameObject.tag == "bone3")
            //{
            //    countScript.currentTime += 7;
            //    Destroy(gameObject);
            //}
            //else if (gameObject.tag == "bone4")
            //{
            //    countScript.currentTime += 7;
            //    Destroy(gameObject);
            //}

            countScript.currentTime += 7;
            Destroy(gameObject);
        }
    }
}
