using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private ArrowObject UArrow;
    [SerializeField] private ArrowObject DArrow;
    [SerializeField] private ArrowObject LArrow;
    [SerializeField] private ArrowObject RArrow;

    [SerializeField] private Transform promptWindow;
    [SerializeField] private Canvas gameUI;
    [SerializeField] private Canvas winScreen;

    private List<ArrowObject> keys;
    private int difficulty = 4;
    private int index = 0;
    private int score = 0;
    private bool pauseGame = true;

    [Header("Minigame Config")]
    [Tooltip("Score to Reach")]
    [SerializeField] private int scoreGoal = 10;
    [Tooltip("How many Arrows to start with")]
    [SerializeField] private int startingDifficulty = 4;
    [Tooltip("How many Arrows are added upon completion")]
    [SerializeField] private int increaseDifficulty = 1;

    private InputAction upAction;
    private InputAction downAction;
    private InputAction leftAction;
    private InputAction rightAction;

    private Animator animator;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        upAction = playerInput.actions.FindAction("Up");
        downAction = playerInput.actions.FindAction("Down");
        leftAction = playerInput.actions.FindAction("Left");
        rightAction = playerInput.actions.FindAction("Right");
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        keys = new List<ArrowObject>();
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGame)
        {
            return;
        }
        //Dev Key FOR TESTING
        if (Input.GetKeyDown(KeyCode.F1))
        {
            difficulty++;
            //Debug.Log(difficulty);
            resetKeys();
        }
        if (upAction.WasPressedThisFrame())
        {
            checkInput(Direction.Up);
        }
        else if (downAction.WasPressedThisFrame())
        {
            checkInput(Direction.Down);
        }
        else if (leftAction.WasPressedThisFrame())
        {
            checkInput(Direction.Left);
        }
        else if (rightAction.WasPressedThisFrame())
        {
            checkInput(Direction.Right);
        }
    }

    public void checkInput(Direction dir)
    {
        Debug.Log(dir);
        if (keys[index].pressKey(dir))
        {
            index++;
            animator.SetInteger("Direction", (int)dir);
            animator.SetTrigger("Correct");
            if (index >= keys.Count)
            {
                score++;
                if (score >= scoreGoal)
                {
                    gameWin();
                    return;
                }
                difficulty += increaseDifficulty;
                resetKeys();
            }
        }
        else
        {
            animator.SetTrigger("Fail");
            resetKeys();
            Debug.Log("Incorrect");
        }
    }
    void resetKeys()
    {
        foreach(ArrowObject key in keys){
            Destroy(key);
        }
        Debug.Log(keys.Count);
        keys.Clear();
        for(int i = 0; i < difficulty; i++)
        {
            switch(Random.Range(0, 4))
            {
                case 0:
                    keys.Add(Instantiate(UArrow, promptWindow));
                    break;
                case 1:
                    keys.Add(Instantiate(DArrow, promptWindow));
                    break;
                case 2:
                    keys.Add(Instantiate(LArrow, promptWindow));
                    break;
                case 3:
                    keys.Add(Instantiate(RArrow, promptWindow));
                    break;
                default:
                    Debug.Log("Key Reset ERROR");
                    break;
            }
        }
        index = 0;
    }

    public void resetGame()
    {
        difficulty = startingDifficulty;
        gameUI.gameObject.SetActive(true);
        score = 0;
        resetKeys();
        winScreen.gameObject.SetActive(false);
        pauseGame = false;
    }

    public void continueGame()
    {
        Debug.Log("Go to next Scene");
        //TO DO
    }

    void gameWin()
    {
        gameUI.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
        pauseGame = true;
    }

    void gameLoss()
    {
        //TO DO
    }
}
