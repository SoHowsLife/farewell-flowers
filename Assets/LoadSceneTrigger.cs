using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class LoadSceneTrigger : GameTrigger
    {
        [SerializeField]
        string scene;
        async public override Task<bool> Trigger()
        {
            GameManager.gameManager.LoadScene(scene);
            return true;
        }
    }
}
