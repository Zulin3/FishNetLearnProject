using UnityEngine;

namespace FishNetLearnProject
{
    [CreateAssetMenu(fileName = "Data_Players", menuName = "Fish Net Learn Project/Players Data", order = 1)]
    public class PlayerData : ScriptableObject
    {
        [Header("Player stats")]
        public float Speed;
        public float RunSpeed;
        public float WaitTime;
        public float LookSpeed;

        [Header("Camera stats")]
        public float LookXLimit;
        public float CameraYOffset;
        public float CameraZOffset;
    }
}