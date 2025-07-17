using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;



public class Countdown : MonoBehaviour
{
    public float currentTime;

    public TMP_Text countdownText;

    void Start()
    {
        countdownText.text = "";
        currentTime = 4f;
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (currentTime > 0)
        {
            countdownText.text = Mathf.Ceil(currentTime).ToString();
            yield return new WaitForSeconds(1f);
            currentTime -= 1f;
        }

        countdownText.text = "0";

        // 倒计时结束后做的事：
        Debug.Log("Time's up!");
        // SceneManager.LoadScene("NextSceneName");
        // 或者 触发事件等
    }
}
