using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystems.Triggers
{
    public class GameTrigger : MonoBehaviour
    {
        async public virtual Task<bool> Trigger()
        {
            return true;
        }
    }
}
