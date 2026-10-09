using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class TogglePlayerInputTrigger : GameTrigger
    {
        [SerializeField]
        bool toggle = true;
        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.TogglePlayerInput(toggle);
            return true;
        }
    }
}
