using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_light_switch : MonoBehaviour
{
    private float timer;
    public float switchInterval;
    public bool ifappear;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    void Start()
    {
        light1 = GameObject.FindWithTag("light1");
        light2 = GameObject.FindWithTag("light2");
        light3 = GameObject.FindWithTag("light3");
        
        timer = 0f;
        switchInterval = 2f;
        ifappear = true;
        light1.SetActive(true);
        light2.SetActive(false);
        light3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            ifappear = !ifappear;
            timer = 0f;
        }
        light1.SetActive(ifappear);
        light2.SetActive(!ifappear);
        light3.SetActive(ifappear);
    }
}
