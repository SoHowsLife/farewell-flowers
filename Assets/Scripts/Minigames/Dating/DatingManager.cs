using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DatingManager : MonoBehaviour
{
    float sliderProgress = 0.0f;
    float sliderOffset = 0.0f;
    [SerializeField] GameObject slider; //Change when we get actual Sprite
    float sliderStart;
    float sliderEnd;

    [SerializeField] GameObject pointer;

    [SerializeField] GameObject hitZone;
    float hitZoneStart;
    float hitZoneEnd;
    int score = 0;


    private InputAction input;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        input = playerInput.actions.FindAction("Click");

        //Change when we get actual Sprite
        sliderStart = (slider.transform.localPosition.x - slider.transform.localScale.x) / 2;
        sliderEnd = (slider.transform.localPosition.x + slider.transform.localScale.x) / 2;

        hitZoneStart = (hitZone.transform.localPosition.x - hitZone.transform.localScale.x) / 2;
        hitZoneEnd = (hitZone.transform.localPosition.x + hitZone.transform.localScale.x) / 2;

        Debug.Log(sliderStart);
        Debug.Log(sliderEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if (input.WasPressedThisFrame())
        {
            playerClick();
        }
    }
    private void FixedUpdate()
    {
        sliderProgress = Mathf.Sin(Time.time + sliderOffset);
        pointer.transform.localPosition = new Vector3(sliderProgress * sliderEnd, slider.transform.localPosition.y, 0);
        //Debug.Log(sliderProgress);

    }

    public void playerClick()
    {
        if (hitZoneStart <= pointer.transform.localPosition.x && pointer.transform.localPosition.x <= hitZoneEnd)
        {
            playerHit();
        }
        else
        {
            playerMiss();
        }
        sliderOffset = Random.Range(0, 2 * Mathf.PI);
    }

    private void playerHit()
    {
        score++;
        Debug.Log("HIT");
    }

    private void playerMiss()
    {
        Debug.Log("MISS");
    }
    public void continueGame()
    {
        Debug.Log("Go to next Scene");
        //TO DO
    }
}
