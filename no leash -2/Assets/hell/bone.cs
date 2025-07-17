using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bone : MonoBehaviour
{
    public GameObject count;

    void Start()
    {
        count = GameObject.FindWithTag("count");
        //count = GameObject.Find("count");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            count = GameObject.FindWithTag("count");

            if (count == null)
            {
                Debug.Log("nonononono");
            }
            Countdown countScript = count.GetComponent<Countdown>();

            countScript.currentTime += 7f;
            Destroy(gameObject);
        }
    }
}
