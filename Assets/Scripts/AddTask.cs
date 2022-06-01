using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class that adds a bullet point, number list, or checkmarkable task when a user presses enter.
public class AddTask : MonoBehaviour
{
    // The bullet point prefab
    private GameObject bulletPoint;

    // The numbered list prefab
    private GameObject numberedList;

    // The checkmarkable task prefab
    private GameObject task;

    // The parent object to add the input fields to
    private GameObject content;

    // Initializes the value of the bullet point, number list, task, and content
    private void Start()
    {
        bulletPoint = Resources.Load("BulletPoint") as GameObject;
        numberedList = Resources.Load("NumberList") as GameObject;
        task = Resources.Load("Task") as GameObject;
        content = GameObject.FindGameObjectWithTag("Content");
    }

    // Checks whether the enter key is pressed down to create a new note below the
    // selected input field. Update is called once per frame.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && Selected.selectedText != null && 
            gameObject == Selected.selectedText.gameObject.transform.parent.gameObject)
        {
            NewNote();
        }
    }

    // Creates a new note below the object this script is attached to
    // based on what type of tag this object has. Numbered lists update
    // the next note to the next number in the sequence.
    private void NewNote()
    {
        if (gameObject.CompareTag("BulletPoint"))
        {
            Instantiate(bulletPoint, content.transform).transform.
                SetSiblingIndex(gameObject.transform.GetSiblingIndex() + 1);
        }
        else if (gameObject.CompareTag("NumberList"))
        {
            GameObject number = Instantiate(numberedList, content.transform);
            number.transform.SetSiblingIndex(gameObject.transform.GetSiblingIndex() + 1);

            string thisNumber = transform.GetChild(0).GetComponent<Text>().text;
            number.transform.GetChild(0).GetComponent<Text>().text =
                (int.Parse(thisNumber.Substring(0, thisNumber.IndexOf(".")))+1) + ".";
        }
        else if (gameObject.CompareTag("Task"))
        {
            Instantiate(task, content.transform).transform.
                SetSiblingIndex(gameObject.transform.GetSiblingIndex() + 1);
        }
    }
}