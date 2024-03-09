using UnityEngine;

namespace FishNetLearnProject
{

    public class SimpleCharacterMove : IMove
    {
        private CharacterController _characterController;
        private CharacterAnimationController _characterAnimationController;
        private float _minSpeed = 0.3f;
        private float _walkSpeed;
        private float _runSpeed;
        private float _waitTime;
        private float _waitBeginTime;
        private CharacterState _characterState;

        private enum CharacterState
        {
            Idle,
            Walking,
            Running,
            Waiting
        }

        public SimpleCharacterMove(CharacterController characterController, CharacterAnimationController characterAnimationController, PlayerData playerData)
        {
            _characterController = characterController;
            _characterAnimationController = characterAnimationController;
            _walkSpeed = playerData.Speed;
            _runSpeed = playerData.RunSpeed;
            _waitTime = playerData.WaitTime;
            _characterState = CharacterState.Idle;
        }

        public void Move(Vector3 direction, bool isRunning)
        {
            if (direction.magnitude < _minSpeed)
            {
                _characterAnimationController.IdleAnimation();
                if (_characterState != CharacterState.Idle)
                {
                    _characterState = CharacterState.Idle;
                    _waitBeginTime = Time.time;
                }
                else
                {
                    if (Time.time - _waitBeginTime > _waitTime)
                    {
                        _characterState = CharacterState.Waiting;
                        _characterAnimationController.WaitingAnimation();
                    }
                }
            }
            else
            {
                if (!isRunning)
                {
                    _characterState = CharacterState.Walking;
                    _characterController.Move(direction * Time.deltaTime * _walkSpeed);
                    _characterAnimationController.WalkAnimation();
                }
                else
                {
                    _characterState = CharacterState.Running;
                    _characterController.Move(direction * Time.deltaTime * _runSpeed);
                    _characterAnimationController.RunningAnimation();
                }
            }
        }

        public void Rotate(Quaternion rotation)
        {
            _characterController.transform.rotation *= rotation;
        }
    }
}