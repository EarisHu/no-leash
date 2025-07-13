using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daytonight : MonoBehaviour
{
    public GameObject world_day;
    public GameObject world_night;

    private bool in_world_day;

    void Start()
    {
        world_day = GameObject.FindWithTag("Day");
        world_night = GameObject.FindWithTag("Night");
        world_day.SetActive(true);
        world_night.SetActive(false);
        in_world_day = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            in_world_day = !in_world_day;
            world_day.SetActive(in_world_day);
            world_night.SetActive(!in_world_day);
        }
    }
}
