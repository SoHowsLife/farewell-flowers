using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class SetCameraTargetTrigger : GameTrigger
    {
        [SerializeField]
        GameObject target;
        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.ChangeCameraTarget.Invoke(target);
            return true;
        }
    }
}
