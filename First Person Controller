# First Person Controller — Pseudocode to C#

This activity takes the movement and camera logic we planned in **pseudocode** and converts it into working **C# code in Unity**.

The purpose of the pseudocode is to describe **what the program needs to do** before worrying about the exact C# syntax.

The finished controller will include:

* Walking
* Sprinting
* Crouching
* Jumping
* Gravity
* Mouse camera control
* Optional inverted Y-axis
* Cursor locking

---

# 1. Variables

Before writing the movement code, we need to identify the information the controller needs to store.

## Pseudocode

```text
#region Variables

// REFERENCE _characterController (CharacterController)
// REFERENCE _playerCamera (Camera)

// FLOAT _walkSpeed
// FLOAT _sprintSpeed
// FLOAT _crouchSpeed
// FLOAT _movementSpeed

// FLOAT _jumpSpeed
// FLOAT _gravity

// VECTOR3 _movementDirection

// FLOAT _mouseSensitivity
// FLOAT _lookLimit
// BOOL _invertY

// FLOAT _rotationX  // running vertical look angle

#endregion
```

## C# Version

```csharp
#region Variables

[Header("References")]
[SerializeField] private CharacterController _characterController;
[SerializeField] private Camera _playerCamera;

[Header("Movement Speeds")]
[SerializeField] private float _walkSpeed = 6f;
[SerializeField] private float _sprintSpeed = 10f;
[SerializeField] private float _crouchSpeed = 3f;
[SerializeField] private float _movementSpeed;

[Header("Jump / Gravity")]
[SerializeField] private float _jumpSpeed = 8f;
[SerializeField] private float _gravity = -20f;

private Vector3 _movementDirection = Vector3.zero;

[Header("Mouse Look")]
[SerializeField] private float _mouseSensitivity = 2f;
[SerializeField] private float _lookLimit = 80f;
[SerializeField] private bool _invertY = false;

private float _rotationX = 0f;

#endregion
```

## What Changed?

The pseudocode identifies the **type of information** we need.

For example:

| Pseudocode                   | C#                                                   |
| ---------------------------- | ---------------------------------------------------- |
| `FLOAT _walkSpeed`           | `private float _walkSpeed = 6f;`                     |
| `BOOL _invertY`              | `private bool _invertY = false;`                     |
| `VECTOR3 _movementDirection` | `private Vector3 _movementDirection = Vector3.zero;` |
| `REFERENCE _playerCamera`    | `private Camera _playerCamera;`                      |

`[SerializeField]` allows a private variable to still appear inside the Unity Inspector.

`[Header()]` does not affect how the program works. It simply organises the variables inside the Inspector.

---

# 2. Player Movement

The `PlayerMovement()` method controls walking, sprinting, crouching, jumping and gravity.

## Pseudocode

```text
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

    //SET _movementDirection.y by _gravity
    //    MULTIPLIED by Time.deltaTime
    //    ADDED to existing y

    //SET _characterController.Move by _movementDirection
    //    MULTIPLIED by Time.deltaTime
}

#endregion
```

---

## Checking if the Player is Grounded

### Pseudocode

```text
IF _characterController isGrounded THEN
```

### C#

```csharp
if (_characterController.isGrounded)
{
```

`isGrounded` is provided by Unity's `CharacterController`.

It tells us whether the controller is currently touching the ground.

We only calculate new movement and jumping while the player is grounded.

---

# 3. Walking, Sprinting and Crouching

The player can move at three different speeds.

## Pseudocode

```text
IF INPUT LeftShift is Pressed THEN
    SET _movementSpeed to _sprintSpeed

ELSE IF INPUT LeftControl is Pressed THEN
    SET _movementSpeed to _crouchSpeed

ELSE
    SET _movementSpeed to _walkSpeed
ENDIF
```

## C#

```csharp
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
```

The program checks the conditions **from top to bottom**.

If `LeftShift` is being held, the player sprints.

If the player is not sprinting, the program checks whether `LeftControl` is being held.

If neither key is being held, the player uses the normal walking speed.

---

# 4. Reading Movement Input

Unity's Horizontal and Vertical input axes allow us to read keyboard movement.

## Pseudocode

```text
SET _movementDirection To Both Horizontal Vertical INPUT
```

## C#

```csharp
float horizontalInput = Input.GetAxis("Horizontal");
float verticalInput = Input.GetAxis("Vertical");

_movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
```

The standard Unity input axes normally map to:

