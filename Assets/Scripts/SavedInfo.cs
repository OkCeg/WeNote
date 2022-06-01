using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

// Class that is able to save the information of the notes app
[System.Serializable]
public class SavedInfo
{
    // The weekly report infos to be saved
    public string reportText, reportDate;

    // The list of note names to be saved
    public List<string> noteNames;

    // The list of a 2D array of edit screen information. The list elements corresponds
    // to the each note's edit screen, the first array element corresponds to the list of notes
    // in that edit screen, and the second array element correspond to the note info:
    // type of note, task description, toggle or number in number list, due date, and font style.
    public List<string[,]> editInfo;

    // The constructor to initialize the fields
    public SavedInfo()
    {
        reportText = "";
        reportDate = "";
        noteNames = new List<string>();
        editInfo = new List<string[,]>();
    }
}
