using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemap_manager : MonoBehaviour
{
    public GameObject tilemap1;
    public GameObject tilemap2;

    private float timer;
    private float switchInterval;
    private bool show;

    void Start()
    {
        Debug.Log("Start 开始");

        tilemap1 = GameObject.FindWithTag("map1");
        tilemap2 = GameObject.FindWithTag("map2");

        Debug.Log("tilemap1: " + tilemap1);
        Debug.Log("tilemap2: " + tilemap2);

        timer = 0f;
        switchInterval = 2f;
        show = true;
        tilemap1.SetActive(true);
        tilemap2.SetActive(false);

        Debug.Log("Start 结束");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            show = !show;
            tilemap1.SetActive(show);
            tilemap2.SetActive(!show);
            timer = 0f;
        }
    }
}
