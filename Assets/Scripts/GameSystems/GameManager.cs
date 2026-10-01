using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameSystems
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        public DiaryManager DiaryManager;
        PlayerInputManager player;
        BasicFollowCamera cam;
        Image screenTransition;
        Image popup;

        public PlayerInputManager Player => player;

        public UnityAction<bool> TogglePlayerInput;
        public UnityAction<GameObject> ChangeCameraTarget;
        public UnityAction<string[]> TriggerDialogue;
       

        private void Awake()
        {
            if (gameManager == null) gameManager = this;
            else if (gameManager != this) Destroy(gameObject);

            GameObject.Find("Player")?.TryGetComponent(out player);
            GameObject.Find("Main Camera")?.TryGetComponent(out cam);
            TryGetComponent<DiaryManager>(out DiaryManager);
            GameObject.Find("Screen Transition")?.TryGetComponent(out screenTransition);
            GameObject.Find("Popup Render")?.TryGetComponent(out popup);
            popup.enabled = false;
        }

        public void LoadScene(string scene)
        {
            Debug.Log("boop");
            StartCoroutine(LoadSceneTransition(scene));
        }
        IEnumerator LoadSceneTransition(string scene)
        {
            while (screenTransition.color.a < 1)
            {
                screenTransition.color = new Color(1, 1, 1, screenTransition.color.a + 0.1f);
                yield return new WaitForSeconds(0.1f);
            }
            SceneManager.LoadScene(scene);
        }
        public void SetPopup(Sprite sprite)
        {
            popup.sprite = sprite;
            popup.enabled = true;
        }
    }
}
