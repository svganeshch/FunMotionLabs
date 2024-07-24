using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public Player playerTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    protected override void Awake()
    {
        base.Awake();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void SetupStates()
    {
        base.SetupStates();

        idleState = new EnemyIdleState(this, characterStateMachine);

        characterStateMachine.Initialize(idleState);
    }
}
