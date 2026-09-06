using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [SerializeField] private Word selectedWord;
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI mistakeDisplay;
    private int score = 0;
    private int mistakes = 0;

    void Start()
    {
        selectedWord.changeText(getRandomWord());
    }
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
                        scoreDisplay.text = string.Format("Score : {0}", score);
                    }
                }
                else
                {
                    mistakes++;
                    mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);
                }
            }
        }
    }

    string getRandomWord()
    {
        return WordGenerator.generateWord();
    }
}
