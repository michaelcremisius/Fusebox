using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogGameController : MonoBehaviour
{
    private GameObject player;
    public Button startButton;
    public Text startText;
    public GameObject FreezeMenu;
    private bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        print("I wanna take a picture");
        player = GameObject.Find("Frog");   
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        TrackTouch();
    }
    

    private void TrackTouch()
    {
        if (Input.GetMouseButton(0))
        {
            player.GetComponent<FrogBehaviour>().Movement();
        }
        else
        {
            player.GetComponent<FrogBehaviour>().StopMovement();
        }
    }

    public void StartTime()
    {
        hasStarted = true;
        startButton.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
        FreezeMenu.SetActive(false);
    }
}
