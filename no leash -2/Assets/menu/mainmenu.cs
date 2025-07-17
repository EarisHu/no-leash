using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("news"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Reference()
    {
        SceneManager.LoadScene("reference");
    }
}
