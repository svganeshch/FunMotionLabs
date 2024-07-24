using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    Enemy enemy;

    bool coolDownCoroutineStarted = false;
    float coolDownTimer = 0f;
    float coolDownDuration = 2.5f;

    public EnemyIdleState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        enemy = character as Enemy;
    }

    public override void Enter()
    {
        base.Enter();

        coolDownCoroutineStarted = false;
        coolDownTimer = 0f;

        enemy.navMeshAgent.SetDestination(enemy.playerTarget.transform.position);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.navMeshAgent.SetDestination(enemy.playerTarget.transform.position);

        if (enemy.coolDown)
        {
            CheckCoolDown();
        }
        else
        {
            if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance)
            {
                stateMachine.ChangeState(enemy.attackState);
            }
        }
    }

    private void CheckCoolDown()
    {
        coolDownTimer += Time.deltaTime;

        if (coolDownTimer > coolDownDuration)
        {
            enemy.coolDown = false;
            coolDownTimer = 0;
        }
    }
}
