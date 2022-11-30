using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler:MonoBehaviour
{
    private Movement playerActionMap;
    public bool IsJumpButtonPressed { get; private set; }
    public bool IsCrouchButtonPressed { get; private set; }
    public float HorizontalMovement { get; private set; }
    public bool CanJump { get; private set; }
    private void Start()
    {
        CanJump = false;
        playerActionMap = new Movement();
        playerActionMap.Enable();
        connectEventsToFunctions();
    }
    private void OnDisable()
    {
        playerActionMap.Disable();
        disableEvents();
    }
    private void connectEventsToFunctions()
    {
        playerActionMap.PlayerMovement.Jump.canceled += jumpButtonReleased;
        playerActionMap.PlayerMovement.Jump.performed += jumpButtonPressed;
    }
  
    private void jumpButtonReleased(InputAction.CallbackContext obj)
    {
        Debug.Log("released");
      
        CanJump = false;
        IsJumpButtonPressed = false;
    }

    private void jumpButtonPressed(InputAction.CallbackContext obj)
    {
        CanJump = true;
        IsJumpButtonPressed = true;
    }
    public void setCanJumpToFalse()
    {
        CanJump = false;
    }

    private void crounchButtonReleased(InputAction.CallbackContext obj)
    {
        IsCrouchButtonPressed=false;
     
    }

    private void crounchButtonPressed(InputAction.CallbackContext obj)
    {
       IsCrouchButtonPressed=true;
        
    }

    private void Update()
    {
     
        HorizontalMovement=playerActionMap.PlayerMovement.Horizontal.ReadValue<float>();
    }
    private void disableEvents()
    {
        playerActionMap.PlayerMovement.Jump.canceled -= jumpButtonReleased;
        playerActionMap.PlayerMovement.Jump.performed -= jumpButtonPressed;
    }

}
