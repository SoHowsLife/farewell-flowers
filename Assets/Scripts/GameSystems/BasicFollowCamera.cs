using GameSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class BasicFollowCamera : MonoBehaviour
    {
        GameObject target;

        [SerializeField]
        float stepToTransitionTarget = 1f;

        float step;

        private void Start()
        {
            target = GameManager.gameManager.Player.gameObject;
            GameManager.gameManager.ChangeCameraTarget += ChangeTarget;
            step = stepToTransitionTarget;
        }
        private void OnDestroy()
        {
            GameManager.gameManager.ChangeCameraTarget -= ChangeTarget;
        }

        private void ChangeTarget(GameObject target)
        {
            transform.parent = target.transform;
        }
    }
}
