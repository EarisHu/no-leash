using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private static music instance;
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject); // 防止多个实例重复
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject); // 跨场景持久化
        }
    }
}
