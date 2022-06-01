using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to a button to create a new note access button for a new note file
public class AddNote : MonoBehaviour
{
    // The parent object to add the note file button to. Object is set in the inspector
    [SerializeField] private GameObject content;

    // The note file button to add to content. Object is set in the inspector
    [SerializeField] private GameObject noteButtonPrefab;

    // The note editing screen to add to content. Object is set in the inspector
    [SerializeField] private GameObject editScreen;

    // Creates a new button using the note file prefab and attaches it to the scrollable
    // content pane. The edit screen is also created to link it with the note button.
    public void Add()
    {
        Instantiate(noteButtonPrefab, content.transform).GetComponent<AccessNote>().editScreen =
            Instantiate(editScreen, GameObject.FindGameObjectWithTag("EditHolder").transform);
    }
}
