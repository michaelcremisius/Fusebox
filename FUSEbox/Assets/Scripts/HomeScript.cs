using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeScript : MonoBehaviour
{
    public GameObject Score;
    private int representationalScore;
    public float timerMax;
    private float scaledTimerMax;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerMax;
        scaledTimerMax = timerMax;
        //Score.GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("TOTAL");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteAll();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            PlayerPrefs.SetInt("TOTAL", 5);
        }
        if (representationalScore < PlayerPrefs.GetInt("TOTAL"))
        {
            CountUP();
        }
    }

    void CountUP()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Score.GetComponent<TextMeshProUGUI>().text = "" + ++representationalScore;
            print(representationalScore / PlayerPrefs.GetInt("TOTAL"));
            if ((float)representationalScore / PlayerPrefs.GetInt("TOTAL") >= .5f)
            {
                scaledTimerMax += .15f;
                timer = scaledTimerMax;
            }
            else
            {
                timer = timerMax;
            }
        }
    }
}
