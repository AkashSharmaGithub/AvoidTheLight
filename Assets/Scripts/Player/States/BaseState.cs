using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseState
{
    public void onStateEntered(StateManager stateManager);
      
    public void onStateStayed(StateManager stateManager);
    public void onStateExited(StateManager stateManager);
   
}
