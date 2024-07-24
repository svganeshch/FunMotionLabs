using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public CharacterController characterController;

    [Header("Player Controls")]
    public float walkSpeed = 5f;
    public float lookSensitivity = 5f;

    [Header("Smoothing Controls")]
    public float animationFadeTime = 0.1f;
    public float speedDampTime = 0.1f;
    public float rotationDampTime = 15f;

    // Animation flags
    public bool applyRootMotion = false;
    public bool canRotate = true;
    public bool canMove = true;
    public bool canCombo = true;

    // Managers
    [HideInInspector] public CharacterAnimatorManager characterAnimatorManager;

    // FSM
    [HideInInspector] public State idleState;
    [HideInInspector] public State attackState;
    [HideInInspector] public State dodgeState;
    [HideInInspector] public StateMachine characterStateMachine;

    protected virtual void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
    }

    protected virtual void Start()
    {
        characterStateMachine = new StateMachine();
        idleState = new IdleState(this, characterStateMachine);
        attackState = new AttackState(this, characterStateMachine);
        dodgeState = new DodgeState(this, characterStateMachine);

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

    public virtual void OnGUI() { }

    public virtual void OnDrawGizmos()
    {
        characterStateMachine?.currentState.OnDrawGizmos();
    }
}
