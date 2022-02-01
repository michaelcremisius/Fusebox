/*****************************************************************************
// File Name :         ButtonBehaviour.cs
// Author :            Lucas Johnson
// Creation Date :     January 31, 2022
//
// Brief Description : A C# script that handles the overal control of the
                       buttons in the matching minigame.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [Tooltip("The value assigned to the button")]
    public int buttonValue;

    [Tooltip("If the button has been completed or not")]
    public bool buttonCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the button text and update it to reflect the value
        var buttonText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        buttonText.text = buttonValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Called when the button is clicked
    /// </summary>
    public void ButtonClicked()
    {
        ChangeButtonColor(Color.red);
    }

    /// <summary>
    /// Changes the color of the button
    /// </summary>
    /// <param name="newColor">The color the button will change to</param>
    public void ChangeButtonColor(Color newColor)
    {
        // Change the colors of the button
        var colors = GetComponent<Button>().colors;
        colors.normalColor = newColor;
        colors.selectedColor = newColor;
        colors.highlightedColor = newColor;
        GetComponent<Button>().colors = colors;
    }
}
