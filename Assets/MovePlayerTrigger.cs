using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class MovePlayerTrigger : GameTrigger
    {
        [SerializeField]
        float speed = 5;
        [SerializeField]
        float time = 3;
        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.TogglePlayerInput.Invoke(false);
            GameManager.gameManager.Player.SetVelocity(Vector3.right * speed * Time.deltaTime);
            await Task.Delay((int)(time * 1000));
            GameManager.gameManager.TogglePlayerInput.Invoke(true);
            return true;
        }
    }
}
