using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class exit : MonoBehaviour
{

    public string targetScene; // Ŀ�곡����������Build Settings����ӣ�
    public string collisionTag = "dog"; // ָ����ײ�����ǩ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(collisionTag))
        {
            Debug.Log("qqqq");
            SceneManager.LoadScene("nature");
        }
    }
}