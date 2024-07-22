using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [HideInInspector] public CharacterController characterController;

    [Header("Player Controls")]
    public float walkSpeed = 5f;
    public float rotationDampTime = 15f;

    // FSM
    State idleState;
    StateMachine characterStateMachine;

    protected virtual void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    protected virtual void Start()
    {
        characterStateMachine = new StateMachine();
        idleState = new IdleState(this, characterStateMachine);

        characterStateMachine.Initialize(idleState);
    }

    protected virtual void Update()
    {
        characterStateMachine.currentState.HandleInput();
        characterStateMachine.currentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        characterStateMachine.currentState.PhysicsUpdate();
    }

    public virtual void OnDrawGizmos()
    {
        characterStateMachine?.currentState.OnDrawGizmos();
    }
}
