using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeNotes : MonoBehaviour
{
    // The screen to open. Set in the inspector
    [SerializeField] private GameObject notesScreen;

    // Open the notes screen. The note screen will be on top of the
    // 
    public void Open()
    {
        notesScreen.SetActive(true);
    }
}
