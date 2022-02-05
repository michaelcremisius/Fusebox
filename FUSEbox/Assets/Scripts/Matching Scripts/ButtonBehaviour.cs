/*****************************************************************************
// File Name :         ButtonBehaviour.cs
// Author :            Lucas Johnson
// Creation Date :     January 31, 2022
//
// Brief Description : A C# script that handles the overal control of the
                       buttons in the matching minigame. Including handling
                       when a button is clicked and changing it's color.
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

    private MatchingGameController mgc;

    // Start is called before the first frame update
    void Start()
    {
        // Get the MatchingGameController script to reference
        mgc = MatchingGameController.instance;

        // Get the button text and update it to reflect the value
        var buttonText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        buttonText.text = buttonValue.ToString();
    }

    /// <summary>
    /// Called when the button is clicked
    /// </summary>
    public void ButtonClicked()
    {
        // If the gamestate allows for a button to be selected
        if(mgc.state == GameState.SelectButton1 || mgc.state == GameState.SelectButton2)
        {
            //Change the button color to yellow
            ChangeButtonColor(Color.yellow);

            // Tell the controller which button was selected and advance the game state
            if(mgc.state == GameState.SelectButton1)
            {
                mgc.selectedButton1 = this;
                mgc.UpdateGameState(GameState.SelectButton2);
            }

            // Tell the controller which button was selected and advance the game state
            else if (mgc.state == GameState.SelectButton2 && mgc.selectedButton1 != this)
            {
                mgc.selectedButton2 = this;
                mgc.UpdateGameState(GameState.TestButtons);
            }
        }
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
