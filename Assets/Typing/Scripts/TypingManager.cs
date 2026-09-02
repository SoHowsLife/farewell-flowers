using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField] private Word selectedWord;
    // Update is called once per frame
    void Update()
    {
        string input = Input.inputString.ToLower();
        if (!input.Equals(""))
        {
            if (input.Equals("\b"))
            {
                selectedWord.backspaceLetter();
            }
            else
            {
                selectedWord.checkLetter(input[0]);
            }
        }
    }
}
