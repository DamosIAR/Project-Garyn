using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGaryn
{
    public class PlayerHardStoppingState : PlayerStoppingState
    {
        public PlayerHardStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region IState Method
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementDecelerationForce = movementData.StopData.HardDecelerationForce;
        }
        #endregion

        #region Reusable Method
        protected override void OnMove()
        {
            if (stateMachine.ReusableData.ShouldWalk)
            {
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }
        #endregion
    }
}
