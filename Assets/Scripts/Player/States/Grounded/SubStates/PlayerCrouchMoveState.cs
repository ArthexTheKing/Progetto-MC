using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    #region Constructors

    public PlayerCrouchMoveState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();

        player.SetColliderHeight(playerData.crouchColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            core.Movement.SetVelocityX(playerData.crouchMovementVelocity * xInput);

            if (xInput == 0 || isTouchingWall)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else if (yInput != -1 && !isTouchingCeiling)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.SetColliderHeight(playerData.standColliderHeight);
    }

    #endregion
}