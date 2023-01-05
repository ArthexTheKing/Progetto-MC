using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    #region Protected Variables

    protected int xInput;
    protected int yInput;

    protected bool isTouchingWall;
    protected bool isTouchingCeiling;

    #endregion

    #region Private Variables

    private bool jumpInput;
    private bool isGrounded;

    #endregion

    #region Constructors

    public PlayerGroundedState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = core.CollisionSenses.Grounded;
        isTouchingWall = core.CollisionSenses.WallFront;
        isTouchingCeiling = core.CollisionSenses.Ceiling;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        jumpInput = player.InputHandler.JumpInput;

        core.Movement.CheckIfShouldFlip(xInput);

        if (!isTouchingCeiling)
        {
            if (player.InputHandler.AttackInput)
            {
                stateMachine.ChangeState(player.AttackState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!isGrounded)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    #endregion
}