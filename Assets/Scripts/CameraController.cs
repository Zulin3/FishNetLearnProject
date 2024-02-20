using UnityEngine;

namespace FishNetLearnProject
{
    public class CameraController : MonoBehaviour
    {
        private float _rotateAngleLimit;

        public void InitCamera(float rotateAngleLimit)
        {
            _rotateAngleLimit = rotateAngleLimit;
        }

        public void MoveIntoParent(Transform parent, Vector3 offset)
        {
            transform.position = new Vector3(parent.position.x + offset.x, parent.position.y + offset.y, parent.position.z + offset.z);
            transform.parent = parent;
        }

        public void RotateVertical(float angle)
        {
            angle = Mathf.Clamp(angle, -_rotateAngleLimit, _rotateAngleLimit);
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
        }
    }

}