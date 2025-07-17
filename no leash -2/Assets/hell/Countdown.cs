using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class Countdown : MonoBehaviour
{
    public float currentTime;

    public TMP_Text countdownText;
    public GameObject dog;

    void Start()
    {
        countdownText.text = "";
        currentTime = 4f;
        StartCoroutine(CountdownRoutine());
        dog = GameObject.FindWithTag("Dog");
    }

    IEnumerator CountdownRoutine()
    {
        while (currentTime > 0)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
            currentTime -= 1f;
        }

        countdownText.text = "00:00";

        // 倒计时结束后做的事：
        dog_hell dogScript = dog.GetComponent<dog_hell>();
        dogScript.Die();
        Debug.Log("Time's up!");
    }
}
