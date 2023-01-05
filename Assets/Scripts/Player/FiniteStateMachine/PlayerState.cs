using UnityEngine;

public class PlayerState
{
    protected Core core;

    protected Player player;
    protected SO_PlayerData playerData;
    protected PlayerStateMachine stateMachine;

    protected bool isAnimationFinished;
    protected bool isExitingState;
    protected float startTime;

    private readonly string animBoolName;

    public PlayerState(Player player, SO_PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.playerData = playerData;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        core = player.Core;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() => DoChecks();

    public virtual void DoChecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

}
