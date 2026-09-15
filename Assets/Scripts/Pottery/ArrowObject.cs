using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
}
