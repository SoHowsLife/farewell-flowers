using GameSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlayerAnim : MonoBehaviour
{
    [SerializeField]
    AnimatorOverrideController controller;
    [SerializeField]
    float transitionSpeed = 60;
    Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Animator>().runtimeAnimatorController = controller;
        GameManager.gameManager.TogglePlayerInput.Invoke(false);
        GameManager.gameManager.Player.SetVelocity(Vector3.right * transitionSpeed * Time.deltaTime);
        Invoke("CompleteTransition", 3);
    }

    public void CompleteTransition()
    {
        GameManager.gameManager.TogglePlayerInput.Invoke(true);
        col.isTrigger = false;
    }
}
