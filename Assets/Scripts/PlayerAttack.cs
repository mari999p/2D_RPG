using UnityEngine;

namespace RPG
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private float _attackCooldown = 1.0f;
        private float _nextAttackTime;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= _nextAttackTime)
            {
                PerformAttack();
                _nextAttackTime = Time.time + _attackCooldown;
            }
        }

        #endregion

        #region Private methods

        private void PerformAttack()
        {
            _playerAnimation.TriggerAttack();
        }

        #endregion
    }
}