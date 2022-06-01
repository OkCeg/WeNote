using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class that changes the title color gradually
public class TitleColor : MonoBehaviour
{
    // The RGB value of the title color
    private int r = 255;
    private int g = 0;
    private int b = 0;

    // The value that determines the lowest value of RGB
    private const int lighten = 0;

    // How quickly the colors should change
    private const int colorSpeed = 1;

    // How many frames until next color change
    private const int colorChangeFrames = 2;

    // Frames since last color change
    private int lastColorChangeFrames = 0;

    // The RGB component being changed currently
    private string centeredColor = "r";

    // The text component attached to the object
    private Text text;

    // Initialize text to the text component in the object
    // Start is called before the first frame update.
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update the color of the title using the RGB value.
    // Update is called once per frame.
    private void Update()
    {
        if (lastColorChangeFrames > colorChangeFrames)
        {
            UpdateColor();
            text.color = new Color(r / 255f, g / 255f, b / 255f);
            lastColorChangeFrames = 0;
        }

        lastColorChangeFrames++;
    }

    // Updates the RGB value
    private void UpdateColor()
    {
        switch (centeredColor)
        {
            case "r":
                if (b > lighten)
                {
                    b -= colorSpeed;
                }
                else
                {
                    g += colorSpeed;
                    b = lighten;
                }
                if (g >= 255)
                {
                    centeredColor = "g";
                    g = 255;
                }
                break;
            case "g":
                if (r > lighten)
                {
                    r -= colorSpeed;
                }
                else
                {
                    b += colorSpeed;
                    r = lighten;
                }
                if (b >= 255)
                {
                    centeredColor = "b";
                    b = 255;
                }
                break;
            case "b":
                if (g > lighten)
                {
                    g -= colorSpeed;
                }
                else
                {
                    r += colorSpeed;
                    g = lighten;
                }
                if (r >= 255)
                {
                    centeredColor = "r";
                    r = 255;
                }
                break;
            default:
                Debug.Log("how?");
                break;
        }
    }
}