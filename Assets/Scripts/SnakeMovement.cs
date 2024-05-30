using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _snakeHead;
    [SerializeField] Sprite _HeadUp, _HeadDown, _HeadLeft, _HeadRight;


    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Vector2 _rotation;
    private SnakeInputSystem _inputActions;


    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        _inputActions = new SnakeInputSystem();
        _inputActions.Player.Movement.performed += HandleMovement;
        _inputActions.Player.Rotation.performed += RotateSnake;
        _inputActions.Enable();
    }

    private void HandleMovement(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        Debug.Log("MoveDirection: " +  _moveDirection);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = _moveDirection * _moveSpeed;
    }
    
    private void RotateSnake(InputAction.CallbackContext context)
    {
        _rotation = context.ReadValue<Vector2>();
        _snakeHead.transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
        RotateHead(_moveDirection);
    }

   private void RotateHead(Vector2 direct)
    {
        if (_moveDirection == Vector2.up)
            _snakeHead.GetComponent<SpriteRenderer>().sprite = _HeadUp;
        else if (_moveDirection == Vector2.down)
            _snakeHead.GetComponent<SpriteRenderer>().sprite = _HeadDown;
        else if (_moveDirection == Vector2.left)
            _snakeHead.GetComponent<SpriteRenderer>().sprite = _HeadLeft;
        else if (_moveDirection == Vector2.right)
            _snakeHead.GetComponent<SpriteRenderer>().sprite = _HeadRight;
    }
        


    
}
