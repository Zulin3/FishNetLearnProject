using UnityEngine;

namespace FishNetLearnProject
{

    public class CharacterAnimationController
    {
        private Animator _animator;

        public CharacterAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void WalkAnimation()
        {
            _animator.SetBool(Constants.CharacterIsWalking, true);
            _animator.SetBool(Constants.CharacterIsRunning, false);
        }

        public void IdleAnimation()
        {
            _animator.SetBool(Constants.CharacterIsWalking, false);
            _animator.SetBool(Constants.CharacterIsRunning, false);
        }

        public void RunningAnimation()
        {
            _animator.SetBool(Constants.CharacterIsRunning, true);
            _animator.SetBool(Constants.CharacterIsWalking, true);
        }

        public void WaitingAnimation()
        {
            _animator.SetTrigger(Constants.CharacterWaitTrigger);
        }
    }
}