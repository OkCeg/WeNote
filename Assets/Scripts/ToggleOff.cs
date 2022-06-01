using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class that turn the toggle off on the first frame
public class ToggleOff : MonoBehaviour
{
    // Turn off the toggle component on the first frame.
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Toggle>().isOn = false;
    }
}
