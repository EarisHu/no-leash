using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class win_hell : MonoBehaviour
{

    public string targetScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            Debug.Log("qqqq");
            SceneManager.LoadScene("hell_win");
        }
    }
}

