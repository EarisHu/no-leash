using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class exit : MonoBehaviour
{

    public string targetScene; // 目标场景名（需在Build Settings中添加）
    public string collisionTag = "dog"; // 指定碰撞物体标签
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(collisionTag))
        {
            Debug.Log("qqqq");
            SceneManager.LoadScene("nature");
        }
    }
}