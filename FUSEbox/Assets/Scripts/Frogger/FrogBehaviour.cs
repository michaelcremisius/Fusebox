using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FrogBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 StartingPoint;
    public Text scoreBoard;
    public int threshold;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        rb2d.velocity = new Vector3(7, 0, 0);
    }
    public void StopMovement()
    {
        rb2d.velocity = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            score++;
            if(score >= threshold)
            {
                LaunchPage();
            }
            scoreBoard.text = score.ToString();
        }
        transform.position = StartingPoint;

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
        PlayerPrefs.SetInt(game, 1);
        PlayerPrefs.SetInt("TOTAL", PlayerPrefs.GetInt("TOTAL") + 1);
    }
}
