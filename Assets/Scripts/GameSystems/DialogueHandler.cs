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
        int characterCount => text.textInfo.characterCount;
        int index;

        // temporarily ignore left clicks so interacting with something doesn't insta skip the first dialogue
        float dialogueDeadzone = 0.2f;
        float deadZoneTimer = 0;

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
            if (!dialogueBox.activeSelf) return;
            else if (Time.time < deadZoneTimer + dialogueDeadzone) return;

            if (Input.GetMouseButtonDown(0))
            {
                if (text.maxVisibleCharacters == characterCount)
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    text.maxVisibleCharacters = characterCount;
                }
            }
        }

        public void StartDialogue(string[] dialogue)
        {
            index = 0;
            lines = dialogue;
            dialogueBox.SetActive(true);
            deadZoneTimer = Time.time;
            text.text = lines[0];
            text.ForceMeshUpdate();
            text.maxVisibleCharacters = 0;
            StartCoroutine(DisplayText());
            GameManager.gameManager.TogglePlayerInput(false);
        }

        IEnumerator DisplayText()
        {
            for (int i = 0; i < characterCount; i++)
            {
                text.maxVisibleCharacters++;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                text.text = lines[index];
                text.ForceMeshUpdate();
                text.maxVisibleCharacters = 0;
                StartCoroutine(DisplayText());
            }
            else
            {
                GameManager.gameManager.TogglePlayerInput(true);
                dialogueBox.SetActive(false);
            }
        }
    }
}
