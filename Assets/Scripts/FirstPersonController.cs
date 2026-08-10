using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    #region Variables 
    // REFERENCE _characterController (CharacterController)
    // REFERENCE _playerCamera (Camera)
    [Header("References")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera _playerCamera;

    // FLOAT _walkSpeed
    // FLOAT _sprintSpeed
    // FLOAT _crouchSpeed
    // FLOAT _movementSpeed
    [Header("Movement Speeds")]
    [SerializeField] private float _walkSpeed = 6f;
    [SerializeField] private float _sprintSpeed = 10f;
    [SerializeField] private float _crouchSpeed = 3f;
    [SerializeField] private float _movementSpeed;

    // FLOAT _jumpSpeed
    // FLOAT _gravity
    [Header("Jump / Gravity")]
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float _gravity = -20f;

    // VECTOR3 _movementDirection
    private Vector3 _movementDirection = Vector3.zero;

    // FLOAT _mouseSensitivity
    // FLOAT _lookLimit
    // BOOL _invertY
    [Header("Mouse Look")]
    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private float _lookLimit = 80f;
    [SerializeField] private bool _invertY = false;

    // FLOAT _rotationX  
    private float _rotationX = 0f;

    #endregion

    #region Player Movement
    void PlayerMovement()
    {
        //IF _characterController isGrounded THEN

        //  IF INPUT LeftShift is Pressed THEN
        //      SET _movementSpeed to _sprintSpeed
        //  ELSE IF INPUT LeftControl is Pressed THEN
        //      SET _movementSpeed to _crouchSpeed
        //  ELSE
        //      SET _movementSpeed to _walkSpeed
        //  ENDIF

        //  SET _movementDirection To Both Horizontal Vertical INPUT
        //  SET _movementDirection MULTIPLIED by _movementSpeed
        //  SET _movementDirection TransformDirection

        //  IF INPUT Space is Pressed THEN
        //      SET _movementDirection.y to _jumpSpeed
        //  ENDIF

        //ENDIF

        //SET _movementDirection.y by _gravity (MULTIPLIED by Time.deltaTime, ADDED to existing y)
        //SET _characterController.Move by _movementDirection (MULTIPLIED by Time.deltaTime)

        if (_characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _movementSpeed = _sprintSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                _movementSpeed = _crouchSpeed;
            }
            else
            {
                _movementSpeed = _walkSpeed;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            _movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
            _movementDirection *= _movementSpeed;
            _movementDirection = transform.TransformDirection(_movementDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movementDirection.y = _jumpSpeed;
            }
        }

        _movementDirection.y += _gravity * Time.deltaTime;
        _characterController.Move(_movementDirection * Time.deltaTime);
    }
    #endregion

    #region Camera Control
    void CameraControl()
    {

        //GET mouse X input MULTIPLIED by sensitivity
        //ROTATE player (transform) around Y-axis by that amount

        //GET mouse Y input MULTIPLIED by sensitivity
        //ADD result to _rotationX (running total)

        //CLAMP _rotationX between -_lookLimit and _lookLimit

        //IF invert is enabled THEN
        //    SET verticalRotation to _rotationX
        //ELSE
        //    SET verticalRotation to negative _rotationX
        //ENDIF

        //SET camera's local rotation X-axis to verticalRotation (Y and Z stay 0)

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        _rotationX += mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -_lookLimit, _lookLimit);

        float verticalRotation = _invertY ? _rotationX : -_rotationX;

        _playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    #endregion

    #region UnityEvents
    void Start()
    {
        //IF _characterController is NOT assigned THEN
        //    GET CharacterController component from this GameObject
        //ENDIF

        //IF _playerCamera is NOT assigned THEN
        //    GET Camera component from children
        //ENDIF

        //LOCK cursor to center of screen
        //HIDE cursor

        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }

        if (_playerCamera == null)
        {
            _playerCamera = GetComponentInChildren<Camera>();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Update()
    {
        //CALL PlayerMovement
        //CALL CameraControl

        PlayerMovement();
        CameraControl();

    }
    #endregion
}
