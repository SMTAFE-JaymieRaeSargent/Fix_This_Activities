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

# 3. Camera Control

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

# 4. Start()

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

# 5. Update()

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
