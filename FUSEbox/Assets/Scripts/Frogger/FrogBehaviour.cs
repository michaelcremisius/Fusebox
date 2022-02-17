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
        rb2d.velocity = new Vector3(0, 7, 0);
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Meditation Station");
                break;
            case "feline":
                UnityEngine.SceneManagement.SceneManager.LoadScene("End of Feline");
                break;
            case "disaster":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Home Screen");//TEMP
                break;
            case "bellissimo":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Home Screen");//TEMP
                break;
            case "astrofacts":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Astrofacts");
                break;
            case "constellation":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Constellation Exploration");
                break;
            case "mismatched":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Mismatch Mayhem");
                break;
            case "cannon":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Cannon Brawl");
                break;
            case "rhythm":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Rhythm Rumble");
                break;
            case "theia":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Theia");
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
