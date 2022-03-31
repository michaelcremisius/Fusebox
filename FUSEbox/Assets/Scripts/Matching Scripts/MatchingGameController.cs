/*****************************************************************************
// File Name :         MatchingGameController.cs
// Author :            Lucas Johnson
// Creation Date :     January 31, 2022
//
// Brief Description : A C# script that handles the overal control of the
                       matching minigame. Including spawning buttons at the
                       start, controlling the game state, testing if two
                       selected buttons are the same, and providing a win
                       condition when the game is beat.
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// The states in which the game can be in
/// </summary>
public enum GameState
{
    SelectButton1,
    SelectButton2,
    TestButtons,
    TestVictory
}
public class MatchingGameController : MonoBehaviour
{
    [Tooltip("Reference to this script")]
    public static MatchingGameController instance;

    [Tooltip("The state the game is currently in")]
    public GameState state;

    [Tooltip("Number of buttons to spawn on startup")]
    public int buttonCount = 16;

    [Tooltip("Refrence to the Button Prefab")]
    public GameObject buttonPrefab;

    [Tooltip("List of the buttons in the grid")]
    public List<GameObject> buttons = new List<GameObject>();

    [Tooltip("List of the images that can appear on the buttons")]
    public List<GameObject> images = new List<GameObject>();

    public AudioSource MatchSound;
    public AudioSource MissSound;
    public AudioSource FlipSound;

    // Reference to the grid object
    private GameObject grid;

    // Buttons that have been selected
    public ButtonBehaviour selectedButton1;
    public ButtonBehaviour selectedButton2;

    public GameObject coin;
    public GameObject coin2;
    public GameObject win;

    /// <summary>
    /// Awake is called when the script is loading
    /// </summary>
    void Awake()
    {
        // Be able to access this script from anywhere
        instance = this;

        // Find the grid object for reference
        grid = GameObject.Find("Grid");
    }

    /// <summary>
    /// Start is called on the first frame
    /// </summary>
    private void Start()
    {
        // Set the starting game state
        UpdateGameState(GameState.SelectButton1);
    }

    /// <summary>
    /// Called when the user clicks the start button
    /// </summary>
    public void StartGame()
    {
        GenerateButtons();
        ApplyButtonValues();
        ApplyButtonImages();
    }

    /// <summary>
    /// Updates the current game state and calls the functions accociated with
    /// with the new state
    /// </summary>
    /// <param name="newState">The new state the game will change to</param>
    public void UpdateGameState(GameState newState)
    {
        // Set the current game state to the new game state
        state = newState;

        // Call the neccessary functions based on the new game state
        switch (newState)
        {
            case GameState.SelectButton1:
                break;
            case GameState.SelectButton2:
                FlipSound.Play();
                break;
            case GameState.TestButtons:
                AnalizeButtonValues();
                break;
            case GameState.TestVictory:
                TestVictory();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Spawns the buttons in the grid and adds them to the buttons list
    /// </summary>
    private void GenerateButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            GameObject currentbutton = Instantiate(buttonPrefab, grid.transform);
            buttons.Add(currentbutton);
        }
    }

    /// <summary>
    /// Picks two random buttons and applies matching values to them
    /// (Repeats till every button has a value)
    /// </summary>
    private void ApplyButtonValues()
    {
        // Number of pairs to add values to
        int buttonValues = buttons.Count/2;

        // Create a copy of the buttons list to hold the buttons that still need a value assigned
        List<GameObject> tempButtonList = new List<GameObject>();
        for (int i = 0; i < buttons.Count; i++)
        {
            tempButtonList.Add(buttons[i]);
        }

        // Pick two random buttons and assign the same value to them, and then reduce the number of pairs to assign
        for (int i = 0; i < buttons.Count/2; i++)
        {
            GameObject randomButton1 = tempButtonList[UnityEngine.Random.Range(0, tempButtonList.Count)];
            randomButton1.GetComponent<ButtonBehaviour>().buttonValue = buttonValues;
            tempButtonList.Remove(randomButton1);

            GameObject randomButton2 = tempButtonList[UnityEngine.Random.Range(0, tempButtonList.Count)];
            randomButton2.GetComponent<ButtonBehaviour>().buttonValue = buttonValues;
            tempButtonList.Remove(randomButton2);

            buttonValues--;
        }
    }

    private void ApplyButtonImages()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int imageNum = buttons[i].GetComponent<ButtonBehaviour>().buttonValue - 1;
            Instantiate(images[imageNum], buttons[i].transform);
        }
    }

    /// <summary>
    /// Tests whether the two selected buttons are the same and changes the color based on the outcome
    /// </summary>
    private void AnalizeButtonValues()
    {
        // If the buttons have the same value...
        if (selectedButton1.buttonValue == selectedButton2.buttonValue)
        {
            MatchSound.Play();
            selectedButton1.gameObject.GetComponent<Button>().interactable = false;
            selectedButton2.gameObject.GetComponent<Button>().interactable = false;
        }
        // If the buttons have different values...
        else
        {
            MissSound.Play();
            selectedButton1.ChangeButtonColor(Color.red);
            selectedButton2.ChangeButtonColor(Color.red);

            Invoke("ResetButtons", 0.2f);
        }

        // Advance the game state
        UpdateGameState(GameState.TestVictory);
    }

    /// <summary>
    /// Sets the selected buttons back to white
    /// and clears the selectedButton variables
    /// </summary>
    public void ResetButtons()
    {
        selectedButton1.ChangeButtonColor(Color.white);
        selectedButton2.ChangeButtonColor(Color.white);

        selectedButton1.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        selectedButton2.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        selectedButton1 = null;
        selectedButton2 = null;
    }

    /// <summary>
    /// Test the buttons to see if the player has found every pair
    /// </summary>
    private void TestVictory()
    {
        // Boolean to represent if the player will win
        bool victory = true;

        // If a button is found that is still interactable, set victory to false
        foreach (var button in buttons)
        {
            if(button.GetComponent<Button>().interactable)
            {
                victory = false;
                break;
            }
        }

        // If the player has found all the pairs they win, otherwise continue the game
        if(victory)
        {
            Invoke("LaunchPage",2f);
            win.SetActive(true);
            coin.SetActive(true);
            coin2.SetActive(true);
        }
        else
        {
            UpdateGameState(GameState.SelectButton1);
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Disaster Golf");//TEMP
                break;
            case "bellissimo":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Bellissimio");//TEMP
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