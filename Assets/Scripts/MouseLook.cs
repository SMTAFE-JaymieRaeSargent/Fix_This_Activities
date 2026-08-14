using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Variables
    // REFERENCE _playerCamera (Camera)
    [Header("References")]
    [SerializeField] private Camera _playerCamera;

    [Header("Mouse Look")]
    // FLOAT _mouseSensitivity
    [SerializeField] private float _mouseSensitivity = 2f;
    // FLOAT _maxLookAngle
    [SerializeField] private float _maxLookAngle = 80f;
    // BOOL _isYInverted
    [SerializeField] private bool _isYInverted = false;
    // FLOAT _totalVerticalRotation
    private float _totalVerticalRotation = 0f;
    // FLOAT _horizontalInput 
    private float _horizontalInput = 0;
    // FLOAT _verticalInput
    private float _verticalInput = 0;
    //FLOAT _finalVerticalRotation
    float _finalVerticalRotation = 0f;
    #endregion

    #region Camera Control
    void CameraControl()
    {
        //GET mouse X input MULTIPLIED by sensitivity
        _horizontalInput  = Input.GetAxis("Mouse X") * _mouseSensitivity;

        //ROTATE player (transform) around Y-axis by that amount
        transform.Rotate(Vector3.up * _horizontalInput );

        //GET mouse Y input MULTIPLIED by sensitivity
        _verticalInput = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        //ADD result to _totalVerticalRotation (running total)
        _totalVerticalRotation += _verticalInput;

        //CLAMP _totalVerticalRotation between -_maxLookAngle and _maxLookAngle
        _totalVerticalRotation = Mathf.Clamp(_totalVerticalRotation, -_maxLookAngle, _maxLookAngle);

        //IF invert is enabled THEN
        if (_isYInverted == true)
        {
            //    SET _finalVerticalRotation to _totalVerticalRotation
            _finalVerticalRotation = _totalVerticalRotation;
        }
        //ELSE
        else
        {
            //    SET _finalVerticalRotation to negative _totalVerticalRotation
            _finalVerticalRotation = -_totalVerticalRotation;

        }
        //ENDIF

        //SET camera's local rotation X-axis to _finalVerticalRotation (Y and Z stay 0)
        _playerCamera.transform.localRotation = Quaternion.Euler(_finalVerticalRotation, 0f, 0f);
    }
    #endregion

    #region UnityEvents
    void Start()
    {
        //IF _playerCamera is NOT assigned THEN
        if (_playerCamera == null)
        {
            //    GET Camera component from children
            _playerCamera = GetComponentInChildren<Camera>();
        }
        //ENDIF
    }

    void Update()
    {
        //CALL CameraControl
        CameraControl();
    }
    #endregion
}