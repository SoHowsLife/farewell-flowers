using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class Word : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordText;
    [SerializeField] private TextMeshProUGUI playerText;
    private string wordToSpell = "";
    private int index = 0;
    private bool isWrong = false;
    // Start is called before the first frame update
    void Start()
    {
        changeText("Testing");
    }

    public bool checkLetter(char letter)
    {
        if (isWrong)
        {
            return true;
        }
        if (letter == wordToSpell.ToLower()[index])
        {
            playerText.text = string.Format("<color=\"green\">{0}", wordToSpell.Substring(0, index + 1));
            index++;
            return true;
        }
        else if (char.IsLetter(letter))
        {
            playerText.text = string.Format("<color=\"green\">{0}<color=\"red\">{1}", wordToSpell.Substring(0, index), wordToSpell[index]);
            isWrong = true;
        }
        return false;
    }

    public void backspaceLetter()
    {
        if (isWrong)
        {
            playerText.text = string.Format("<color=\"green\">{0}", wordToSpell.Substring(0, index));
            isWrong = false;
        }
    }

    public bool checkComplete()
    {
        return index >= wordToSpell.Length;
    }
    public void changeText(string newWord)
    {
        playerText.text = "";
        wordText.text = newWord;
        wordToSpell = newWord;
        index = 0;
        isWrong = false;
    }
}
