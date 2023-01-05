using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    #region Constructors

    public PlayerCrouchIdleState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
        player.SetColliderHeight(playerData.crouchColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0 && !isTouchingWall)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }
            else if (yInput != -1 && !isTouchingCeiling)
            {
                stateMachine.ChangeState(player.IdleState);
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