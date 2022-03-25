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
    public Image circleBar;
    private float fillTimer;
    public float MaxFillTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerMax;
        fillTimer = MaxFillTimer;
        scaledTimerMax = timerMax;
        circleBar.fillAmount = 0;
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
            PlayerPrefs.SetInt("TOTAL", 10);
        }
        if (representationalScore < PlayerPrefs.GetInt("TOTAL"))
        {
            CountUP();
        }
        FillCircle();
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
                scaledTimerMax += .07f;
                timer = scaledTimerMax;
            }
            else
            {
                timer = timerMax;
            }
        }
    }
    private void FillCircle()
    {
        if (fillTimer > 0)
        {
            fillTimer -= Time.deltaTime;
        }
        else
        {
            if (circleBar.fillAmount < (float)PlayerPrefs.GetInt("TOTAL")/10)
            {
                fillTimer = MaxFillTimer;//+ (circleBar.fillAmount/85);
                circleBar.fillAmount += .01f;
            }
        }
    }
}
