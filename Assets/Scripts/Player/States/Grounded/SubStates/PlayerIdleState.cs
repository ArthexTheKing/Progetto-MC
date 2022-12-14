using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    #region Constructors

    public PlayerIdleState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0 && !isTouchingWall)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
        }
    }

    #endregion
}