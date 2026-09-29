using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //static int wordIndex = 0;
    static int lastWord = -1;
    private static List<string> wordList = new List<string>
    {
        "milquetoast","ubiquitous","taciturn","syzygy","phloem","chrysanthemum","pulchritudinous",
        "avaricious","pterodactyl","jeopardy","tchotchke","tinnitus","whittle","flotilla",
        "quixotic","superfluous","mimicry","machination","machiavellian","zenithal","axolotl",
        "boudoirs","yttrium","xenophobia","nitrogenous","vacuous","zooxanthellae","reticulum",
        "aberrant","exquisite","maelstrom","precocious","knave","kineticism","diarrhea","restaurant",
        "jared","congeal","hydrangea","cynicism","myocarditis","coagulate","flagellum","melismatic",
        "ventriloquy","masseuse","lackadaisical","amateurish","chambray","fibromyalgia"
    };

    public static string generateWord()
    {
        int index = Random.Range(0, wordList.Count);
        if (index == lastWord)
        {
            index = (index + 1) % wordList.Count;
        }
        lastWord = index;
        string word = wordList[index];

        //string word = wordList[wordIndex];
        //wordIndex = (wordIndex + 1) % wordList.Count;
        return word;
    }
}
