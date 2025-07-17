using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level6_damage_manager : MonoBehaviour
{
    public GameObject dog;
    public GameObject damage1;
    public GameObject damage3;
    void Start()
    {
        damage1 = GameObject.FindWithTag("damage1");
        damage3 = GameObject.FindWithTag("damage3");
        dog = GameObject.FindWithTag("Dog");
        damage1.SetActive(false);
        damage3.SetActive(false);
    }

    void Update()
    {
        if (dog.transform.position.y < -400 && dog.transform.position.y > -470 && dog.transform.position.x < 100)
        {
            damage1.SetActive(true);
        }
        if (dog.transform.position.y < -400 && dog.transform.position.y > -470 && dog.transform.position.x < -36)
        {
            damage3.SetActive(true);
        }
        
    }
}
