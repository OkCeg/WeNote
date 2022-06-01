using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class to only display the image and text if the search note input field is focused
public class ActivateIfFocus : MonoBehaviour
{
    // The input field for the search note field. Set in inspector
    [SerializeField] private InputField inputField;

    // Hides the search results if the search note field is not focused.
    // Update is called once per frame.
    private void Update()
    {
        for (int i = 0; i <= 3; i++)
        {
            transform.GetChild(i).gameObject.SetActive(inputField.isFocused);
        }
    }
}
