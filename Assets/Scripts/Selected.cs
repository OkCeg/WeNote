using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Checks if the input field is selected or not
public class Selected : MonoBehaviour
{
    // The currently selected text
    public static Text selectedText;

    // The corresponding input field
    private InputField inputField;

    // Initializes selectedText to null and inputField to its InputField component.
    // Start is called before the first frame update.
    private void Start()
    {
        selectedText = null;
        inputField = GetComponent<InputField>();
    }

    // Updates the selected text based on if the input field is focused or not.
    // Update is called once per frame.
    private void Update()
    {
        if (inputField.isFocused)
        {
            selectedText = gameObject.transform.GetChild(2).GetComponent<Text>();
        }
    }
}
