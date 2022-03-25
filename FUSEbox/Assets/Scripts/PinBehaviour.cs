using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinBehaviour : MonoBehaviour
{
    private string pin;
    public TextMeshProUGUI textBox;
    private bool activated;
    private float countDown;
    public float maxCountDown;
    // Start is called before the first frame update
    private void Start()
    {
        activated = false;
        pin = "-----";
    }

    public void AddNum(string num)
    {
        if (!activated)
        {
            SimplifyPin();
            if (pin.Length < 5)
            {
                pin += num;
                FillPin();
                textBox.text = pin;
            }
        }
    }

    public void Delete()
    {
        if(!activated)
        {
            SimplifyPin();
            if (pin.Length > 0)
            {
                pin = pin.Substring(0, pin.Length - 1);
            }
            FillPin();
            textBox.text = pin;
        }

    }

    private void FillPin()
    {
        while(pin.Length < 5)
        {
            pin += "-";
        }
    }
    private void SimplifyPin()
    {
        if(pin.Contains("-"))
        {
            pin = pin.Substring(0, pin.IndexOf("-"));
        }
    }

    public void Submit()
    {
        if (!activated)
        {
            switch (pin) //kaboom, matching, frogger, circuit
            {
                case "54461": //meditation
                    textBox.text = "MEDITATION";
                    PlayerPrefs.SetString("Current", "meditation");
                    Invoke("LoadKaboom", 1f);
                    //kaboom
                    break;
                case "33310": //feline
                    textBox.text = "FELINE";
                    PlayerPrefs.SetString("Current", "feline");
                    Invoke("LoadMatching", 1f);
                    //matching
                    break;
                case "71266": //disaster
                    textBox.text = "DISASTER";
                    PlayerPrefs.SetString("Current", "disaster");
                    Invoke("LoadFrogger", 1f);
                    //frogger
                    break;
                case "80232": //bellissimo
                    textBox.text = "BELLISSIMO";
                    PlayerPrefs.SetString("Current", "bellissimo");
                    Invoke("LoadCircuit1", 1f);
                    //circuit
                    break;
                case "15753": //astrofacts
                    textBox.text = "ASTROFACTS";
                    PlayerPrefs.SetString("Current", "astrofacts");
                    Invoke("LoadKaboom", 1f);
                    //kaboom
                    break;
                case "21989": //constellation
                    textBox.text = "CONSTELLATION";
                    PlayerPrefs.SetString("Current", "constellation");
                    Invoke("LoadMatching", 1f);
                    //matching
                    break;
                case "95642": //mismatched
                    textBox.text = "MISMATCHED";
                    PlayerPrefs.SetString("Current", "mismatched");
                    Invoke("LoadFrogger", 1f);
                    //frogger
                    break;
                case "34492": //cannon
                    textBox.text = "CANNON";
                    PlayerPrefs.SetString("Current", "cannon");
                    Invoke("LoadCircuit1", 1f);
                    //circuit
                    break;
                case "08776": //rhythm
                    textBox.text = "RHYTHM";
                    PlayerPrefs.SetString("Current", "rhythm");
                    Invoke("LoadFrogger", 1f);
                    //frogger
                    break;
                case "14412": //theia
                    textBox.text = "THEIA";
                    PlayerPrefs.SetString("Current", "theia");
                    Invoke("LoadCircuit1", 1f);
                    //circuit
                    break;
                default:
                    countDown = maxCountDown;
                    break;
            }
        }
    }



    private void LoadCircuit1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Circuit Minigame 1");
        activated = true;
    }
    private void LoadFrogger()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Frogger");
        activated = true;
    }
    private void LoadMatching()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Matching Minigame");
        activated = true;
    }
    private void LoadKaboom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Kaboom Minigame");
        activated = true;
    }

    private void Update()
    {
        TickDown();

    }
    private void TickDown()
    {
        if(countDown > 0f)
        {
            countDown -= Time.deltaTime;
            textBox.color = Color.red;
        }
        else
        {
            textBox.color = Color.white;
        }
    }
}
