using Cinemachine;
using UnityEngine;

public abstract class CharacterMovementManager : MonoBehaviour
{
    protected Vector3 moveDirection;

    protected float xAxisValue, yAxisValue;
    protected Quaternion xQuat;
    protected Quaternion yQuat;
    protected Quaternion targetRotation;
    protected Quaternion finalRotation;

    protected float horizontalInput;
    protected float verticalInput;

    protected Character character;

    protected Transform playerCamera;

    public virtual void Start()
    {
        character = GetComponent<Character>();
        playerCamera = Camera.main.transform;
    }

    public virtual void Update()
    {
        HandleGroundedMovement();
        HandleRotation();
    }

    protected virtual void HandleGroundedMovement()
    {
        GetMovementInput();

        moveDirection = playerCamera.forward * verticalInput;
        moveDirection += playerCamera.right * horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        character.characterAnimatorManager.SetAnimatorParameters(horizontalInput, verticalInput, false);

        float speed = character.walkSpeed;

        character.characterController.Move(speed * Time.deltaTime * moveDirection);

        //Debug.Log("move : " + horizontalInput + ", " + verticalInput);
    }

    protected virtual void HandleRotation()
    {
        targetRotation = playerCamera.rotation;
        finalRotation = Quaternion.Slerp(character.transform.rotation, targetRotation, character.rotationDampTime * Time.deltaTime);

        character.transform.rotation = targetRotation;
    }

    public abstract void GetMovementInput();
    public abstract void GetMouseInput();
}