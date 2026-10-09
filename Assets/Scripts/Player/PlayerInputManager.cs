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
        InputAction pause;
        InputAction interact;
        Rigidbody rb;
        BoxCollider col;
        SpriteRenderer sprite;
        Animator anim;
        [SerializeField]
        float speed;

        bool readInputs = true;
        public bool ReadInputs { get { return readInputs; } }

        Vector3 velocity;

        private void Awake()
        {
            PlayerInput playerInput = GetComponent<PlayerInput>();
            rb = GetComponent<Rigidbody>();
            input = playerInput.actions.FindAction("Move");
            pause = playerInput.actions.FindAction("Pause");
            interact = playerInput.actions.FindAction("Interact");
            sprite = GetComponentInChildren<SpriteRenderer>();
            col = GetComponent<BoxCollider>();
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            GameManager.gameManager.TogglePlayerInput += TogglePlayerInputs;
            pause.performed += OnPause;
            interact.performed += OnInteract;
        }
        private void OnDestroy()
        {
            GameManager.gameManager.TogglePlayerInput -= TogglePlayerInputs;
            pause.performed -= OnPause;
            interact.performed -= OnInteract;
        }

        public void OnPause(InputAction.CallbackContext ctx)
        {
            if (!readInputs) return;
            GameManager.gameManager.DiaryManager.ToggleDiaryDisplay();
        }
        public void OnInteract(InputAction.CallbackContext ctx)
        {
            if (!readInputs) return;
            Collider[] cols = Physics.OverlapBox(transform.position, col.size, Quaternion.identity, LayerMask.GetMask("Interactable"));
            foreach(Collider col in cols)
            {
                col.GetComponent<Interactable>().Interact();
            }
        }

        public void TogglePlayerInputs(bool toggle)
        {
            readInputs = toggle;
            SetVelocity(Vector3.zero);
        }


        private void FixedUpdate()
        {
            if (readInputs)
            {
                SetVelocity(velocity = Vector3.right * input.ReadValue<Vector2>().x * speed * Time.deltaTime);
            }
            if ((sprite.flipX && velocity.x > 0) || (!sprite.flipX && velocity.x < 0)) sprite.flipX = !sprite.flipX;
            Move();
        }

        public void SetVelocity(Vector3 velocity)
        {
            this.velocity = velocity;
        }

        public void Move()
        {
            rb.velocity = velocity;
            anim.SetBool("IsMoving", rb.velocity != Vector3.zero);
        }
    }
}