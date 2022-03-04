///By Sean Lee, 1/27/22. contact for help
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircuitGameController : MonoBehaviour
{
    //Button Presses: Used to track how many times the player has clicked on a circuit junction.
    private int buttonPresses;

    [Tooltip("If we have a double wire puzzle that includes two junctions that need to be set correctly instead of just one, set this to true.")]
    public bool twoJunctionsToFinish = false;

    [Tooltip("If the Junction required to finish beat the level has been set to its correct rotation, this will become true.")]
    public bool requiredJunction = false;

    [Tooltip("Same as above but is only used in scenarioes where there are two junctions required.\nBE SURE TO SET THIS TO SOMETHING EVEN IF NOT IN USE!")]
    public bool requiredJunction2 = false;

    [Tooltip("The Game Object for the first required Junction")]
    public GameObject requiredJunctionObject;

    [Tooltip("The Game Object for the second required Junction")]
    public GameObject requiredJunctionObject2;

    [Tooltip("The object that lights up when the player wins")]
    public GameObject lightbulb;

    public Text CounterText;

    private Color OnColor = new Color(1f, 1f, .6f, 1f);
    private Color OffColor = new Color(.54f, .54f, .54f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        buttonPresses = 0;
        CounterText.text = buttonPresses.ToString();
    }


    /// <summary>
    /// Adds one to the button press count.
    /// </summary>
    public void IncreasePressCount()
    {
        buttonPresses++;
        CounterText.text = buttonPresses.ToString();
    }

    /// <summary>
    /// Returns button presses.
    /// </summary>
    /// <returns></returns>
    public int ReturnButtonPresses()
    {
        return buttonPresses;
    }

    /// <summary>
    /// Attempts to win. This is run whenever a junction is turned.
    /// </summary>
    public void TryWin()
    {
        //update the bools needed to win by checking the dedicated junctions.
        requiredJunction = requiredJunctionObject.GetComponent<CircuitJunctionScript>().GetBoolState();
        if (twoJunctionsToFinish) { requiredJunction2 = requiredJunctionObject2.GetComponent<CircuitJunctionScript>().GetBoolState(); }

        if (requiredJunction && !twoJunctionsToFinish)
        {
            lightbulb.GetComponent<SpriteRenderer>().color = OnColor;
            LaunchPage();
        }
        else if (twoJunctionsToFinish && requiredJunction && requiredJunction2) lightbulb.GetComponent<SpriteRenderer>().color = OnColor;
        else lightbulb.GetComponent<SpriteRenderer>().color = OffColor;
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Disaster Golf");//TEMP
                break;
            case "bellissimo":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Bellissimo");//TEMP
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
