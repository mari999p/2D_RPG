using UnityEngine;

namespace RPG
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _runSpeedMultiplier = 2;
        [SerializeField] private float _jumpForce = 5;
        [Header("Ground Check")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheck;

        private bool _isGrounded;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Move();
            Rotate();
            Jump();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        #endregion

        #region Private methods

        private void CheckGround()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundLayer);
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _animation.TriggerJump();
            }
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = new(horizontal, 0);
            float currentSpeed = _speed;

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            if (isRunning)
            {
                currentSpeed *= _runSpeedMultiplier;
            }

            Vector2 velocity = direction.normalized * currentSpeed;
            velocity.y = _rb.velocity.y;
            _rb.velocity = velocity;

            _animation.SetMovement(direction.magnitude);
            _animation.SetRunning(isRunning);
        }

        private void Rotate()
        {
            _spriteRenderer.flipX = Input.GetAxis("Horizontal") < 0;
        }

        #endregion
    }
}