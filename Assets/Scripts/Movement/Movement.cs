using UnityEngine;

namespace Bugbear.CharacterMovement
{
    public class Movement : MonoBehaviour
    {
        [Header("References")]
        private CharacterController _characterController;
        private Animator _animator;

        [Header("Constants")]
        public float _moveSpeed = 2f;
        public float _gravity = -9.8f;
        private float _groundedGravity = -0.05f;
        private float _jumpForce;
        private float _movementGCD;
        private float _maxJumpHeight = 1.0f;
        private float _maxJumpTime = 0.75f;
        private float _jumpCooldown = 1f;
        private float _velocityZ = 0.0f;
        private float _velocityX = 0.0f;
        private float _acceleration = 2.0f;
        private float _deceleration = 2.0f;

        //Player Input Values
        private Vector3 _currentMovement;
        private bool isMovementPressed;
        private bool isJumping = false;
        private bool isDashing;
        private bool isJumpPressed = false;

        //Animations TODO: ADD MORE HASHES
        private int isRunningHash;
        private int isJumpingHash;
        private bool isJumpAnimating = false;



        private void Start()
        {
            InitializeMovement();
            InitializeJumpVariables();
        }

        private void InitializeMovement()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void InitializeJumpVariables()
        {
            float timeToApex = _maxJumpTime / 2;
            _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
            _jumpForce = (2 * _maxJumpHeight) / timeToApex;

            //Second Jump Variable
        }

        public void SetMovement(Vector2 input)
        {
            _currentMovement.x = input.x;
            _currentMovement.z = input.y;
            isMovementPressed = input.x != 0 || input.y != 0;
        }

        public void OnJump(bool isJumping)
        {
            isJumpPressed = isJumping;
        }

        private void Update()
        {
            HandleMovement();
            HandleAnimation();

            HandleGravity();
            HandleJump();
        }

        private void HandleAnimation()
        {
            if (isMovementPressed)
            {
                _animator.SetBool("isMoving", true);
            }
            else if (!isMovementPressed)
            {
                _animator.SetBool("isMoving", false);
            }
        }

        private void HandleGravity()
        {
            bool isFalling = _currentMovement.y <= 0.0f || !isJumpPressed;
            float falllMultiplier = 2.0f;

            if (_characterController.isGrounded)
            {
                if (isJumpAnimating)
                {
                    isJumpAnimating = false;
                }
                _currentMovement.y = _gravity;
            }
            else if (isFalling)
            {
                float previousYvelocity = _currentMovement.y;
                float newYvelocity = _currentMovement.y + (_gravity * falllMultiplier * Time.deltaTime);
                float nextYvelocity = (previousYvelocity + newYvelocity) * 0.5f;
                _currentMovement.y = nextYvelocity;

            }
            else
            {
                float previousYvelocity = _currentMovement.y;
                float newYvelocity = _currentMovement.y + (_gravity * Time.deltaTime);
                float nextYvelocity = (previousYvelocity + newYvelocity) * 0.5f;
                _currentMovement.y = nextYvelocity;
            }
        }

        private void HandleMovement()
        {
            _characterController.Move(_currentMovement * _moveSpeed * Time.deltaTime);
        }

        private void HandleJump()
        {
            if (!isJumping && _characterController.isGrounded && isJumpPressed)
            {
                isJumpAnimating = true;
                isJumping = true;
                _currentMovement.y = _jumpForce * 0.7f;
                _movementGCD = 0f;
            }
            else if (!isJumpPressed && isJumping && _characterController.isGrounded)
            {
                isJumping = false;
            }
        }
    }
}
