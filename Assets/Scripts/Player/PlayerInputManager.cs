using GameSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        InputAction input;
        Rigidbody rb;
        [SerializeField]
        float speed;

        bool readInputs = true;

        Vector3 velocity;

        private void Awake()
        {
            PlayerInput playerInput = GetComponent<PlayerInput>();
            rb = GetComponent<Rigidbody>();
            input = playerInput.actions.FindAction("Move");
        }

        private void Start()
        {
            GameManager.gameManager.TogglePlayerInput += TogglePlayerInputs;
        }
        private void OnDestroy()
        {
            GameManager.gameManager.TogglePlayerInput -= TogglePlayerInputs;
        }


        public void TogglePlayerInputs(bool toggle)
        {
            readInputs = toggle;
        }


        private void FixedUpdate()
        {
            if (readInputs)
            {
                SetVelocity(velocity = Vector3.right * input.ReadValue<Vector2>().x * speed * Time.deltaTime);
            }
            Move();
        }

        public void SetVelocity(Vector3 velocity)
        {
            this.velocity = velocity;
        }

        public void Move()
        {
            rb.velocity = velocity;
        }
    }
}