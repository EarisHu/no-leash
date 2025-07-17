using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_2 : MonoBehaviour
{
    public GameObject dog; 
    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
    }

    void Update()
    {
        if (dog.transform.position.y > 37 && dog.transform.position.x > 40)
        {
            gameObject.SetActive(false);
        }
    }
}
