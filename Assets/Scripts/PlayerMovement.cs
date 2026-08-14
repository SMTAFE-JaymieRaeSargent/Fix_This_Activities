using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    // REFERENCE _characterController (CharacterController)
    [Header("References")]
    [SerializeField] private CharacterController _characterController;

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
    #endregion

    #region Player Movement
    void PlayerMovementUpdate()
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

    #region UnityEvents
    void Start()
    {
        //IF _characterController is NOT assigned THEN
        if (_characterController == null)
        {
            //    GET CharacterController component from this GameObject

            _characterController = GetComponent<CharacterController>();
        }
        //ENDIF

    }

    void Update()
    {
        //CALL PlayerMovementUpdate
        PlayerMovementUpdate();
    }
    #endregion
}