using UnityEngine;

namespace FishNetLearnProject
{

    public interface IMove
    {
        public void Move(Vector3 direction);
        public void Rotate(Quaternion rotation);
    }
}