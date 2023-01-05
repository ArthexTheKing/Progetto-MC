using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    #region Protected Variables

    protected bool isAbilityDone;

    #endregion

    #region Private Variables

    private bool isGrounded;

    #endregion

    #region Contructors

    public PlayerAbilityState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = core.CollisionSenses.Grounded;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAbilityDone)
        {
            if(isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }
    #endregion
}