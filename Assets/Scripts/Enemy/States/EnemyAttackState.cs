using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    Enemy enemy;

    float comboProbability = 0.15f;
    int totalCombos = 3;
    int comboCount = 0;

    public EnemyAttackState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        enemy = character as Enemy;
    }

    public override void Enter()
    {
        base.Enter();

        comboCount = 0;
        enemy.characterAnimatorManager.PlayAttackAnimation(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.navMeshAgent.SetDestination(enemy.playerTarget.transform.position);

        if (enemy.navMeshAgent.remainingDistance > enemy.navMeshAgent.stoppingDistance + 0.5f)
        {
            stateMachine.ChangeState(enemy.idleState);
            return;
        }

        if (comboCount >= totalCombos)
        {
            enemy.coolDown = true;
            stateMachine.ChangeState(enemy.idleState);

            return;
        }

        if (Random.value <= comboProbability)
        {
            if (enemy.canCombo)
            {
                enemy.canCombo = false;
                enemy.characterAnimatorManager.PlayAttackAnimation(true);

                comboCount++;
            }
        }
    }
}
