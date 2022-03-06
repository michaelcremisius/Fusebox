///By Sean Lee, 1/27/22. contact for help
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitJunctionScript : MonoBehaviour
{
    [Tooltip("Unless this is the first junction, this should be true.\n" +
    "Used to see if a previous junction needs to be correct before this one works.")]
    public bool requiresPrevious = true;

    [Tooltip("The name of the junction before this one.\n" +
    "used to find out if said junction was set properly or not.")]
    public GameObject previousJunction;

    [Tooltip("The name of the Circuit(s) that this will power on.")]
    public GameObject[] nextCircuit;

    [Tooltip("If the junction can power incorrect circuits that don't contribute, this are them.")]
    public GameObject[] falseCircuit;

    [Tooltip("Unless this is the final junction, this list should include ALL future junctions in the circuit.")]
    public GameObject[] futureJunctions;

    [Tooltip("Becomes true when it's rotated correctly.")]
    public bool correctSlot = false;

    [Tooltip("Set this to true if there are false circuits that can be enabled.")]
    public bool falseCircuitsExist = false;

    [Tooltip("The position of the junction that makes correctSlot true")]
    [Range(0,3)]
    public int correctPosition;

    [Tooltip("If there are false circuits, this is the postion that they will be set on.")]
    [Range(0, 3)]
    public int falsePosition;

    [Tooltip("The starting position of the junction.")]
    [Range(0, 3)]
    public int startPosition;

    private int currentPosition;

    private CircuitGameController GC;

    public void Start()
    {
        currentPosition = startPosition;
        GC = FindObjectOfType<CircuitGameController>();
    }

    /// <summary>
    /// This is where the magic happens.
    /// BUG NOTICE: With how I have things set up currently, if you power a circuit, power the next circuit, and then unpower the first, the second will stay powered.
    /// I know it's like this and I know why it's like this but it's 10 pm the night before we need this so it should be fine. This is for proof of concept anyway.
    /// </summary>
    public void TurnJunction()
    {
        GC.PlayTurnSound();
        //If a previous junction is off, Let junction rotate but don't turn circuit on.
        if (requiresPrevious && !previousJunction.GetComponent<CircuitJunctionScript>().GetBoolState())
        {
            //Increase number.
            GC.IncreasePressCount();
            //Rotate
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90f);
            //Change Position.
            ChangePosition();
        }

        if ((requiresPrevious && previousJunction.GetComponent<CircuitJunctionScript>().GetBoolState()) || !requiresPrevious)
        {
            //After pushing the button, increase the press count. This is useless now but when we need scores, this will be good to have, so I'm writing it in now.
            GC.IncreasePressCount();
            //First off, rotate 90 degrees. Won't matter if it's above 360 unless you put an autoclicker on it and leave it be for 2 weeks :p
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90f);
            //Next, change the position
            ChangePosition();
            //if there are false circuits, check for them first.
            if (falseCircuitsExist)
            {
                //turn false on
                if (currentPosition == falsePosition)
                {
                    for (int i = 0; i < falseCircuit.Length; i++)
                    {
                        falseCircuit[i].GetComponent<CircuitScript>().TurnOn();
                    }
                }
                //turn false off
                else if (currentPosition == falsePosition + 1 || (currentPosition == 0 && falsePosition == 3))
                {
                    for (int i = 0; i < falseCircuit.Length; i++)
                    {
                        falseCircuit[i].GetComponent<CircuitScript>().TurnOff();
                    }
                }
            }

            //Now that false circuits are taken care of, time for actual circuits.
            if (currentPosition == correctPosition)
            {
                //turn real on
                for (int i = 0; i < nextCircuit.Length; i++)
                {
                    nextCircuit[i].GetComponent<CircuitScript>().TurnOn();
                }
                if (futureJunctions.Length > 0)
                {

                    for (int i = 0; i < futureJunctions.Length; i++) futureJunctions[i].GetComponent<CircuitJunctionScript>().CheckJunction();
                }
                correctSlot = true;
            }
            //turn real off
            else if (currentPosition == correctPosition + 1 || (currentPosition == 0 && correctPosition == 3))
            {
                //toggle correct circuits. This should set them to off.
                for (int i = 0; i < nextCircuit.Length; i++)
                {
                    nextCircuit[i].GetComponent<CircuitScript>().TurnOff();
                }
                correctSlot = false;
                DisableFutureJunctions();
            }
            //lastly, try to win the game. This checks to see if all necessary circuits are lit up.
            GC.TryWin();
        }
    }

    /// <summary>
    /// If a previous Junction has just been activated, it will run this. Used to turn on multiple junctions in a circuit at once.
    /// </summary>
    public void CheckJunction()
    {
        if (requiresPrevious && previousJunction.GetComponent<CircuitJunctionScript>().GetBoolState())
        {
            //Check to see if our position is right
            if (currentPosition == correctPosition)
            {
                //toggle correct circuits. This should set them to on.
                for (int i = 0; i < nextCircuit.Length; i++)
                {
                    nextCircuit[i].GetComponent<CircuitScript>().TurnOn();
                }
                correctSlot = true;
            }
            //check to see if our position is on a false junction.
            else if (currentPosition == falsePosition)
            {
                for (int i = 0; i < falseCircuit.Length; i++)
                {
                    falseCircuit[i].GetComponent<CircuitScript>().TurnOn();
                }
                correctSlot = false;
            }
            else
            {
                correctSlot = false;
            }
            GC.TryWin();
        }
    }

    /// <summary>
    /// This disables the state of all future junctions.
    /// </summary>
    public void DisableFutureJunctions()
    {
        for (int i = 0; i < futureJunctions.Length; i++)
        {
            futureJunctions[i].GetComponent<CircuitJunctionScript>().correctSlot = false;
            print("Just tried to set " + futureJunctions[i] + " to false");
            futureJunctions[i].GetComponent<CircuitJunctionScript>().DisableRealCircuits();
            futureJunctions[i].GetComponent<CircuitJunctionScript>().DisableFalseCircuits();
        }
    }

    /// <summary>
    /// Name should be self explanatory
    /// </summary>
    public void DisableRealCircuits()
    {
        for (int i = 0; i < this.nextCircuit.Length; i++)
        {
            nextCircuit[i].GetComponent<CircuitScript>().TurnOff();
        }
    }

    /// <summary>
    /// Name should be self explanatory
    /// </summary>
    public void DisableFalseCircuits()
    {
        for (int i = 0; i < this.falseCircuit.Length; i++)
        {
            falseCircuit[i].GetComponent<CircuitScript>().TurnOff();
        }
    }

    /// <summary>
    /// This increments the position by one. Resets it if it overflows
    /// </summary>
    public void ChangePosition()
    {
        if (currentPosition == 3) currentPosition = 0;
        else currentPosition++;
    }

    public bool GetBoolState()
    {
        return correctSlot;
    }


}
