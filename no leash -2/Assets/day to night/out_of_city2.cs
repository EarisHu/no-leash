using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class out_of_city2 : MonoBehaviour
{
    public GameObject dog;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            SceneManager.LoadScene("city3");
        }
    }
}
