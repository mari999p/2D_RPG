using UnityEngine;

namespace RPG
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Movement = Animator.StringToHash("movement");
        private static readonly int Run = Animator.StringToHash("run");
        private static readonly int Death = Animator.StringToHash("death");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void SetMovement(float speed)
        {
            _animator.SetFloat(Movement, speed);
        }
        public void TriggerDeath()
        {
            _animator.SetTrigger(Death);
        }
        public void SetRunning(bool isRunning)
        {
            _animator.SetBool(Run, isRunning);
        }
        

        #endregion
    }
}