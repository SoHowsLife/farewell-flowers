using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private ArrowObject UArrow;
    [SerializeField] private ArrowObject DArrow;
    [SerializeField] private ArrowObject LArrow;
    [SerializeField] private ArrowObject RArrow;

    private List<ArrowObject> Keys;
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
        Keys = new List<ArrowObject>();
        resetKeys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
    }

    void resetKeys()
    {
        Keys.Clear();
        for(int i = 0; i < difficulty; i++)
        {
            switch(Random.Range(0, 4))
            {
                case 0:
                    Keys.Add(UArrow);
                    break;
                case 1:
                    Keys.Add(DArrow);
                    break;
                case 2:
                    Keys.Add(LArrow);
                    break;
                case 3:
                    Keys.Add(RArrow);
                    break;
                default:
                    Debug.Log("Key Reset ERROR");
                    break;
            }
        }
        index = 0;
    }
}
