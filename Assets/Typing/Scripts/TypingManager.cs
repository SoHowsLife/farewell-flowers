using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string textEntry = "";

    // Update is called once per frame
    void Update()
    {
        string input = Input.inputString;
        if (!input.Equals(""))
        {
            if (input.Equals("\b"))
            {
                textEntry.Remove(0, textEntry.Length - 1);
            }
            else
            {
                textEntry = textEntry + input;
            }
            text.text = textEntry;
        }
    }
}
