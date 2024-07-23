using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    Player player;

    bool attack = false;

    public IdleState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        player = character as Player;
    }

    public override void Enter()
    {
        base.Enter();

        attack = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (player.attackAction.WasPressedThisFrame())
        {
            attack = true;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (attack)
        {
            attack = false;
            stateMachine.ChangeState(player.attackState);
        }
    }
}
