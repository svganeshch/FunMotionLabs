using UnityEngine;

public class PlayerAnimatorManager : CharacterAnimatorManager
{
    Player player;
    Transform playerTransform;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<Player>();
        playerTransform = player.transform;
    }

    private void OnAnimatorMove()
    {
        if (player.applyRootMotion)
        {
            Vector3 velocity = player.animator.deltaPosition;

            player.characterController.Move(velocity);
            playerTransform.rotation *= player.animator.deltaRotation;
        }
    }
}