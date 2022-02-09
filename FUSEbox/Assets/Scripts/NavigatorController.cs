using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorController : MonoBehaviour
{

    public void SwitchScene(string nextScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
