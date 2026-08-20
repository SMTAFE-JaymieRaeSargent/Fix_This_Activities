using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Variables
    // REFERENCE _playerCamera (Camera)  
    // FLOAT _mouseSensitivity
    // FLOAT _maxLookAngle
    // BOOL _isYInverted
    // FLOAT _totalVerticalRotation
    // FLOAT _horizontalInput 
    // FLOAT _verticalInput
    //FLOAT _finalVerticalRotation
    #endregion

    #region Camera Control
    void CameraControl()
    {
        //GET mouse X input MULTIPLIED by sensitivity

        //ROTATE player (transform) around Y-axis by that amount

        //GET mouse Y input MULTIPLIED by sensitivity

        //ADD result to _totalVerticalRotation (running total)

        //CLAMP _totalVerticalRotation between -_maxLookAngle and _maxLookAngle

        //IF invert is enabled THEN
        
            //    SET _finalVerticalRotation to _totalVerticalRotation
        
        //ELSE
        
            //    SET _finalVerticalRotation to negative _totalVerticalRotation

        
        //ENDIF

        //SET camera's local rotation X-axis to _finalVerticalRotation (Y and Z stay 0)
    }
    #endregion

    #region UnityEvents
    void Start()
    {
        //IF _playerCamera is NOT assigned THEN
        
            //    GET Camera component from children
        
        //ENDIF
    }

    void Update()
    {
        //CALL CameraControl
    }
    #endregion
}