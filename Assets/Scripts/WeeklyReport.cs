using System;
using UnityEngine;
using UnityEngine.UI;

// The class that shows a weekly report on how many tasks the user has completed
public class WeeklyReport : MonoBehaviour
{
    // Stores when the last weekly report was. Default to DateTime.Now
    public DateTime lastSavedDate;

    // The gameobject with the text for the report to update. Set in the inspector
    [SerializeField] private GameObject report;

    // Checks if a new report should be made
    // Start is called before the first frame update
    private void Start()
    {
        if (lastSavedDate == DateTime.MinValue)
        {
            lastSavedDate = DateTime.Now.ToLocalTime();
        }
        else if ((DateTime.Now.ToLocalTime() - lastSavedDate).TotalDays >= 7)
        {
            SaveAndShow();
            lastSavedDate = DateTime.Now.ToLocalTime();
        }
    }

    // Looks through the toggles for task completion and displays the tasks completed
    private void SaveAndShow()
    {
        TaskBlank[] tasks = GameObject.FindObjectsOfType<TaskBlank>(true);
        int completedCount = 0;
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].gameObject.GetComponent<Toggle>().isOn)
            {
                completedCount++;
            }
        }

        Text reportText = report.transform.GetChild(2).GetComponent<Text>();
        reportText.text = "Tasks completed: " + completedCount + "/" + tasks.Length;
        if (tasks.Length == 0)
        {
            reportText.text += "\nAdd more tasks!";
        }
        else if (((float) completedCount)/tasks.Length < 0.5f)
        {
            reportText.text += "\nTry harder!";
        }
        else if (((float)completedCount) / tasks.Length < 0.8f)
        {
            reportText.text += "\nOn the right track!";
        }
        else if (((float)completedCount) / tasks.Length < 1f)
        {
            reportText.text += "\nKeep up the good work!";
        }
        else
        {
            reportText.text += "\nPerfect!";
        }
    }

    // Toggles the report showing
    public void ToggleReport()
    {
        report.SetActive(!report.activeSelf);
    }
}
