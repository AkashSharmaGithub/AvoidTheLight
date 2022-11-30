using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StateManager), typeof(Rigidbody))]
public class PlayerMovementHandler : MonoBehaviour
{
    private StateManager manager;
    public Rigidbody PlayerRigidbody { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float JumpHeight { get; private set; }
    [field: SerializeField] public int TotalJumps { get; private set; }
    
    public bool CanStopJump { get; private set; }

    public int CurrentJumps { get; private set; }

    public bool HasJumped { get; private set; }
    public bool isMoving { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        CanStopJump = false;
        manager =GetComponent<StateManager>();
        PlayerRigidbody=GetComponent<Rigidbody>();
    }

    public void performLeftRightMovement()
    {
        isMoving = false;
        if (manager.InputHandler.HorizontalMovement != 0)
        {
            isMoving = true;

            PlayerRigidbody.velocity = new Vector3(0, PlayerRigidbody.velocity.y, -manager.InputHandler.HorizontalMovement * Speed * Time.deltaTime);
            if((manager.InputHandler.HorizontalMovement<0 && transform.localScale.z>0)|| (manager.InputHandler.HorizontalMovement > 0 && transform.localScale.z < 0))
            {
                transform.localScale=new Vector3(transform.localScale.x,transform.localScale.y,-transform.localScale.z);
            }
            
        }


    }
    public void Jump()
    {
        if (CurrentJumps < TotalJumps)
        {

            if (manager.InputHandler.CanJump)
            {
                manager.InputHandler.setCanJumpToFalse();
                HasJumped = true;

                  CurrentJumps++;
                PlayerRigidbody.velocity = new Vector3(PlayerRigidbody.velocity.x, JumpHeight, PlayerRigidbody.velocity.z);
                CanStopJump = true;
            }
        }
        else
        {
            manager.InputHandler.setCanJumpToFalse();

        }

    }
    public void stopJumping()
    {
        if (CanStopJump)
        {
            CanStopJump = false;
            HasJumped=false;
                if (PlayerRigidbody.velocity.y<0)
                {
                    return;
                }
           
            PlayerRigidbody.velocity = new Vector3(PlayerRigidbody.velocity.x, 0, PlayerRigidbody.velocity.z);
            Debug.Log("stop jumping ");
        }
    }
    public void resetCurrentJumps()
    {
        CurrentJumps=0;
    }
    public void setHasJumpedToFalse()
    {
        HasJumped = false;
    }
}
