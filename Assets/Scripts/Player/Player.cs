using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    PlayerInput input;

    // Move Inputs
    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    [HideInInspector] public Vector2 lookInput;

    // Input Actions
    private InputAction moveAction;
    private InputAction lookAction;

    // Managers
    [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;

    protected override void Awake()
    {
        base.Awake();

        input = GetComponent<PlayerInput>();

        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }

    protected override void Start()
    {
        base.Start();

        moveAction = input.actions["Move"];
        lookAction = input.actions["Look"];

        moveAction.performed += i => moveInput = i.ReadValue<Vector2>();
        lookAction.performed += i => lookInput = i.ReadValue<Vector2>();
    }

    protected override void Update()
    {
        base.Update();

        horizontalInput = moveInput.x;
        verticalInput = moveInput.y;
    }
}
