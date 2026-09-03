using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField] private Word selectedWord;
    private int score = 0;
    private int mistakes = 0;
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
                if (selectedWord.checkLetter(input[0]))
                {
                    if (selectedWord.checkComplete())
                    {
                        score++;
                        selectedWord.changeText(getRandomWord());
                    }
                }
                else
                {
                    mistakes++;
                }
            }
        }
    }

    string getRandomWord()
    {
        return "TODO";
    }
}
