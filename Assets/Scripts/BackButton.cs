using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Goes back to the previous screen
public class BackButton : MonoBehaviour
{
    // Disables the current screen to go back to the previous screen
    // and disable the selected text
    public void Back()
    {
        transform.parent.gameObject.SetActive(false);
        Selected.selectedText = null;
    }
}
