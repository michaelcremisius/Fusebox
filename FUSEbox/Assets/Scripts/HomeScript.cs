using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScript : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "" + PlayerPrefs.GetInt("TOTAL");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
