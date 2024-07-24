using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Player player;

    bool attack = false;

    public AttackState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        player = character as Player;
    }

    public override void Enter()
    {
        base.Enter();

        player.playerAnimatorManager.PlayAttackAnimation(false);
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

            if (player.canCombo)
            {
                player.canCombo = false;

                player.playerAnimatorManager.PlayAttackAnimation(true);
            }
        }
    }
}
