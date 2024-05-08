using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Vector2 _rotation;
    private SnakeInputSystem _inputActions;
    private const int _rotateDegree = 90;

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
        ChooseRotateDirection(_rotation);
    }

    private void ChooseRotateDirection(Vector2 rotate)
    {
        if (rotate.x < 0)
        {
            transform.Rotate(0,0, _rotateDegree);
        }
        else if (rotate.x > 0) {
            transform.Rotate(0, 0, -_rotateDegree);
        }
        
    }
}
