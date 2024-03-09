using UnityEngine;

namespace FishNetLearnProject
{

    public class PlayerPCControls : IPlayerControls
    {
        private float _cameraVerticalRotation;
        private Transform _player;

        public PlayerPCControls(Transform player)
        {
            _player = player;
            _cameraVerticalRotation = 0;
        }

        public Vector3 GetMoveDirection()
        {
            Vector3 forward = _player.TransformDirection(Vector3.forward);
            Vector3 right = _player.TransformDirection(Vector3.right);
            float curSpeedX = Input.GetAxis(Constants.Vertical);
            float curSpeedY = Input.GetAxis(Constants.Horizontal);
            return (forward * curSpeedX) + (right * curSpeedY);
        }

        public Quaternion GetRotation()
        {
            return Quaternion.Euler(0, Input.GetAxis(Constants.LookVertical), 0);
        }

        public bool GetIsRunning()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        public float GetCameraRotationAngle()
        {
            _cameraVerticalRotation -= Input.GetAxis(Constants.LookHorizontal);
            return _cameraVerticalRotation;
        }
    }
}