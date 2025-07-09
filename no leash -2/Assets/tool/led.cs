using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class led : MonoBehaviour
{
    public float switchInterval = 3f; 
    private float timer;
    private bool isRed = true;

    private SpriteRenderer spriteRenderer;

    public GameObject dog;        
    public GameObject carPrefab;
    public float a;
    public float b;  
    private bool carSpawned = false;

    void Start()
    {
        a = 558f;
        b = 618f; 
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetLightColor();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            isRed = !isRed;
            SetLightColor();
            timer = 0f;
            carSpawned = false; 
        }

        CheckDogAndSpawnCar();
    }

    void SetLightColor()
    {
        if (isRed)
            spriteRenderer.color = Color.red;
        else
            spriteRenderer.color = Color.green;
    }

    public bool IsRed()
    {
        return isRed;
    }

    void CheckDogAndSpawnCar()
    {
        if (!isRed && !carSpawned)
        {
            float dogX = dog.transform.position.x;

            if (dogX >= a && dogX <= b)
            {
                Instantiate(carPrefab, transform.position, Quaternion.identity);
                carSpawned = true;
            }
        }
    }
}
