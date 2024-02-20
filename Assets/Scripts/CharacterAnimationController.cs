using UnityEngine;

namespace FishNetLearnProject
{

    public class CharacterAnimationController
    {
        private Animator _animator;

        private enum AnimationState
        {
            Idle,
            Walking
        }

        public CharacterAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void WalkAnimation()
        {
            _animator.SetBool(Constants.CharacterIsWalking, true);
        }

        public void IdleAnimation()
        {
            _animator.SetBool(Constants.CharacterIsWalking, false);
        }
    }
}