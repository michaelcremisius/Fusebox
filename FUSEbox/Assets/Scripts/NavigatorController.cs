using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorController : MonoBehaviour
{

    public bool isTeam;
    public bool isPassport;
    public AudioSource CoinClick;
    private void Start()
    { 
        Time.timeScale = 1;
    }
    public void SwitchScene(string nextScene)
    {
        if (isTeam)
        {
            if(PlayerPrefs.GetInt("TOTAL") == 10)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("All Scenes Collected");
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            if(isPassport)
            {
                CoinClick.Play();
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
