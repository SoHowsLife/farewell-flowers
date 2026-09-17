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

    private InputAction input;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        input = playerInput.actions.FindAction("Move");
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
            setDifficulty(difficulty + 1);
            //Debug.Log(difficulty);
            resetKeys();
        }
    }

    void setDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
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
}
