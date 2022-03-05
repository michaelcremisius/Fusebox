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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        player = GameObject.Find("Frog");   
    }

    // Update is called once per frame
    void Update()
    {
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

        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
        FreezeMenu.SetActive(false);
    }
}
