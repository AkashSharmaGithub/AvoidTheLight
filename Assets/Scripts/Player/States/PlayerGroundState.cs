using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : BaseState
{
    public void onStateEntered(StateManager stateManager)
    {
    }
    public void onStateStayed(StateManager stateManager)
    {
        stateManager.PlayerMovement.performLeftRightMovement();
        stateManager.PlayerAnimationHandler.setBooleanInController(stateManager.PlayerAnimationHandler.IsMoving, stateManager.PlayerMovement.isMoving);

        stateManager.PlayerMovement.Jump();
        if(stateManager.PlayerMovement.HasJumped)
        {
         stateManager.PlayerAnimationHandler.setBooleanInController(stateManager.PlayerAnimationHandler.HasJumped, stateManager.PlayerMovement.HasJumped);
            stateManager.PlayerMovement.setHasJumpedToFalse();
            stateManager.changeState(stateManager.JumpState);
        }
      //  checkAnimation(stateManager);
        
        
    }

    private static void checkAnimation(StateManager stateManager)
    {
        if (stateManager.PlayerMovement.isMoving == true && stateManager.PlayerMovement.HasJumped == true)
        {
            stateManager.changeState(stateManager.JumpState);
        }
        else if (stateManager.PlayerMovement.isMoving == false && stateManager.PlayerMovement.HasJumped == true)
        {
            stateManager.changeState(stateManager.JumpState);
        }
        else if (stateManager.PlayerMovement.isMoving == true && stateManager.PlayerMovement.HasJumped == false)
        {
            
        }
        else if (stateManager.PlayerMovement.isMoving==false && stateManager.PlayerMovement.HasJumped == false)
        {
        }
    }

    public void onStateExited(StateManager stateManager)
    {
       
    }


   
}
