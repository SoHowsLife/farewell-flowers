using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [Header("Components References")]
    [SerializeField] private Word selectedWord;
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI charlotteDisplay;
    [SerializeField] private TextMeshProUGUI timerDisplay;
    [SerializeField] private Canvas failScreen;
    [SerializeField] private Canvas winScreen;

    [Header("Minigame Config")]
    [Tooltip("How long the minigame will take.")]
    [SerializeField] private float timerStart = 120.0f;

    private bool pauseGame = true;
    private float timeRemaining;
    private bool timerPaused = true;
    private int score = 0;

    [Header("Charlotte Config")]
    [SerializeField] private float charlotteStart = 4.0f;
    [SerializeField] private float charlotteRange = 1.0f;
    private int charlotteScore = 0;
    private float charlotteTimer;

    void Start()
    {
        resetGame();
    }
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
                        scoreDisplay.text = string.Format("Your Score : {0}", score);
                        return;
                    }
                }
                //else
                //{
                //    playerMistake();
                //}
            }
        }
        if (!timerPaused)
        {
            timeRemaining -= Time.deltaTime;
            charlotteTimer -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (timeRemaining <= 0)
            {
                if (score > charlotteScore)
                {
                    gameWin();
                }
                else
                {
                    gameLoss();
                }
                return;
            }
            if (charlotteTimer <= 0)
            {
                charlotteScore++;
                charlotteDisplay.text = string.Format("Charlotte's Score : {0}", charlotteScore);
                charlotteTimer = charlotteStart + Random.Range(-charlotteRange, charlotteRange);
            }
        }
    }

    void resetWord()
    {
        selectedWord.changeText(getRandomWord());
    }

    public void resetGame()
    {
        score = 0;
        charlotteScore = 0;

        scoreDisplay.text = string.Format("Your Score : {0}", score);
        charlotteDisplay.text = string.Format("Charlotte's Score : {0}", charlotteScore);

        charlotteTimer = charlotteStart + Random.Range(-charlotteRange, charlotteRange);

        timeRemaining = timerStart;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        selectedWord.gameObject.SetActive(true);
        resetWord();
        timerPaused = true;
        pauseGame = false;
        failScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
    }

    public void continueGame()
    {
        Debug.Log("Go to next Scene");
        //TO DO
    }

    void gameLoss()
    {
        pauseGame = true;
        selectedWord.gameObject.SetActive(false);
        failScreen.gameObject.SetActive(true);
        timerDisplay.text = "00:00";
    }

    void gameWin()
    {
        pauseGame = true;
        selectedWord.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
        timerDisplay.text = "00:00";
    }

    string getRandomWord()
    {
        return WordGenerator.generateWord();
    }
}
