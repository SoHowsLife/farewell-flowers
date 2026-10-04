using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    [Header("Components References")]
    [SerializeField] private Word selectedWord;
    [SerializeField] private GameObject spellingUI;
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI charlotteDisplay;
    //[SerializeField] private TextMeshProUGUI timerDisplay;
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject winScreen;

    [Header("Minigame Config")]
    [Tooltip("How long the minigame will take.")]
    //[SerializeField] private float timerStart = 120.0f;
    [SerializeField] private int targetScore = 10;

    private bool pauseGame = true;
    //private float timeRemaining;
    private bool timerPaused = true;
    private int score = 0;

    [Header("Charlotte Config")]
    [SerializeField] private float charlotteStart = 4.0f;
    [SerializeField] private float charlotteRange = 1.0f;
    private int charlotteScore = 0;
    private float charlotteTimer;


    //private int mistakes = 0;
    //[SerializeField] private int allowedMistakes = 5;

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
                        scoreDisplay.text = string.Format("Your Score : {0}", score);
                        if (score == targetScore) gameWin();
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
            //timeRemaining -= Time.deltaTime;
            charlotteTimer -= Time.deltaTime;

            //float minutes = Mathf.FloorToInt(timeRemaining / 60);
            //float seconds = Mathf.FloorToInt(timeRemaining % 60);

            //timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            /*if (timeRemaining <= 0)
            {
                if (score > charlotteScore)
                {
                    gameWin();
                }
                else
                {
                    gameLoss();
                }
                //playerMistake();
                return;
            }
            */
            if (charlotteTimer <= 0)
            {
                charlotteScore++;
                charlotteDisplay.text = string.Format("Charlotte's Score : {0}", charlotteScore);
                charlotteTimer = Random.Range(charlotteStart, charlotteRange);
                if (charlotteScore == targetScore)
                {
                    gameLoss();
                    return;
                }
            }
        }

    }

    //void playerMistake()
    //{
    //    mistakes++;
    //    mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);
    //    if (mistakes >= allowedMistakes)
    //    {
    //        gameLoss();
    //    }
    //}

    void resetWord()
    {
        selectedWord.changeText(getRandomWord());
    }

    public void resetGame()
    {
        score = 0;
        charlotteScore = 0;
        //mistakes = 0;

        scoreDisplay.text = string.Format("Your Score : {0}", score);
        charlotteDisplay.text = string.Format("Charlotte's Score : {0}", charlotteScore);
        //mistakeDisplay.text = string.Format("Mistakes : {0}", mistakes);

        charlotteTimer = Random.Range(charlotteStart, charlotteRange);

        //timeRemaining = timerStart;
        //float minutes = Mathf.FloorToInt(timeRemaining / 60);
        //float seconds = Mathf.FloorToInt(timeRemaining % 60);
        //timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        spellingUI.SetActive(true);
        resetWord();
        timerPaused = true;
        pauseGame = false;
        failScreen.SetActive(false);
        winScreen.SetActive(false);
    }
    public void Proceed()
    {
        selectedWord.gameObject.SetActive(false);
    }

    void gameLoss()
    {
        pauseGame = true;
        spellingUI.SetActive(false);
        failScreen.SetActive(true);
        //timerDisplay.text = "00:00";
    }

    void gameWin()
    {
        pauseGame = true;
        spellingUI.SetActive(false);
        winScreen.SetActive(true);
        //timerDisplay.text = "00:00";
    }

    string getRandomWord()
    {
        return WordGenerator.generateWord();
    }
}
