using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(PlayerInputHandler),typeof(PlayerMovementHandler),typeof(PlayerAnimationManager))]
public class StateManager : MonoBehaviour
{
    
   
    public PlayerMovementHandler PlayerMovement { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerAnimationManager PlayerAnimationHandler { get; private set; }

    public PlayerGroundState GroundState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerHideState HideState { get; private set; }
    public BaseState CurrentState { get; private set; }
    
    public bool IsGrounded { get; private set; }


    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovementHandler>();
        InputHandler = GetComponent<PlayerInputHandler>();
        PlayerAnimationHandler = GetComponent<PlayerAnimationManager>();
        GroundState = new PlayerGroundState();
        JumpState = new PlayerJumpState();
        HideState = new PlayerHideState();
        CurrentState=GroundState;
        
    }
    private void Start()
    {
        changeState(CurrentState);
        
    }
    private void Update()
    {
        Debug.Log("CurrentState:" + CurrentState);
        CurrentState.onStateStayed(this);
    }
    public void changeState(BaseState state)
    {
        CurrentState = state;
        state.onStateEntered(this);
    }
 
    
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("platform"))
        {
            IsGrounded = true;
            PlayerAnimationHandler.setBooleanInController(PlayerAnimationHandler.IsFalling, false);
            PlayerAnimationHandler.setBooleanInController(PlayerAnimationHandler.IsGrounded, IsGrounded);
            PlayerAnimationHandler.setBooleanInController(PlayerAnimationHandler.HasJumped, false);
            PlayerMovement.resetCurrentJumps();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
        PlayerAnimationHandler.setBooleanInController(PlayerAnimationHandler.IsGrounded, IsGrounded);
    }
}
