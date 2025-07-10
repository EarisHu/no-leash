using UnityEngine;
using UnityEngine.SceneManagement;

public class level_switch : MonoBehaviour
{
    public void Loadhome()
    {
        SceneManager.LoadScene("home");
    }
    public void Loadcity()
    {
        SceneManager.LoadScene("city");
    }
    
    public void Loadnature()
    {
        SceneManager.LoadScene("nature");
    }
}
