using GameSystems.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class Interactable : MonoBehaviour
    {
        async public virtual void Interact()
        {
            foreach (GameTrigger gameTrigger in GetComponents<GameTrigger>())
            {
                await gameTrigger.Trigger();
            }
        }
    }
}
