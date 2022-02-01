/*****************************************************************************
// File Name :         MatchingGameController.cs
// Author :            Lucas Johnson
// Creation Date :     January 31, 2022
//
// Brief Description : A C# script that handles the overal control of the
                       matching minigame.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGameController : MonoBehaviour
{
    [Tooltip("Number of buttons to spawn on startup")]
    public int buttonCount = 16;

    [Tooltip("Refrence to the Button Prefab")]
    public GameObject buttonPrefab;

    [Tooltip("List of the buttons in the grid")]
    public List<GameObject> buttons = new List<GameObject>();

    /// <summary>
    /// Reference to the grid object
    /// </summary>
    private GameObject grid;

    /// <summary>
    /// Awake is called when the script is loading
    /// </summary>
    void Awake()
    {
        // Find the grid object for reference
        grid = GameObject.Find("Grid");

        // Spawn buttons and apply values
        GenerateButtons();
        ApplyButtonValues();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Spawns the buttons in the grid and adds them to the buttons list
    /// </summary>
    private void GenerateButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            GameObject currentbutton = Instantiate(buttonPrefab);
            currentbutton.transform.SetParent(grid.transform);
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
            GameObject randomButton1 = tempButtonList[Random.Range(0, tempButtonList.Count)];
            randomButton1.GetComponent<ButtonBehaviour>().buttonValue = buttonValues;
            tempButtonList.Remove(randomButton1);

            GameObject randomButton2 = tempButtonList[Random.Range(0, tempButtonList.Count)];
            randomButton2.GetComponent<ButtonBehaviour>().buttonValue = buttonValues;
            tempButtonList.Remove(randomButton2);

            buttonValues--;
        }
    }
}
