using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{ public class CollisionInteractable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name != "Player") return;

            GetComponent<Interactable>().Interact();
        }
    }
}
