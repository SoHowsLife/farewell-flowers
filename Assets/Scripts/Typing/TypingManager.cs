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
    [SerializeField] private TextMeshProUGUI timerDisplay;

    [SerializeField] private float timerStart = 5.0f;
    private float timeRemaining;
    private bool timerPaused = true;
    private int score = 0;
    private int mistakes = 0;

    void Start()
    {
        resetTyping();
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
                timerPaused = false;
                if (selectedWord.checkLetter(input[0]))
                {
                    if (selectedWord.checkComplete())
                    {
                        score++;
                        resetTyping();
                        scoreDisplay.text = string.Format("Score : {0}", score);
                        return;
                    }
                }
                else
                {
                    mistakes++;
                    mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);
                }
            }
        }
        if (!timerPaused)
        {
            timeRemaining -= Time.deltaTime;

            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerDisplay.text = string.Format("00:{0:00}", seconds);
            if (timeRemaining <= 0)
            {
                resetTyping();
                mistakes++;
                mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);
            }
        }
    }

    void resetTyping()
    {
        timerPaused = true;
        timeRemaining = timerStart;

        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerDisplay.text = string.Format("00:{0:00}", seconds);
        selectedWord.changeText(getRandomWord());
    }
    string getRandomWord()
    {
        return WordGenerator.generateWord();
    }
}
