using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGaryn
{
    public class PlayerMovementStateMachine : StateMachine
    {
       public Player Player { get; }
        public PlayerStateReusableData ReusableData { get; }
       public PlayerIdlingState idlingState { get; }
       public PlayerDashingState DashingState { get; }
       public PlayerWalkingState WalkingState { get; }
       public PlayerRunningState RunningState { get; }
       public PlayerSprintingState SprintingState { get; }

       public PlayerMovementStateMachine(Player player)
       {
           Player = player;
           ReusableData = new PlayerStateReusableData();
           idlingState = new PlayerIdlingState(this);
           DashingState = new PlayerDashingState(this);

           WalkingState = new PlayerWalkingState(this);
           RunningState = new PlayerRunningState(this);
           SprintingState = new PlayerSprintingState(this);    
       }
    }
}
