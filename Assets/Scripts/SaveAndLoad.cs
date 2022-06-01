using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

// The class that saves and loads the notes properly
// Binary Formatter tutorial by Brackeys
public class SaveAndLoad : MonoBehaviour
{
    // The weekly report info to be saved. Set in the inspector
    [SerializeField] private GameObject reportInfo;

    // The object that holds all the notes. Set in the inspector
    [SerializeField] private GameObject content;

    // The object that holds all the edit screens. Set in the inspector
    [SerializeField] private GameObject editScreenHolder;

    // The corresponding prefabs that will be used to load back the objects.
    // Set in the inspector
    [SerializeField] private GameObject accessNote;
    [SerializeField] private GameObject editScreen;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private GameObject numberList;
    [SerializeField] private GameObject task;

    // Fixing the hierarchy by changing the caret sibling position
    // Update is called once per frame
    private void Update()
    {
        GameObject[] allObj = GameObject.FindObjectsOfType<GameObject>(true) as GameObject[];
        foreach (GameObject obj in allObj)
        {
            foreach (Transform child in obj.transform)
            {
                if (child.name.Contains("Input Caret") && child.GetSiblingIndex() != obj.transform.childCount - 1)
                {
                    child.SetSiblingIndex(obj.transform.childCount - 1);
                }
            }
        }
    }

    // Saves the canvas that holds all the user edits into a file.
    // Called when the application is quit
    private void OnApplicationQuit()
    {
        SavedInfo info = new SavedInfo();

        // save report info
        info.reportText = reportInfo.transform.GetChild(1).GetChild(2).GetComponent<Text>().text;
        info.reportDate = reportInfo.GetComponent<WeeklyReport>().lastSavedDate.ToString();

        // save note name info
        foreach (Transform child in content.transform)
        {
            info.noteNames.Add(child.GetChild(0).GetComponent<InputField>().text);
        }

        // save edit screen info
        List<GameObject> editScreens = new List<GameObject>();
        foreach (Transform child in editScreenHolder.transform)
        {
            editScreens.Add(child.gameObject);
        }

        Transform[] contents = new Transform[editScreens.Count];
        for (int i = 0; i < contents.Length; i++)
        {
            contents[i] = editScreens[i].transform.GetChild(0).GetChild(0);
            info.editInfo.Add(new string[contents[i].childCount, 5]);

            foreach (Transform child in contents[i])
            {
                int index = child.GetSiblingIndex();
                info.editInfo[i][index, 0] = child.tag;
                info.editInfo[i][index, 1] = child.GetComponent<InputField>().text;
                info.editInfo[i][index, 4] = child.transform.GetChild(2).GetComponent<Text>().fontStyle.ToString();

                if (child.CompareTag("Task"))
                {
                    info.editInfo[i][index, 2] = child.GetChild(0).GetComponent<Toggle>().isOn.ToString();
                    info.editInfo[i][index, 3] = child.GetChild(3).GetChild(2).GetComponent<Text>().text;
                }
                else if (child.CompareTag("NumberList"))
                {
                    info.editInfo[i][index, 2] = child.GetChild(0).GetComponent<Text>().text;
                }
            }
        }

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/saved.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, info);
        stream.Close();
    }

    // Loads back all the saved data if the first path exists
    // Awake is called before Start, which is called before the first frame update
    private void Awake()
    {
        string path = Application.persistentDataPath + "/saved.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);
            SavedInfo info = formatter.Deserialize(stream) as SavedInfo;
            stream.Close();

            // load report info
            reportInfo.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = info.reportText;
            reportInfo.GetComponent<WeeklyReport>().lastSavedDate = DateTime.Parse(info.reportDate);

            // load note name info
            GameObject[] editScreens = new GameObject[info.noteNames.Count];
            for (int i = 0; i < info.noteNames.Count; i++)
            {
                editScreens[i] = Instantiate(editScreen, editScreenHolder.transform);
                GameObject newNote = Instantiate(accessNote, content.transform);
                newNote.GetComponent<AccessNote>().editScreen = editScreens[i];
                newNote.transform.GetChild(0).GetComponent<InputField>().text = info.noteNames[i];
            }

            // load edit screen info
            for (int i = 0; i < info.editInfo.Count; i++)
            {
                Transform content = editScreens[i].transform.GetChild(0).GetChild(0);
                for (int j = 0; j < info.editInfo[i].GetLength(0); j++)
                {
                    switch (info.editInfo[i][j, 0])
                    {
                        case ("BulletPoint"):
                            GameObject bP = Instantiate(bulletPoint, content);
                            bP.GetComponent<InputField>().text = info.editInfo[i][j, 1];
                            FontStyle bPFont = bP.transform.GetChild(2).GetComponent<Text>().fontStyle;
                            switch (info.editInfo[i][j, 4])
                            {
                                case ("Normal"):
                                    bPFont = FontStyle.Bold;
                                    break;
                                case ("Bold"):
                                    bPFont = FontStyle.Normal;
                                    break;
                                case ("Italic"):
                                    bPFont = FontStyle.BoldAndItalic;
                                    break;
                                case ("BoldAndItalic"):
                                    bPFont = FontStyle.Italic;
                                    break;
                                default:
                                    Debug.Log("font error");
                                    break;
                            }
                            break;
                        case ("NumberList"):
                            GameObject nL = Instantiate(numberList, content);
                            nL.GetComponent<InputField>().text = info.editInfo[i][j, 1];
                            FontStyle nLFont = nL.transform.GetChild(2).GetComponent<Text>().fontStyle;
                            switch (info.editInfo[i][j, 4])
                            {
                                case ("Normal"):
                                    nLFont = FontStyle.Bold;
                                    break;
                                case ("Bold"):
                                    nLFont = FontStyle.Normal;
                                    break;
                                case ("Italic"):
                                    nLFont = FontStyle.BoldAndItalic;
                                    break;
                                case ("BoldAndItalic"):
                                    nLFont = FontStyle.Italic;
                                    break;
                                default:
                                    Debug.Log("font error");
                                    break;
                            }
                            nL.transform.GetChild(0).GetComponent<Text>().text = info.editInfo[i][j, 2];
                            break;
                        case ("Task"):
                            GameObject t = Instantiate(task, content);
                            t.GetComponent<InputField>().text = info.editInfo[i][j, 1];
                            t.GetComponent<InputField>().text = info.editInfo[i][j, 1];
                            FontStyle tFont = t.transform.GetChild(2).GetComponent<Text>().fontStyle;
                            switch (info.editInfo[i][j, 4])
                            {
                                case ("Normal"):
                                    tFont = FontStyle.Bold;
                                    break;
                                case ("Bold"):
                                    tFont = FontStyle.Normal;
                                    break;
                                case ("Italic"):
                                    tFont = FontStyle.BoldAndItalic;
                                    break;
                                case ("BoldAndItalic"):
                                    tFont = FontStyle.Italic;
                                    break;
                                default:
                                    Debug.Log("font error");
                                    break;
                            }
                            t.transform.GetChild(0).GetComponent<Toggle>().isOn = Boolean.Parse(info.editInfo[i][j, 2]);
                            t.transform.GetChild(3).GetChild(2).GetComponent<Text>().text = info.editInfo[i][j, 3];
                            break;
                        default:
                            Debug.Log("how? loading tag error");
                            break;
                    }
                }
            }
        }
    }
}
