using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    NavMeshAgent navMeshAgent;

    protected override void Awake()
    {
        base.Awake();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void SetupStates()
    {
        base.SetupStates();

        idleState = new EnemyIdleState(this, characterStateMachine);

        characterStateMachine.Initialize(idleState);
    }
}
