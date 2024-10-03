using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectGaryn
{
    public class PlayerSprintingState : PlayerMovingState
    {
        private PlayerSprintData sprintData;

        private float startTime;

        private bool keepSprinting;
        public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            sprintData = movementData.SprintData;
        }

        #region IState
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementSpeedModifier = sprintData.SpeedModifier;

            startTime = Time.time;
        }

        public override void Exit()
        {
            base.Exit();

            keepSprinting = false;
        }

        public override void Update()
        {
            base.Update();

            if (keepSprinting)
            {
                return;
            }

            if(Time.time < startTime + sprintData.SprintToRunTimer) 
            {
                return;
            }

            StopSprinting();
        }

        #endregion

        #region Main Method

        private void StopSprinting()
        {
            if(stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.idlingState);

                return;
            }
            stateMachine.ChangeState(stateMachine.RunningState);

        }
        #endregion

        #region ReusableMethod
        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Sprint.performed += OnSprintPerformed;
        }


        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Sprint.performed -= OnSprintPerformed;
        }
        #endregion



        #region Input Method

        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.HardStoppingState);
        }
        private void OnSprintPerformed(InputAction.CallbackContext context)
        {
            keepSprinting = true;
        }
        #endregion
    }
}
