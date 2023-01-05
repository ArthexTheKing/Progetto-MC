using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    #region Private Variables

    private int amountOfJumpsLeft;

    #endregion

    #region Constructors

    public PlayerJumpState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
        amountOfJumpsLeft = this.playerData.amountOfJumps;
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        core.Movement.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        DecreaseAmountOfJumpsLeft();
        player.InAirState.SetIsJumping();
    }

    #endregion

    #region Public Functions

    public bool CanJump() => amountOfJumpsLeft > 0;

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;

    #endregion
}