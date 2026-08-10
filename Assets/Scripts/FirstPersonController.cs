using UnityEngine;

//My First Person Controller!
[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    #region Variables

    //By default these members are private. Names begin with an underscore.
    [SerializeField] private CharacterController _characterController; //reference to the CharacterController component
    [SerializeField] private Camera _playerCamera; //reference to the camera we look through

    [Header("Movement Speeds")]
    [SerializeField] private float _walkSpeed = 6f;
    [SerializeField] private float _sprintSpeed = 10f;
    [SerializeField] private float _crouchSpeed = 3f;
    private float _movementSpeed; //whichever speed is currently active

    [Header("Jump / Gravity")]
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float _gravity = -20f;

    private Vector3 _movementDirection = Vector3.zero; //how far/which way we move this frame

    [Header("Mouse Look")]
    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private float _lookLimit = 80f;
    public bool invertY = false; //should looking up/down be reversed?

    private float _rotationX = 0f; //running vertical look angle

    #endregion

    #region Player Movement
    void PlayerMovement()
    {
        //We only worry about handling movement input if the controller is grounded.
        if (_characterController.isGrounded)
        {
            //Sprinting: if the player holds Left Shift, move faster than normal.
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //We should move at _sprintSpeed.
                _movementSpeed = _sprintSpeed;
            }
            
            //Crouching: if the player holds Left Control instead, move slower than normal.
            //This works just like the Sprint check above, but:
            //  - checks for KeyCode.LeftControl instead of LeftShift
            //  - assigns _crouchSpeed instead of _sprintSpeed

            //ELSE IF INPUT LeftControl is Pressed THEN            
            else if (true)
            {
                //SET _movementSpeed to _crouchSpeed

            }
            else
            {
                //Otherwise we're just walking normally.
                _movementSpeed = _walkSpeed;
            }

            //Read raw horizontal/vertical input (WASD or arrow keys)
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            //Build a direction vector from that input, scale it by our chosen speed,
            //then convert it from local space into world space.
            _movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
            _movementDirection *= _movementSpeed;
            _movementDirection = transform.TransformDirection(_movementDirection);

            //Jumping: if Space is pressed this frame, set our vertical speed to _jumpSpeed.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movementDirection.y = _jumpSpeed;
            }
        }

        //Whether grounded or not, gravity should always be pulling us down.
        _movementDirection.y += _gravity * Time.deltaTime;

        //Finally, actually move the CharacterController by our direction, scaled for deltaTime.
        _characterController.Move(_movementDirection * Time.deltaTime);
    }
    #endregion

    #region Camera Control
    void CameraControl()
    {
        //GET mouse X input and use it to turn the player body left/right.
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        //GET mouse Y input and build up a running vertical look angle.
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;
        _rotationX += mouseY;

        //Clamp so the player can't flip the camera all the way over.
        _rotationX = Mathf.Clamp(_rotationX, -_lookLimit, _lookLimit);

        float verticalRotation = 0f;

        
        //Normal (not inverted) look: moving the mouse up should look up,
        //so the camera's X rotation should be the NEGATIVE of _rotationX.
        //Inverted look: moving the mouse up should look down instead.
            //This is the opposite sign of the case above.

         //IF invert is enabled THEN
        if (invertY)
        {
            //SET verticalRotation to _rotationX
            
        }
        //ELSE
        else
        {
            //SET verticalRotation to negative _rotationX
           
        }
        

        //SET the camera's local rotation on the X-axis only (Y and Z stay 0)
        _playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    #endregion

    #region UnityEvents
    void Start()
    {
        //If no CharacterController was assigned in the Inspector, grab it off this GameObject.
        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }

        //If no camera was assigned, look for one in our children.
        if (_playerCamera == null)
        {
            _playerCamera = GetComponentInChildren<Camera>();
        }

        //Lock and hide the cursor so it doesn't drift around the screen while we look.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        PlayerMovement();
        CameraControl();
    }
    #endregion
}