using UnityEngine;

namespace FishNetLearnProject
{

    public interface IPlayerControls
    {
        public Vector3 GetMoveDirection();
        public bool GetIsRunning();
        public Quaternion GetRotation();
        public float GetCameraRotationAngle();
    }
}