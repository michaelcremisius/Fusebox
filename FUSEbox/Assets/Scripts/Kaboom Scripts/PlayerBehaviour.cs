using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{

    private uint score;
    public Text ScoreDisplay;
    private float xPos;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        xPos = 0;
    }


    private void Update()
    {
        TrackFinger();
        Movement();
    }

    private void TrackFinger()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            xPos = worldPos.x;
        }

    }
    private void Movement()
    {

        transform.position = new Vector3(xPos, -3.65f, 0);
        //move the catcher there
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Obstacle"))
        {
            Destroy(collision.gameObject);
            score++;
            ScoreDisplay.text = score + "";
        }

    }

}
