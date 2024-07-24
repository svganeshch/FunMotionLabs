using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public Player playerTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    public bool coolDown = false;

    protected override void Awake()
    {
        base.Awake();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (navMeshAgent.velocity.magnitude > 0 )
        {
            characterAnimatorManager.SetAnimatorParameters(0, 1);
        }
    }

    public override void SetupStates()
    {
        base.SetupStates();

        idleState = new EnemyIdleState(this, characterStateMachine);
        attackState = new EnemyAttackState(this, characterStateMachine);

        characterStateMachine.Initialize(idleState);
    }
}
