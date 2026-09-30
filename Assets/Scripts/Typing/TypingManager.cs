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
    [SerializeField] private Canvas failScreen;
    [SerializeField] private Canvas winScreen;


    [SerializeField] private float timerStart = 5.0f;
    private bool pauseGame = true;
    private float timeRemaining;
    private bool timerPaused = true;
    private int score = 0;
    private int mistakes = 0;

    [SerializeField] private int allowedMistakes = 5;
    [SerializeField] private int scoreGoal = 5;

    void Start()
    {
        resetGame();
    }
    // Update is called once per frame
    void Update()
    {
        if (pauseGame)
        {
            return;
        }
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
                        resetWord();
                        scoreDisplay.text = string.Format("Score : {0}", score);
                        if (score >= scoreGoal)
                        {
                            gameWin();
                        }
                        return;
                    }
                }
                else
                {
                    playerMistake();
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
                resetWord();
                playerMistake();
            }
        }
    }

    void playerMistake()
    {
        mistakes++;
        mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);
        if (mistakes >= allowedMistakes)
        {
            gameLoss();
        }
    }

    void resetWord()
    {
        timerPaused = true;
        timeRemaining = timerStart;

        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerDisplay.text = string.Format("00:{0:00}", seconds);
        selectedWord.changeText(getRandomWord());
    }

    public void resetGame()
    {
        score = 0;
        mistakes = 0;
        scoreDisplay.text = string.Format("Score : {0}", score);
        mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);
        selectedWord.gameObject.SetActive(true);
        resetWord();
        pauseGame = false;
        failScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
    }

    void gameLoss()
    {
        pauseGame = true;
        selectedWord.gameObject.SetActive(false);
        failScreen.gameObject.SetActive(true);
    }

    void gameWin()
    {
        pauseGame = true;
        selectedWord.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
    }

    string getRandomWord()
    {
        return WordGenerator.generateWord();
    }
}
