using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float RotationSpeed;
    private PlayerActionController _playerActionController;
    private Camera _camera;
    private Vector3 _targetPoint;
    private Vector2 _delta;
    private Vector3 _direction;
    private void Awake()
    {
        _playerActionController = new PlayerActionController();
        // _camera = Camera.main;
    }

    private void Start()
    {
        _playerActionController.PhoneControl.TouchControl.performed += context => Touch(context);
    }

    private void OnEnable()
    {
        _playerActionController.Enable();
    }

    private void OnDisable()
    {
        _playerActionController.Disable();
    }

    private void Touch(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        
        if (_delta != Vector2.zero)
        {
            //find the vector pointing from our position to the target
            _direction = new Vector3(_delta.x, 0f,_delta.y);
            
            //create the rotation we need to be in to look at the target
            var _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed); 
        }

        if (GameplayManager.Instance._currentState == GameStates.Playing)
        {
            transform.position += transform.forward * (Time.deltaTime * GameplayManager.Instance.playerSpeed);
        }
    }
}
