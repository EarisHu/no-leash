using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHaven3 : MonoBehaviour
{
    void Update()
    {
        // 检测是否按下任意键
        if (Input.anyKeyDown)
        {
            // 加载菜单场景
            SceneManager.LoadScene("menu");
        }
    }
}
