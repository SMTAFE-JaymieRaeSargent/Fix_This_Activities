using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    // REFERENCE _characterController (CharacterController)
    // FLOAT _walkSpeed
    // FLOAT _sprintSpeed
    // FLOAT _crouchSpeed
    // FLOAT _movementSpeed
    // FLOAT _jumpSpeed
    // FLOAT _gravity
    // VECTOR3 _movementDirection
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
    }
    #endregion

    #region UnityEvents
    void Start()
    {
        //IF _characterController is NOT assigned THEN
        
            //    GET CharacterController component from this GameObject
        //ENDIF

    }

    void Update()
    {
        //CALL PlayerMovementUpdate
    }
    #endregion
}