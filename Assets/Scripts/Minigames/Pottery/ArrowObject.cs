using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
public class ArrowObject : MonoBehaviour
{
    [SerializeField] private Direction direction;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;
    private Image spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = unpressedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool pressKey(Direction key)
    {
        if (key == direction)
        {
            spriteRenderer.sprite = pressedSprite;
            return true;
        }
        return false;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
