using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState {

    public PlayerIdleState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {

    }

    public override void Enter() {
        base.Enter();
        player.SetVelocityX(0f);
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if(xInput != 0 && !isTouchingWall && !isExitingState) {
            stateMachine.ChangeState(player.MoveState);
        }
    }

}