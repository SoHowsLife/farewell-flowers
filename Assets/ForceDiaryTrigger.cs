using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class ForceDiaryTrigger : GameTrigger
    {
        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.DiaryManager.ToggleDiaryDisplay();
            return true;
        }
    }
}
