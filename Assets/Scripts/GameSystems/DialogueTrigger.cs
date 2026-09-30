using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class DialogueTrigger : GameTrigger
    {
        [SerializeField]
        string[] dialogue;

        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.TriggerDialogue(dialogue);
            while (!GameManager.gameManager.Player.ReadInputs)
            {
                await Task.Yield();
            }
            return true;
        }
    }
}
