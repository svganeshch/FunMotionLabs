using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    Enemy enemy;

    public EnemyIdleState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        enemy = character as Enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.navMeshAgent.SetDestination(enemy.playerTarget.transform.position);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.navMeshAgent.SetDestination(enemy.playerTarget.transform.position);
    }
}
