using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{

    public uint score;
    public Text ScoreDisplay;
    public int threshold;
    private float xPos;
    public GameObject coin;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        xPos = 0;
        ScoreDisplay.text = score + "/" + threshold;
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
            ScoreDisplay.text = score + "/" + threshold;
            if(score >= threshold)
            {
                Invoke("LaunchPage", 2f);
                win.SetActive(true);
                coin.SetActive(true);
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Meditation Station");
                break;
            case "feline":
                UnityEngine.SceneManagement.SceneManager.LoadScene("End of Feline");
                break;
            case "disaster":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Disaster Golf");
                break;
            case "bellissimo":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Bellissimo");
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
        PlayerPrefs.SetInt(game,1);
        PlayerPrefs.SetInt("TOTAL", PlayerPrefs.GetInt("TOTAL") + 1);
    }

}


