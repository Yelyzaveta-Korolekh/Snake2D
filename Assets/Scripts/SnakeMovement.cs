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
    private SnakeInputSystem _inputActions;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputActions = new SnakeInputSystem();
        _inputActions.Player.Movement.performed += HandleMovement;
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
}
