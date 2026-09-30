using GameSystems.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class SingleUseInteractable : Interactable
    {
        async public override void Interact()
        {
            foreach (GameTrigger gameTrigger in GetComponents<GameTrigger>())
            {
                await gameTrigger.Trigger();
            }
            gameObject.SetActive(false);
        }
    }
}
