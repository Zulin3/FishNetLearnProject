using UnityEngine;

namespace FishNetLearnProject
{

    public interface IMove
    {
        public void Move(Vector3 direction, bool isRunning);
        public void Rotate(Quaternion rotation);
    }
}