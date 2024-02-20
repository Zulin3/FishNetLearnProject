using UnityEngine;

namespace FishNetLearnProject
{

    public class PlayerPCControls : IPlayerControls
    {
        private float _speed;
        private float _rotationSpeed;
        private float _cameraVerticalRotation;
        private Transform _player;

        public PlayerPCControls(Transform player, float speed, float rotationSpeed)
        {
            _player = player;
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _cameraVerticalRotation = 0;
        }

        public Vector3 GetMoveDirection()
        {
            Vector3 forward = _player.TransformDirection(Vector3.forward);
            Vector3 right = _player.TransformDirection(Vector3.right);
            float curSpeedX = _speed * Input.GetAxis(Constants.Vertical);
            float curSpeedY = _speed * Input.GetAxis(Constants.Horizontal);
            return (forward * curSpeedX) + (right * curSpeedY);
        }

        public Quaternion GetRotation()
        {
            return Quaternion.Euler(0, Input.GetAxis(Constants.LookVertical) * _rotationSpeed, 0);
        }

        public float GetCameraRotationAngle()
        {
            _cameraVerticalRotation -= Input.GetAxis(Constants.LookHorizontal) * _rotationSpeed;
            return _cameraVerticalRotation;
        }
    }
}