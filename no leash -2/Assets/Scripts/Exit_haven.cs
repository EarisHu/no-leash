using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit_haven : MonoBehaviour
{
    public string targetScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            Debug.Log("qqqq");
            SceneManager.LoadScene("haven");
        }
    }
}
