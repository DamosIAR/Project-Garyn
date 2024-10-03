using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGaryn
{
    public class PlayerLightStoppingState : PlayerStoppingState
    {
        public PlayerLightStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }


        #region IState Method
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementDecelerationForce = movementData.StopData.LightDecelerationForce;
        }
        #endregion
    }
}
