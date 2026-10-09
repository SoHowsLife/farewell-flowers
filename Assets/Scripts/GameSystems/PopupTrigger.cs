using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class PopupTrigger : GameTrigger
    {
        [SerializeField]
        Sprite sprite;

        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.TogglePlayerInput(false);
            GameManager.gameManager.SetPopup(sprite);
            return true;
        }
    }
}
