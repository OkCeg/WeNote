using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to a button to delete the selected note file
public class DeleteNote : MonoBehaviour
{
    // Deletes the both the parent note file object and the corresponding edit screen
    public void Delete()
    {
        Destroy(transform.parent.GetComponent<AccessNote>().editScreen);
        Destroy(transform.parent.gameObject);
    }
}
