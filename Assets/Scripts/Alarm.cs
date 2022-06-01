using System;
using UnityEngine;
using UnityEngine.UI;

// Class to trigger the alarm an hour or 30 minutes before a task is due
public class Alarm : MonoBehaviour
{
    // Sound file to imitate an alarm. File set in the inspector
    [SerializeField] private AudioClip audioFile;

    // The toggle used to check if a task is completed. The alarm will only
    // trigger if the task is not yet completed. Set in the inspector
    [SerializeField] private Toggle taskToggle;

    // The input field to check for the set time
    private InputField inputField;

    // The audio source to play the sound file for the alarm
    private AudioSource audioSource;

    // The boolean value to make sure the audio doesn't trigger multiple times
    private bool triggered; 

    // Initializes inputField and audioSource to the attached input field
    // and audio source. Set the clip of the audio source to audioFile.
    // Start is called before the first frame update.
    private void Start()
    {
        inputField = GetComponent<InputField>();
        audioSource = GetComponent<AudioSource>();
        triggered = false;

        audioSource.clip = audioFile;
    }

    // Checks if it is an hour or 30 minutes before the set time in the input field.
    // Both 12-hour or 24-hour time inputs work. Only triggers when the task
    // does not have a checkmark.
    // Update is called once per frame
    public void Update()
    {
        if (!taskToggle.isOn && !triggered)
        {
            if (DateTime.Now.ToLocalTime().AddHours(1).ToString("h:mm tt") == inputField.text
            || DateTime.Now.ToLocalTime().AddHours(1).ToString("H:mm") == inputField.text
            || DateTime.Now.ToLocalTime().AddMinutes(30).ToString("h:mm tt") == inputField.text
            || DateTime.Now.ToLocalTime().AddMinutes(30).ToString("H:mm") == inputField.text)
            {
                audioSource.Play();
                triggered = true;
            }
            else
            {
                triggered = false;
            }
        }
    }
}
