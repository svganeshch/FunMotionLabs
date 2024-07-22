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

    // Input Actions
    private InputAction moveAction;

    protected override void Awake()
    {
        base.Awake();

        input = GetComponent<PlayerInput>();
    }

    protected override void Start()
    {
        base.Start();

        moveAction = input.actions["Move"];

        moveAction.performed += i => moveInput = i.ReadValue<Vector2>();
    }

    protected override void Update()
    {
        base.Update();

        horizontalInput = moveInput.x;
        verticalInput = moveInput.y;
    }
}
