using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class that manages everything related to a selected note or task
public class EditSelection : MonoBehaviour
{
    // The bullet point prefab. Object is set in the instructor
    public GameObject bulletPoint;

    // The numbered list prefab. Object is set in the instructor
    public GameObject numberedList;

    // The checkmarkable task prefab. Object is set in the instructor
    public GameObject task;

    // The parent object to add the input fields to. Object is set in the inspector
    public GameObject content;

    // Delete the selected text if it exists
    [SerializeField]
    private void Delete()
    {
        if (Selected.selectedText != null)
        {
            Destroy(Selected.selectedText.gameObject.transform.parent.gameObject);
        }
    }

    // Bold the selected text if it exists. Make the text bold and italic if previously italicized.
    [SerializeField]
    private void Bold()
    {
        if (Selected.selectedText != null)
        {
            switch(Selected.selectedText.fontStyle)
            {
                case (FontStyle.Normal):
                    Selected.selectedText.fontStyle = FontStyle.Bold;
                    break;
                case (FontStyle.Bold):
                    Selected.selectedText.fontStyle = FontStyle.Normal;
                    break;
                case (FontStyle.Italic):
                    Selected.selectedText.fontStyle = FontStyle.BoldAndItalic;
                    break;
                case (FontStyle.BoldAndItalic):
                    Selected.selectedText.fontStyle = FontStyle.Italic;
                    break;
                default:
                    Debug.Log("error");
                    break;
            };
        }
    }

    // Italicize the selected text if it exists. Make the text bold and italic if previously bolded.
    [SerializeField]
    private void Italicize()
    {
        if (Selected.selectedText != null)
        {
            switch (Selected.selectedText.fontStyle)
            {
                case (FontStyle.Normal):
                    Selected.selectedText.fontStyle = FontStyle.Italic;
                    break;
                case (FontStyle.Bold):
                    Selected.selectedText.fontStyle = FontStyle.BoldAndItalic;
                    break;
                case (FontStyle.Italic):
                    Selected.selectedText.fontStyle = FontStyle.Normal;
                    break;
                case (FontStyle.BoldAndItalic):
                    Selected.selectedText.fontStyle = FontStyle.Bold;
                    break;
                default:
                    Debug.Log("error");
                    break;
            }
        }
    }

    // Add a bullet point note to the edit screen
    [SerializeField]
    private void AddBulletPoint()
    {
        Instantiate(bulletPoint, content.transform);
    }

    // Add a numbered list to the edit screen
    [SerializeField]
    private void AddNumberedList()
    {
        Instantiate(numberedList, content.transform);
    }

    // Add a checkmarkable task to the edit screen
    [SerializeField]
    private void AddTask()
    {
        Instantiate(task, content.transform);
    }
}
