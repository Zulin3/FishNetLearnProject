using FishNet.Object;
using UnityEngine;



public class PlayerCharacterController : NetworkBehaviour
{
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] private float LookSpeed = 2.0f;
    [SerializeField] private float LookXLimit = 45.0f;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private float _rotationX = 0;

    [SerializeField] private float CameraYOffset = 0.5f;
    private Camera _playerCamera;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            _playerCamera = Camera.main;
            _playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + CameraYOffset, transform.position.z);
            _playerCamera.transform.parent = transform;
        }
        else
        {
            enabled = false;
        }
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = Speed * Input.GetAxis("Vertical");
        float curSpeedY = Speed * Input.GetAxis("Horizontal");
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        _characterController.Move(_moveDirection * Time.deltaTime);

        _rotationX -= Input.GetAxis("Mouse Y") * LookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -LookXLimit, LookXLimit);
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * LookSpeed, 0);

    }
}
