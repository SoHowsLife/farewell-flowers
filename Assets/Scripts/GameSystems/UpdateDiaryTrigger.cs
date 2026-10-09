using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class UpdateDiaryTrigger : GameTrigger
    {
        [SerializeField]
        int index;
        [SerializeField]
        Sprite page;
        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.DiaryManager.UpdatePage(index, page);
            return true;
        }
    }
}
