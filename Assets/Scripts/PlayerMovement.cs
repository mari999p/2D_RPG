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

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Move();
            Rotate();
        }

        #endregion

        #region Private methods

        private void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 direction = new(horizontal, vertical);
            float currentSpeed = _speed;

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            if (isRunning)
            {
                currentSpeed *= _runSpeedMultiplier;
            }

            Vector2 velocity = direction.normalized * currentSpeed;
            _rb.velocity = velocity;
            _animation.SetMovement(direction.magnitude);
            _animation.SetRunning(isRunning);
        }

        private void Rotate()
        {
            _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
        }

        #endregion
    }
}