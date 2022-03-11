using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int lives;
    public Text livesDisplay;
    public GameObject Enemy;

    public Text startText;
    public Button startButton;
    public GameObject haze;
    // Start is called before the first frame update
    void Start()
    {
        //lives = 3;
        Time.timeScale = 0;
        livesDisplay.text = lives + "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //lives--;
        //livesDisplay.text = lives + "";
        Destroy(collision.gameObject);
        Enemy.GetComponent<EnemyBehaviour>().InitiateCooldown();
/*        if(lives <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            //lose game
        }*/
    }
    public int GetLives()
    {
        return lives;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
        haze.SetActive(false);
    }
}
