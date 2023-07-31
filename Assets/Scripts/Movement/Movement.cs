using UnityEngine;

namespace Bugbear.CharacterMovement
{
    public class Movement : MonoBehaviour
    {
        [Header("References")]
        private CharacterController _characterController;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        [Header("Constants")]
        public float _moveSpeed = 2f;
        public float _gravity = -9.8f;
        private float _groundedGravity = -0.05f;
        private float _jumpForce;
        private float _movementGCD;
        private float _maxJumpHeight = 1.0f;
        private float _maxJumpTime = 0.75f;
        private float _jumpCooldown = 1f;
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
        private int isMovingHash = Animator.StringToHash("isMoving");
        private int isJumpingHash = Animator.StringToHash("isJumping");
        private int isFallingHash = Animator.StringToHash("isFalling");
        private int isGroundedHash = Animator.StringToHash("isGrounded");
        private bool isJumpAnimating = false;
        private float lastDirection;

        private void Start()
        {
            InitializeMovement();
            InitializeAnimation();
            InitializeJumpVariables();
        }

        private void InitializeMovement()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void InitializeAnimation()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _currentMovement.z = 0;
            isMovementPressed = input.x != 0;
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
            HandleLookDirection();

            if (isMovementPressed)
            {
                _animator.SetBool(isMovingHash, true);
            }
            else if (!isMovementPressed)
            {
                _animator.SetBool(isMovingHash, false);
            }
        }

        private void HandleGravity()
        {
            bool isFalling = _currentMovement.y <= 0.0f || !isJumpPressed;
            float falllMultiplier = 2.0f;

            if (_characterController.isGrounded)
            {
                _animator.SetBool(isGroundedHash, true);
                _animator.SetBool(isFallingHash, false);
                if (isJumpAnimating)
                {
                    _animator.SetBool(isJumpingHash, false);
                    isJumpAnimating = false;
                }
                _currentMovement.y = _gravity;
            }
            else if (isFalling)
            {
                _animator.SetBool(isGroundedHash, false);
                _animator.SetBool(isFallingHash, true);
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
                _animator.SetBool(isGroundedHash, false);
                _animator.SetBool(isJumpingHash, true);
                isJumpAnimating = true;
                isJumping = true;
                _currentMovement.y = _jumpForce * 0.7f;
                _movementGCD = 0f;
            }
            else if (!isJumpPressed && isJumping && _characterController.isGrounded)
            {
                isJumping = false;
                _animator.SetBool(isGroundedHash, true);
                _animator.SetBool(isFallingHash, false);
            }
        }
        private void HandleLookDirection()
        {
            if (_currentMovement.x > 0)
            {
                lastDirection = Mathf.Sign(_currentMovement.x);
                FlipSprite();
            }
            else if (_currentMovement.x < 0)
            {
                lastDirection = Mathf.Sign(_currentMovement.x);
                FlipSprite(lastDirection);
            }
            else
            {
                FlipSprite(lastDirection);
            }
        }
        private void FlipSprite(float direction = 1f)
        {
            _spriteRenderer.flipX = direction < 0;
        }
    }
}
