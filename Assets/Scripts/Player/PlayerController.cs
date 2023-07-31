using Bugbear.CharacterMovement;
using Bugbear.Combat;
using System;
using UnityEngine;

namespace Bugbear.Player
{
    public class PlayerController : MonoBehaviour
    {
        private InputMap _playerInput;
        private Movement _movement;
        private CombatScheme _combatSceheme;

        private Camera mainCamera;

        public event Action<Animator> onPlayerInitialize;

        private void Awake()
        {
            InitializePlayer();
        }
        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void OnDisable()
        {
            _playerInput.PlayerControls.Disable();
        }
        private void InitializePlayer()
        {
            _playerInput = new InputMap();
            _movement = GetComponent<Movement>();
            _combatSceheme = GetComponent<CombatScheme>();

            _playerInput.PlayerControls.Move.started += ctx => _movement.SetMovement(ctx.ReadValue<Vector2>());
            _playerInput.PlayerControls.Move.performed += ctx => _movement.SetMovement(ctx.ReadValue<Vector2>());
            _playerInput.PlayerControls.Move.canceled += ctx => _movement.SetMovement(ctx.ReadValue<Vector2>());
            _playerInput.PlayerControls.Jump.performed += ctx => _movement.OnJump(ctx.ReadValueAsButton());
            _playerInput.PlayerControls.Jump.canceled += ctx => _movement.OnJump(ctx.ReadValueAsButton());
            _playerInput.PlayerControls.Attack.performed += ctx => _combatSceheme.OnAttack(ctx.ReadValueAsButton());
            _playerInput.PlayerControls.Attack.canceled += ctx => _combatSceheme.OnAttack(ctx.ReadValueAsButton());


            _playerInput.PlayerControls.Enable();
        }
    }
}
