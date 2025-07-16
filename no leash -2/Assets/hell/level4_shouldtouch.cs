using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4_shouldtouch : MonoBehaviour
{
    public GameObject door;
    void Start()
    {
        door = GameObject.FindWithTag("level4_door");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            Destroy(door);
        }
    }
}