| Axis       | Typical Keys          |
| ---------- | --------------------- |
| Horizontal | A / D or Left / Right |
| Vertical   | W / S or Up / Down    |

We combine both values into a `Vector3`.

```csharp
new Vector3(horizontalInput, 0f, verticalInput);
```

The three values represent:

```text
X = Left / Right
Y = Up / Down
Z = Forward / Backward
```

We use `0f` for Y because normal ground movement should not move the player vertically.

---

# 5. Applying Movement Speed

## Pseudocode

```text
SET _movementDirection MULTIPLIED by _movementSpeed
```

## C#

```csharp
_movementDirection *= _movementSpeed;
```

Without this step, the input values would normally only range between `-1` and `1`.

Multiplying the direction by `_movementSpeed` determines how quickly the player moves.

---

# 6. Changing Local Movement into World Movement

## Pseudocode

```text
SET _movementDirection TransformDirection
```

## C#

```csharp
_movementDirection = transform.TransformDirection(_movementDirection);
```

The movement input starts as a direction relative to the player.

`TransformDirection()` converts that direction so movement follows the direction the player is facing.

This means pressing **W** moves the player forward from their current perspective rather than always moving in the same world direction.

---

# 7. Jumping

## Pseudocode

```text
IF INPUT Space is Pressed THEN
    SET _movementDirection.y to _jumpSpeed
ENDIF
```

## C#

```csharp
if (Input.GetKeyDown(KeyCode.Space))
{
    _movementDirection.y = _jumpSpeed;
}
```

`GetKeyDown()` becomes true only on the frame the key is first pressed.

When Space is pressed, we change the Y value of the movement direction.

```csharp
_movementDirection.y = _jumpSpeed;
```

A positive Y value moves the player upward.

---

# 8. Gravity

Jumping pushes the player upward, but we also need gravity to pull the player back down.

## Pseudocode

```text
SET _movementDirection.y by _gravity
MULTIPLIED by Time.deltaTime
ADDED to existing y
```

## C#

```csharp
_movementDirection.y += _gravity * Time.deltaTime;
```

Notice that we use:

```csharp
+=
```

instead of:

```csharp
=
```

This is important.

Using `+=` means gravity is continuously **added to the existing vertical velocity**.

For example:

```text
Jump starts at:

Y = 8

Gravity changes it over time:

8
7.6
7.2
6.8
...
0
...
-2
-4
-6
```

The player first moves upward, slows down, and then begins falling.

---

# 9. Moving the CharacterController

## Pseudocode

```text
SET _characterController.Move by _movementDirection
MULTIPLIED by Time.deltaTime
```

## C#

```csharp
_characterController.Move(_movementDirection * Time.deltaTime);
```

The `CharacterController.Move()` method actually applies the movement to the player.

`Time.deltaTime` makes the movement **frame-rate independent**.

Without it, the movement speed could change depending on how many frames per second the computer is running.

---

# Complete Player Movement Method

```csharp
#region Player Movement

void PlayerMovement()
{
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
```

---

# 10. Camera Control

The next method controls where the player looks using the mouse.

## Pseudocode

```text
#region Camera Control

void CameraControl()
{
    //GET mouse X input MULTIPLIED by sensitivity
    //ROTATE player around Y-axis by that amount

    //GET mouse Y input MULTIPLIED by sensitivity
    //ADD result to _rotationX

    //CLAMP _rotationX between -_lookLimit and _lookLimit

    //IF invert is enabled THEN
    //    SET verticalRotation to _rotationX
    //ELSE
    //    SET verticalRotation to negative _rotationX
    //ENDIF

    //SET camera's local rotation X-axis to verticalRotation
    //Y and Z stay 0
}

#endregion
```

---

# 11. Reading Mouse Input

## Pseudocode

```text
GET mouse X input MULTIPLIED by sensitivity

GET mouse Y input MULTIPLIED by sensitivity
```

## C#

```csharp
float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;
```

The mouse produces two separate values.

```text
Mouse X = Left and Right

Mouse Y = Up and Down
```

We multiply both values by `_mouseSensitivity` so we can control how quickly the camera responds.

---

# 12. Rotating the Player Left and Right

## Pseudocode

```text
ROTATE player around Y-axis by mouse X
```

## C#

```csharp
transform.Rotate(Vector3.up * mouseX);
```

Horizontal mouse movement rotates the **entire player**.

The rotation happens around the Y-axis.

```text
        Y
        ↑

        Player
       ↺     ↻
```

This allows movement to follow the direction the player is looking.

---

# 13. Tracking Vertical Camera Rotation

