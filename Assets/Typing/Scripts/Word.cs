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

    public void checkLetter(char letter)
    {
        if (isWrong)
        {
            return;
        }
        if (letter == wordToSpell.ToLower()[index])
        {
            playerText.text = string.Format("<color=\"green\">{0}", wordToSpell.Substring(0, index + 1));
            index++;
        }
        else if (char.IsLetter(letter))
        {
            playerText.text = string.Format("<color=\"green\">{0}<color=\"red\">{1}", wordToSpell.Substring(0, index), wordToSpell[index]);
            isWrong = true;
        }
    }

    public void backspaceLetter()
    {
        if (isWrong)
        {
            playerText.text = string.Format("<color=\"green\">{0}", wordToSpell.Substring(0, index));
            isWrong = false;
        }
    }
    void changeText(string newWord)
    {
        playerText.text = "";
        wordText.text = newWord;
        wordToSpell = newWord;
    }
}
