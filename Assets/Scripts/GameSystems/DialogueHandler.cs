using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameSystems
{
    public class DialogueHandler : MonoBehaviour
    {
        [SerializeField]
        float textSpeed = 0.3f;
        [SerializeField]
        GameObject dialogueBox;
        [SerializeField]
        TextMeshProUGUI text;

        int index;

        string[] lines;

        // Start is called before the first frame update
        void Start()
        { 
            GameManager.gameManager.TriggerDialogue += StartDialogue;
        }

        private void OnDestroy()
        {
            GameManager.gameManager.TriggerDialogue -= StartDialogue;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (text.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    text.text = lines[index];
                }
            }
        }

        public void StartDialogue(string[] dialogue)
        {
            text.text = "";
            index = 0;
            lines = dialogue;
            dialogueBox.SetActive(true);
            StartCoroutine(DisplayText());
        }

        IEnumerator DisplayText()
        {
            foreach (char c in lines[index])
            {
                text.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                text.text = "";
                StartCoroutine(DisplayText());
            }
            else dialogueBox.SetActive(false);
        }
    }
}
