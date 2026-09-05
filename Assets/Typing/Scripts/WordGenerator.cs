using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    static int wordIndex = 0;
    private static List<string> wordList = new List<string>
    {
        "efflorescence", "flower", "jarona", "botanical", "melancholy",
        "somber", 

    };

    public static string generateWord()
    {
        int index = Random.Range(0, wordList.Count);
        string word = wordList[index];

        //string word = wordList[wordIndex];
        //wordIndex = (wordIndex + 1) % wordList.Count;
        return word;
    }
}
