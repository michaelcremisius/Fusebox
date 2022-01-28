using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogGameController : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
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
}
