using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMap _playerInput;
    private Movement _movement;

    private Camera mainCamera;

    private void Awake()
    {
        _playerInput = new InputMap();
        _movement = GetComponent<Movement>();

        _playerInput.PlayerControls.Move.started += ctx => _movement.SetMovement(ctx.ReadValue<Vector2>());
        _playerInput.PlayerControls.Move.performed += ctx => _movement.SetMovement(ctx.ReadValue<Vector2>());
        _playerInput.PlayerControls.Move.canceled += ctx => _movement.SetMovement(ctx.ReadValue<Vector2>());
        _playerInput.PlayerControls.Jump.started += ctx => _movement.OnJump(ctx.ReadValueAsButton());
        _playerInput.PlayerControls.Jump.canceled += ctx => _movement.OnJump(ctx.ReadValueAsButton());

    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _playerInput.PlayerControls.Enable();
    }

    private void OnDisable()
    {
        _playerInput.PlayerControls.Disable();
    }
}
