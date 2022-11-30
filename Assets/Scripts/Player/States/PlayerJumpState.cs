using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : BaseState
{
    public void onStateEntered(StateManager stateManager)
    {

    }

    public void onStateStayed(StateManager stateManager)
    {
        stateManager.PlayerMovement.Jump();
     
        if (stateManager.PlayerMovement.HasJumped)
        {
            stateManager.PlayerAnimationHandler.setBooleanInController(stateManager.PlayerAnimationHandler.HasJumped, stateManager.PlayerMovement.HasJumped);
            stateManager.PlayerMovement.setHasJumpedToFalse();
           
        }
        if (stateManager.PlayerMovement.PlayerRigidbody.velocity.y<0 )
        {
            stateManager.PlayerAnimationHandler.setBooleanInController(stateManager.PlayerAnimationHandler.IsFalling, true);

        }
        else if(stateManager.PlayerMovement.PlayerRigidbody.velocity.y > 0)
        {
            stateManager.PlayerAnimationHandler.setBooleanInController(stateManager.PlayerAnimationHandler.IsFalling, false);
        }
        stateManager.PlayerMovement.performLeftRightMovement();
        if (stateManager.InputHandler.IsJumpButtonPressed==false)
        {

            Debug.Log("Jump button false");
            stateManager.PlayerMovement.stopJumping();
        }
        if (stateManager.IsGrounded == true)
        {
            stateManager.changeState(stateManager.GroundState);
        }
    }
    public void onStateExited(StateManager stateManager)
    {
    
    }


    
}
