using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The class to search through the notes to find a user-input phrase
public class Search : MonoBehaviour
{
    // The input field to enter the search
    private InputField inputField;

    // The text to be updated to show the search result
    [SerializeField] private Text showText;

    // Initializes the input field
    // Start is called before the first frame update
    private void Start()
    {
        inputField = GetComponent<InputField>();
    }

    // Finds and returns an array of all objects with the tag "TextToSearch"
    public List<Text> GetArray()
    {
        Text[] allText = FindObjectsOfType<Text>(true);
        List<Text> textWithTag = new List<Text>();

        foreach (Text text in allText)
        {
            if (text.gameObject.CompareTag("TextToSearch"))
            {
                textWithTag.Add(text);
            }
        }

        return textWithTag;
    }

    // Displays the list of messages that contains the case insensitive user-input phrase
    public void ReturnSearch()
    {
        List<Text> arr = new List<Text>();
        List<Text> validText = GetArray();
        foreach (Text text in validText)
        {
            if (text.text.ToUpper().Contains(inputField.text.ToUpper()) && inputField.text != "")
            {
                arr.Add(text);
            }
        }

        showText.text = "";
        for (int i = 0; i < arr.Count-1; i++)
        {
            showText.text += arr[i].text + ", ";
        }
        if (arr.Count > 0)
        {
            showText.text += arr[arr.Count - 1].text;
        }
    }
}
