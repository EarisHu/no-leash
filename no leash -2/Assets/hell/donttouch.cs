using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donttouch : MonoBehaviour
{
    public GameObject dog;
    public GameObject enemy;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        enemy = GameObject.FindWithTag("enemy_4");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog"))
        {
            level4_enemy enemyScript = enemy.GetComponent<level4_enemy>();
            enemyScript.ifgo = true;  
        }
    }
}
