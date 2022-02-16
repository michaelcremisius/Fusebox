using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{

    private uint score;
    public Text ScoreDisplay;
    public int threshold;
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
            if(score >= threshold)
            {
                LaunchPage();
            }
        }

    }

    private void LaunchPage()
    {
        if (checkFirst(PlayerPrefs.GetString("Current")) == 0)
        {
            MakeFirst(PlayerPrefs.GetString("Current"));
        }
        switch (PlayerPrefs.GetString("Current"))
        {
            case "meditation":

                break;
            case "feline":

                break;
            case "disaster":

                break;
            case "bellissimo":

                break;
            case "astrofacts":

                break;
            case "constellation":

                break;
            case "mismatched":

                break;
            case "cannon":
 
                break;
            case "rhythm":

                break;
            case "theia":

                break;
            default:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Home Screen");
                break;

        }
    }
    private int checkFirst(string game)
    {
        return PlayerPrefs.GetInt(game);
    }
    private void MakeFirst(string game)
    {
        PlayerPrefs.SetInt(game,1);
        PlayerPrefs.SetInt("TOTAL", PlayerPrefs.GetInt("TOTAL") + 1);
    }

}


