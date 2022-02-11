///By Sean Lee, 1/27/22. contact for help
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitScript : MonoBehaviour
{
    //A simple boolean for whether or not the circuit is powered. Starts false by default.
    private bool powered;

    private Color OnColor = new Color(1f, 1f, .6f, 1f);
    private Color OffColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        powered = false;
    }

    /// <summary>
    /// when powered, set all children to a particular color
    /// </summary>
    public void TurnOn()
    {
        powered = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = OnColor;
        }
    }

    /// <summary>
    /// Ditto to above, but when not powered
    /// </summary>
    public void TurnOff()
    {
        powered = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = OffColor;
        }
    }

    /// <summary>
    /// Public void to toggle the powered boolean and set the colors
    /// </summary>
    public void TogglePower()
    {
        
        powered = !powered;
        //print("TogglePower in CircuitScript on " + this.name + ", set to " + powered);
        if (powered) TurnOn();
        if (!powered) TurnOff();
    }
}
