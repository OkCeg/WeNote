using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Opens the corresponding note editing screen
public class AccessNote : MonoBehaviour
{
    // The panel to switch to. Object is set with the creation of the access note button in AddNote.cs
    public GameObject editScreen;

    // Switch the screen
    public void Switch()
    {
        editScreen.SetActive(true);
    }
}
