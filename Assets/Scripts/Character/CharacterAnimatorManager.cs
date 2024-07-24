using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAnimatorManager : MonoBehaviour
{
    Character character;

    public DamageHandler[] damageHandlers;

    private int previousActionHash;
    private int nextActionHash;

    private static readonly int attack1 = Animator.StringToHash("punch_body");
    private static readonly int attack2 = Animator.StringToHash("punch_cross");

    protected virtual void Awake()
    {
        character = GetComponent<Character>();
        damageHandlers = GetComponentsInChildren<DamageHandler>();
    }

    public void SetAnimatorParameters(float horizontalInput, float verticalInput, bool applyRootMotion = false)
    {
        character.applyRootMotion = applyRootMotion;

        character.animator.SetFloat("SpeedX", horizontalInput, character.speedDampTime, Time.deltaTime);
        character.animator.SetFloat("SpeedY", verticalInput, character.speedDampTime, Time.deltaTime);
    }

    protected virtual void PlayCharacterActionAnimation(
        int animationClipHash,
        bool canRotate = false,
        bool canMove = false,
        bool applyRootMotion = true)
    {
        previousActionHash = animationClipHash;

        character.animator.CrossFade(animationClipHash, character.animationFadeTime);

        character.applyRootMotion = applyRootMotion;
        character.canRotate = canRotate;
        character.canMove = canMove;
    }

    public void PlayAttackAnimation(bool canCombo)
    {
        nextActionHash = attack1;

        if (canCombo)
        {
            if (previousActionHash == attack1)
                nextActionHash = attack2;
            else if (previousActionHash == attack2)
                nextActionHash = attack1;
        }

        PlayCharacterActionAnimation(nextActionHash);
    }

    // Animation events
    public void StartDamage()
    {
        foreach (var handler in damageHandlers)
        {
            handler.StartDamage();
        }
    }

    public void StopDamage()
    {
        foreach (var handler in damageHandlers)
        {
            handler.StopDamage();
        }
    }

    public void EnableCombo()
    {
        character.canCombo = true;
    }

    public void DisableCombo()
    {
        character.canCombo = false;
    }
}
