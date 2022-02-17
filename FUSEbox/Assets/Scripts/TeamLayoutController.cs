/*****************************************************************************
// File Name :         TeamLayoutController.cs
// Author :            Lucas Johnson
// Creation Date :     February 16, 2022
//
// Brief Description : A C# script that controls the displaying of different
                       layouts for the team display scenes.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLayoutController : MonoBehaviour
{
    /// <summary>
    /// Changes the layout of the page based on which button is pressed
    /// </summary>
    /// <param name="layout">Layout to be activated</param>
    public void ChangeLayout(GameObject layout)
    {
        // Disable all the children
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Activate the desired layout
        layout.SetActive(true);
    }
}
