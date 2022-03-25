using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeScript : MonoBehaviour
{
    public GameObject Score;
    // Start is called before the first frame update
    void Start()
    {
        Score.GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("TOTAL");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
