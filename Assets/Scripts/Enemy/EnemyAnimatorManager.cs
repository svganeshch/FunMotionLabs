using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : CharacterAnimatorManager
{
    Enemy enemy;
    Transform playerTransform;

    protected override void Awake()
    {
        base.Awake();

        enemy = GetComponent<Enemy>();
        playerTransform = enemy.transform;
    }

    private void OnAnimatorMove()
    {
        if (enemy.applyRootMotion)
        {
            Vector3 velocity = enemy.animator.deltaPosition;

            enemy.characterController.Move(velocity);
            playerTransform.rotation *= enemy.animator.deltaRotation;
        }
    }
}
