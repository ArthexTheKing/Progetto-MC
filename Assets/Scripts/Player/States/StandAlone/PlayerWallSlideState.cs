using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    #region Private Variables

    private int xInput;

    private bool isGrounded;
    private bool isTouchingWall;
    private bool jumpInput;

    #endregion

    #region Constructors

    public PlayerWallSlideState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;

        if(!isExitingState)
        {
            if (jumpInput)
            {
                player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
                stateMachine.ChangeState(player.WallJumpState);
            }
            else if (isGrounded)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (!isTouchingWall || xInput != player.FacingDirection)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else
            {
                player.SetVelocityY(-playerData.wallSlideVelocity);
            }
        }
    }
    #endregion
}