## Pseudocode

```text
ADD mouse Y result to _rotationX
```

## C#

```csharp
_rotationX += mouseY;
```

Unlike horizontal rotation, we keep track of the vertical camera angle ourselves.

`_rotationX` acts as a **running total**.

For example:

```text
_rotationX = 0

Mouse moves upward by 2

_rotationX = 2

Mouse moves upward by another 2

_rotationX = 4
```

---

# 14. Limiting Camera Rotation

Without a limit, the player could rotate the camera completely around vertically.

To prevent this, we clamp the camera angle.

## Pseudocode

```text
CLAMP _rotationX between -_lookLimit and _lookLimit
```

## C#

```csharp
_rotationX = Mathf.Clamp(
    _rotationX,
    -_lookLimit,
    _lookLimit
);
```

If `_lookLimit` is:

```csharp
80f
```

then `_rotationX` can only be between:

```text
-80 degrees

and

80 degrees
```

---

# 15. Inverting the Y-Axis

Some players prefer inverted camera controls.

## Pseudocode

```text
IF invert is enabled THEN
    SET verticalRotation to _rotationX
ELSE
    SET verticalRotation to negative _rotationX
ENDIF
```

The long-form C# version would be:

```csharp
float verticalRotation;

if (_invertY)
{
    verticalRotation = _rotationX;
}
else
{
    verticalRotation = -_rotationX;
}
```

The finished script uses a shorter C# conditional expression:

```csharp
float verticalRotation = _invertY ? _rotationX : -_rotationX;
```

Both versions perform the same decision.

---

# 16. Applying the Camera Rotation

## Pseudocode

```text
SET camera's local rotation X-axis to verticalRotation
Y and Z stay 0
```

## C#

```csharp
_playerCamera.transform.localRotation =
    Quaternion.Euler(verticalRotation, 0f, 0f);
```

The camera only rotates vertically.

```text
X = verticalRotation
Y = 0
Z = 0
```

The player GameObject handles left and right rotation while the camera handles up and down rotation.

---

# Complete Camera Control Method

```csharp
#region Camera Control

void CameraControl()
{
    float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

    transform.Rotate(Vector3.up * mouseX);

    _rotationX += mouseY;

    _rotationX = Mathf.Clamp(
        _rotationX,
        -_lookLimit,
        _lookLimit
    );

    float verticalRotation = _invertY
        ? _rotationX
        : -_rotationX;

    _playerCamera.transform.localRotation =
        Quaternion.Euler(verticalRotation, 0f, 0f);
}

#endregion
```

---

# 17. Start()

`Start()` runs once when the GameObject becomes active.

We use it to find required components and configure the mouse cursor.

## Pseudocode

```text
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
}
```

---

## Finding the CharacterController

### Pseudocode

```text
IF _characterController is NOT assigned THEN
    GET CharacterController component from this GameObject
ENDIF
```

### C#

```csharp
if (_characterController == null)
{
    _characterController = GetComponent<CharacterController>();
}
```

`null` means the variable currently has no object assigned to it.

If it is empty, `GetComponent<CharacterController>()` looks for a `CharacterController` attached to the same GameObject.

---

# 18. Finding the Camera

## Pseudocode

```text
IF _playerCamera is NOT assigned THEN
    GET Camera component from children
ENDIF
```

## C#

```csharp
if (_playerCamera == null)
{
    _playerCamera = GetComponentInChildren<Camera>();
}
```

The player's camera is normally placed as a **child GameObject** of the player.

`GetComponentInChildren<Camera>()` searches the player's children for a Camera component.

---

# 19. Locking the Cursor

## Pseudocode

```text
LOCK cursor to center of screen
HIDE cursor
```

## C#

```csharp
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
```

For a first-person controller, we normally do not want the mouse pointer moving around the screen during gameplay.

Instead, mouse movement should control the camera.

---

# Complete Start Method

```csharp
void Start()
{
    if (_characterController == null)
    {
        _characterController =
            GetComponent<CharacterController>();
    }

    if (_playerCamera == null)
    {
        _playerCamera =
            GetComponentInChildren<Camera>();
    }

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}
```

---

# 20. Update()

`Update()` runs once every frame.

This is where we call the methods that need to continually check player input.

## Pseudocode

```text
void Update()
{
    //CALL PlayerMovement
    //CALL CameraControl
}
```

## C#

```csharp
void Update()
{
    PlayerMovement();
    CameraControl();
}
```

Notice the brackets:

```csharp
PlayerMovement();
```

This means:

