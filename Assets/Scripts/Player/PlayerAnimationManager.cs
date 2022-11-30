using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerAnimationManager : MonoBehaviour
{
    
    public Animator PlayerAnimator { get; private set; }
    public string IsMoving { get; private set; } = "isMoving";
    public string HasJumped { get; private set; } = "hasJumped";
    public string IsCrouched { get; private set; } = "isCrouched";
    public string IsGrounded { get; private set; } = "isGrounded";
    public string IsFalling { get; private set; } = "isFalling";

    public string JumpRun { get; private set; } = "JumpRun";
       public string Idle { get; private set; } = "Idle";
    public string CrounchMove { get; private set; } = "CrouchMove";
   
    private void Awake()
    {
 
        
        PlayerAnimator = GetComponent<Animator>();
       
    }
    public void setBooleanInController(string booleanName,bool value)
    {
        
  
        PlayerAnimator.SetBool(booleanName, value);
    }
}
