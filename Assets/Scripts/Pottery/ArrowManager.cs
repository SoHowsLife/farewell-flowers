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

    private List<ArrowObject> keys;
    private int difficulty = 4;
    private int index = 0;

    private InputAction upAction;
    private InputAction downAction;
    private InputAction leftAction;
    private InputAction rightAction;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        upAction = playerInput.actions.FindAction("Up");
        downAction = playerInput.actions.FindAction("Down");
        leftAction = playerInput.actions.FindAction("Left");
        rightAction = playerInput.actions.FindAction("Right");
    }
    // Start is called before the first frame update
    void Start()
    {
        keys = new List<ArrowObject>();
        resetKeys();
    }

    // Update is called once per frame
    void Update()
    {
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
            if (index >= keys.Count)
            {
                difficulty += 1;
                resetKeys();
            }
        }
        else
        {
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

    public void onUp()
    {
        Debug.Log("Up");
    }
}
