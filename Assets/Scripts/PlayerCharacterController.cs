using FishNet.Object;
using UnityEngine;

namespace FishNetLearnProject
{

    public class PlayerCharacterController : NetworkBehaviour, IMove
    {
        [Header("Data")]
        public PlayerData data;

        private CharacterController _characterController;
        private CharacterAnimationController _characterAnimationController;
        private IPlayerControls _playerControls;
        private IMove _moveImplementation;
        private CameraController _camera;

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (base.IsOwner)
            {
                InitPlayerCamera();
            }
            else
            {
                enabled = false;
            }
        }

        private void InitPlayerCamera()
        {
            _camera = Camera.main.GetComponent<CameraController>();
            _camera.MoveIntoParent(transform, new Vector3(0f, data.CameraYOffset, 0f));
            _camera.InitCamera(data.LookXLimit);
        }

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _characterAnimationController = new CharacterAnimationController(GetComponent<Animator>());
            _moveImplementation = new SimpleCharacterMove(_characterController, _characterAnimationController);
            _playerControls = new PlayerPCControls(transform, data.Speed, data.LookSpeed);

            var networked = GetComponent<NetworkObject>().IsNetworked;
            if (!networked)
            {
                InitPlayerCamera();
            }
        }

        void Update()
        {
            Move(_playerControls.GetMoveDirection());
            Rotate(_playerControls.GetRotation());
            _camera.RotateVertical(_playerControls.GetCameraRotationAngle());
        }

        public void Move(Vector3 direction)
        {
            _moveImplementation.Move(direction);
        }

        public void Rotate(Quaternion rotation)
        {
            _moveImplementation.Rotate(rotation);
        }
    }
}