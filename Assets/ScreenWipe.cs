using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
    Image screenTransition;

    private void Start()
    {
        TryGetComponent(out screenTransition);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (screenTransition.color.a > 0)
        {
            screenTransition.color = new Color(1, 1, 1, screenTransition.color.a - 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
