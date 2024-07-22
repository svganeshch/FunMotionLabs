using UnityEngine;

public abstract class CharacterMovementManager : MonoBehaviour
{
    protected Vector3 moveDirection;
    protected Vector3 targetRotationDirection;
    protected Vector3 lockedTargetDirection;
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

        character.characterAnimatorManager.SetAnimatorParameters(horizontalInput, verticalInput, true);

        //float speed = character.walkSpeed;

        //character.characterController.Move(speed * Time.deltaTime * moveDirection);

        //Debug.Log("move : " + horizontalInput + ", " + verticalInput);
    }

    protected virtual void HandleRotation()
    {
        targetRotationDirection = playerCamera.forward * verticalInput;
        targetRotationDirection += playerCamera.right * horizontalInput;
        targetRotationDirection.y = 0f;
        targetRotationDirection.Normalize();

        if (targetRotationDirection == Vector3.zero)
        {
            targetRotationDirection = character.transform.forward;
        }

        targetRotation = Quaternion.LookRotation(targetRotationDirection);

        finalRotation = Quaternion.Slerp(character.transform.rotation, targetRotation, character.rotationDampTime * Time.deltaTime);
        character.transform.rotation = finalRotation;
    }

    public abstract void GetMovementInput();
}