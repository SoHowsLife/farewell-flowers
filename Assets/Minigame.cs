using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    [SerializeField] private Camera minigameCamera;
    void Start()
    {
        AssignCamera();
    }
    
    void AssignCamera()
    {
        foreach (Canvas canvas in GetComponentsInChildren<Canvas>())
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = minigameCamera;
        }
    }
}
