using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class deathcount : MonoBehaviour
{
    public TMP_Text countdownText;

    void Start()
    {
        int count = PlayerPrefs.GetInt("deathCount", 0);
        countdownText.text = "You have died for " + count + " times";
    }
}
