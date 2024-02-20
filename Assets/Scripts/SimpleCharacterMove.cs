using UnityEngine;

namespace FishNetLearnProject
{

    public class SimpleCharacterMove : IMove
    {
        private CharacterController _characterController;
        private CharacterAnimationController _characterAnimationController;

        public SimpleCharacterMove(CharacterController characterController, CharacterAnimationController characterAnimationController)
        {
            _characterController = characterController;
            _characterAnimationController = characterAnimationController;
        }

        public void Move(Vector3 direction)
        {
            _characterController.Move(direction * Time.deltaTime);

            if (direction == Vector3.zero)
            {
                _characterAnimationController.IdleAnimation();
            }
            else
            {
                _characterAnimationController.WalkAnimation();
            }

        }

        public void Rotate(Quaternion rotation)
        {
            _characterController.transform.rotation *= rotation;
        }
    }
}