using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _speed = 5.0f;

    private float threshold = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float direction = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(direction * _speed, 0f);
        if(Mathf.Abs(direction) > 0)
        {
            _animator.SetBool("isMoving", true);
            if(direction > threshold)
            {
                _sprite.flipX = false;
            }
            else if(direction < threshold)
            {
                _sprite.flipX = true;
            }
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }
}
