using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystems
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;
        PlayerInputManager player;
        BasicFollowCamera cam;

        public PlayerInputManager Player => player;

        public UnityAction<bool> TogglePlayerInput;
        public UnityAction<GameObject> ChangeCameraTarget;

        private void Awake()
        {
            if (gameManager == null) gameManager = this;
            else if (gameManager != this) Destroy(gameObject);

            player = GameObject.Find("Player").GetComponent<PlayerInputManager>();
            cam = GameObject.Find("Main Camera").GetComponent<BasicFollowCamera>();
        }
    }
}
