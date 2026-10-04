using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class SetActiveTrigger : GameTrigger
    {
        [SerializeField]
        GameObject[] gameObjects;
        [SerializeField]
        bool setActive;

        async public override Task<bool> Trigger()
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(setActive);
            }
            return true;
        }
    }
}
