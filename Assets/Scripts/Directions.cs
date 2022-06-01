using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to show instructions on how to properly use the app
public class Directions : MonoBehaviour
{
    // The current index of the child shown
    private int index;

    // The number of children of the game object
    private int childCount;

    // Boolean to see if the directions should be on or off
    private bool directionsOn;

    // Initializes index to 0, childCount to the number of children in the game object transform,
    // and sets directionsOn to false to hide the directions.
    // Start is called before the first frame update.
    private void Start()
    {
        index = 0;
        childCount = transform.childCount;
        directionsOn = false;
    }

    // Turns on the directions. Called when the directions button is hit
    public void ToggleDirections()
    {
        directionsOn = true;
    }

    // Performs Next() when the user performs a left click and directions should be on.
    // Update is called once per frame.
    private void Update()
    {
        if (directionsOn)
        {
            if (index == 0)
            {
                Next();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Next();
            }
        }
    }

    // Move to the next instruction
    private void Next()
    {
        if (index == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (index > 0 && index <= childCount-1)
        {
            transform.GetChild(index).gameObject.SetActive(true);
            transform.GetChild(index-1).gameObject.SetActive(false);
        }
        else if (index == childCount)
        {
            transform.GetChild(childCount - 1).gameObject.SetActive(false);
            directionsOn = false;
        }

        index++;
        if (index > childCount)
        {
            index = 0;
        }
    }
}
