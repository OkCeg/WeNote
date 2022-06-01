using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to fix resolution problems and keep the aspect ratio constant
public class Resolution : MonoBehaviour
{
    // The frames before the next resolution update
    private int framesUntil = 2;

    // The frames to count when to change the resolution
    private int frames = 0;

    // Set the default screen size resolution.
    // Awake is called before Start, which is called before the first frame update
    private void Awake()
    {
        Screen.SetResolution(600, 800, false);
    }

    // Match the height of the resolution to the equivalent ratio of the original
    // size resolution based on the changed width. If the window height is greater than
    // the screen height, change the width instead.
    // Update is called once per frame
    void Update()
    {
        if (frames >= framesUntil)
        {
            if (Screen.height != (int)(Screen.width * 4f / 3))
            {
                if ((int)(Screen.width * 4f / 3) > Screen.currentResolution.height)
                {
                    Screen.SetResolution((int)(3f / 4 * Screen.height), Screen.height, false);
                }
                else
                {
                    Screen.SetResolution(Screen.width, (int)(Screen.width * 4f / 3), false);
                }
            }
            frames = 0;
        }
        frames++;
    }
}