```text
Run the PlayerMovement method.
```

And:

```csharp
CameraControl();
```

means:

```text
Run the CameraControl method.
```

The methods contain the instructions, but they will not run automatically just because we created them.

Calling them from `Update()` tells Unity to run them every frame.

---

# 21. RequireComponent

At the top of the script we also have:

```csharp
[RequireComponent(typeof(CharacterController))]
```

This tells Unity that this script requires a `CharacterController`.

If the script is added to a GameObject without one, Unity automatically adds the required component.

---

# Complete First Person Controller

```csharp
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    #region Variables

    [Header("References")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera _playerCamera;

    [Header("Movement Speeds")]
    [SerializeField] private float _walkSpeed = 6f;
    [SerializeField] private float _sprintSpeed = 10f;
    [SerializeField] private float _crouchSpeed = 3f;
    [SerializeField] private float _movementSpeed;

    [Header("Jump / Gravity")]
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float _gravity = -20f;

    private Vector3 _movementDirection = Vector3.zero;

    [Header("Mouse Look")]
    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private float _lookLimit = 80f;
    [SerializeField] private bool _invertY = false;

    private float _rotationX = 0f;

    #endregion

    #region Player Movement

    void PlayerMovement()
    {
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

            _movementDirection =
                new Vector3(horizontalInput, 0f, verticalInput);

            _movementDirection *= _movementSpeed;

            _movementDirection =
                transform.TransformDirection(_movementDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movementDirection.y = _jumpSpeed;
            }
        }

        _movementDirection.y +=
            _gravity * Time.deltaTime;

        _characterController.Move(
            _movementDirection * Time.deltaTime
        );
    }

    #endregion

    #region Camera Control

    void CameraControl()
    {
        float mouseX =
            Input.GetAxis("Mouse X") * _mouseSensitivity;

        float mouseY =
            Input.GetAxis("Mouse Y") * _mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        _rotationX += mouseY;

        _rotationX = Mathf.Clamp(
            _rotationX,
            -_lookLimit,
            _lookLimit
        );

        float verticalRotation =
            _invertY ? _rotationX : -_rotationX;

        _playerCamera.transform.localRotation =
            Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    #endregion

    #region UnityEvents

    void Start()
    {
        if (_characterController == null)
        {
            _characterController =
                GetComponent<CharacterController>();
        }

        if (_playerCamera == null)
        {
            _playerCamera =
                GetComponentInChildren<Camera>();
        }

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
```

---

# Pseudocode to C# Quick Reference

| Pseudocode                   | C#                                |
| ---------------------------- | --------------------------------- |
| `IF condition THEN`          | `if (condition)`                  |
| `ELSE IF condition THEN`     | `else if (condition)`             |
| `ELSE`                       | `else`                            |
| `ENDIF`                      | `}`                               |
| `SET x to value`             | `x = value;`                      |
| `ADD value to x`             | `x += value;`                     |
| `MULTIPLY x by value`        | `x *= value;`                     |
| `is equal to`                | `==`                              |
| `is NOT equal to`            | `!=`                              |
| `is NOT assigned`            | `== null`                         |
| `CALL PlayerMovement`        | `PlayerMovement();`               |
| `INPUT Space is Pressed`     | `Input.GetKeyDown(KeyCode.Space)` |
| `INPUT LeftShift is Pressed` | `Input.GetKey(KeyCode.LeftShift)` |
| `GET Horizontal INPUT`       | `Input.GetAxis("Horizontal")`     |
| `GET Mouse X INPUT`          | `Input.GetAxis("Mouse X")`        |

---

# How the Controller Works

Each frame Unity calls:

```csharp
Update();
```

`Update()` then calls:

```csharp
PlayerMovement();
CameraControl();
```

The overall flow is:

```text
UPDATE
│
├── PlayerMovement
│   │
│   ├── Check if grounded
│   ├── Choose walk / sprint / crouch speed
│   ├── Read movement input
│   ├── Create movement direction
│   ├── Apply movement speed
│   ├── Convert movement to player direction
│   ├── Check for jump
│   ├── Apply gravity
│   └── Move CharacterController
│
└── CameraControl
    │
    ├── Read Mouse X
    ├── Rotate player left / right
    ├── Read Mouse Y
    ├── Update vertical camera angle
    ├── Clamp camera angle
    ├── Check invert Y
    └── Rotate camera up / down
```

The important idea is that we did not start with C#.

We first worked out the **logic**, represented that logic using **pseudocode**, and then translated each instruction into the correct C# syntax.
