using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Player player;

    public AttackState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        player = character as Player;
    }

    public override void Enter()
    {
        base.Enter();

        player.playerAnimatorManager.PlayAttackAnimation();
    }
}
