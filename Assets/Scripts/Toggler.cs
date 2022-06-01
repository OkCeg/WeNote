using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to a toggles to activate delete butons or renaming input fields
public class Toggler : MonoBehaviour
{
    // Boolean to check if the toggle is active for delete buttons
    public bool toggleOnDelete;

    // Boolean to check if the toggle is active for renaming input fields
    public bool toggleOnRename;

    // Initializes toggleOnDelete and toggleOnRename to false.
    // Start is called before the first frame update
    private void Start()
    {
        toggleOnDelete = false;
        toggleOnRename = false;
    }

    // Swap the delete toggle
    public void ToggleDelete()
    {
        toggleOnDelete = !toggleOnDelete;
    }

    // Swap the rename toggle
    public void ToggleRename()
    {
        toggleOnRename = !toggleOnRename;
    }
}
