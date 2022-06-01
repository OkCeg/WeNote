using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class to correctly implement toggles
public class ManageAccessNote : MonoBehaviour
{
    // Toggler objects to find whether the toggle is on or not
    private Toggler togglerDelete;
    private Toggler togglerRename;

    // Initialize togglerDelete and togglerRename by finding the corresponding tags.
    // Start is called before the first frame update
    private void Start()
    {
        togglerDelete = GameObject.FindGameObjectWithTag("DeleteToggle").GetComponent<Toggler>();
        togglerRename = GameObject.FindGameObjectWithTag("RenameToggle").GetComponent<Toggler>();
    }

    // Toggles the note deletion button and the renaming input field
    private void Update()
    {
        transform.GetChild(0).GetComponent<InputField>().enabled = togglerRename.toggleOnRename;
        transform.GetChild(1).gameObject.SetActive(togglerDelete.toggleOnDelete);
    }
}
